﻿
---index

--Ref. link: https://www.mssqltips.com/sqlservertip/3441/script-out-all-sql-server-indexes-in-a-database-using-tsql/
--Exporting all indexes
declare @SchemaName varchar(100)declare @TableName varchar(256)
declare @IndexName varchar(256)
declare @ColumnName varchar(100)
declare @is_unique varchar(100)
declare @IndexTypeDesc varchar(100)
declare @FileGroupName varchar(100)
declare @is_disabled varchar(100)
declare @IndexOptions varchar(max)
declare @IndexColumnId int
declare @IsDescendingKey int 
declare @IsIncludedColumn int
declare @TSQLScripCreationIndex varchar(max)
declare @TSQLScripDisableIndex varchar(max)
declare @filter_definition varchar(max)

declare @BoolColumns table
(
colValue varchar(200),
colReplaceValue varchar(200)
)
insert into @BoolColumns
select distinct COLUMN_NAME+'=(0)',COLUMN_NAME+'=false' from INFORMATION_SCHEMA.COLUMNS where DATA_TYPE='bit'
union
select distinct COLUMN_NAME+'=(1)',COLUMN_NAME+'=true' from INFORMATION_SCHEMA.COLUMNS where DATA_TYPE='bit'


declare @constraints table
(
command varchar(max)
)

declare CursorIndex cursor for
 select schema_name(t.schema_id) [schema_name], t.name, ix.name,
 case when ix.is_unique = 1 then 'UNIQUE ' else '' END 
 , ix.type_desc,
 case when ix.is_padded=1 then 'PAD_INDEX = ON, ' else 'PAD_INDEX = OFF, ' end
 + case when ix.allow_page_locks=1 then 'ALLOW_PAGE_LOCKS = ON, ' else 'ALLOW_PAGE_LOCKS = OFF, ' end
 + case when ix.allow_row_locks=1 then  'ALLOW_ROW_LOCKS = ON, ' else 'ALLOW_ROW_LOCKS = OFF, ' end
 + case when INDEXPROPERTY(t.object_id, ix.name, 'IsStatistics') = 1 then 'STATISTICS_NORECOMPUTE = ON, ' else 'STATISTICS_NORECOMPUTE = OFF, ' end
 + case when ix.ignore_dup_key=1 then 'IGNORE_DUP_KEY = ON, ' else 'IGNORE_DUP_KEY = OFF, ' end
 + 'SORT_IN_TEMPDB = OFF, FILLFACTOR =' + CAST(ix.fill_factor AS VARCHAR(3)) AS IndexOptions
 , ix.is_disabled , FILEGROUP_NAME(ix.data_space_id) FileGroupName,
 filter_definition
 from sys.tables t 
 inner join sys.indexes ix on t.object_id=ix.object_id
 where ix.type>0 and ix.is_primary_key=0 and ix.is_unique_constraint=0 --and schema_name(tb.schema_id)= @SchemaName and tb.name=@TableName
 and t.is_ms_shipped=0 and t.name<>'sysdiagrams'
 and
 ( schema_name(t.schema_id)+'.'+t.name in(select tablename from include_table_list)
or (select count(1) from include_table_list)=0)  
 order by schema_name(t.schema_id), t.name, ix.name

open CursorIndex
fetch next from CursorIndex into  @SchemaName, @TableName, @IndexName, @is_unique, @IndexTypeDesc, @IndexOptions,@is_disabled, @FileGroupName,@filter_definition

while (@@fetch_status=0)
begin
 declare @IndexColumns varchar(max)
 declare @IncludedColumns varchar(max)
 declare @DType varchar(max)
 set @IndexColumns=''
 set @IncludedColumns=''
 
 declare CursorIndexColumn cursor for 
  select col.name, ixc.is_descending_key, ixc.is_included_column
  from sys.tables tb 
  inner join sys.indexes ix on tb.object_id=ix.object_id
  inner join sys.index_columns ixc on ix.object_id=ixc.object_id and ix.index_id= ixc.index_id
  inner join sys.columns col on ixc.object_id =col.object_id  and ixc.column_id=col.column_id
  inner JOIN sys.types AS ty ON ty.user_type_id=col.user_type_id
  where ix.type>0 and (ix.is_primary_key=0 or ix.is_unique_constraint=0)
  and schema_name(tb.schema_id)=@SchemaName and tb.name=@TableName and ix.name=@IndexName
  order by ixc.index_column_id
 
 open CursorIndexColumn 
 fetch next from CursorIndexColumn into  @ColumnName, @IsDescendingKey, @IsIncludedColumn
 
 while (@@fetch_status=0)
 begin
  if @IsIncludedColumn=0 
   set @IndexColumns=@IndexColumns + lower ( @ColumnName)  + case when @IsDescendingKey=1  then ' DESC, ' else  ' ASC, ' end
  else 
   set @IncludedColumns=@IncludedColumns  + lower (@ColumnName ) +', ' 

  fetch next from CursorIndexColumn into @ColumnName, @IsDescendingKey, @IsIncludedColumn
 end

 close CursorIndexColumn
 deallocate CursorIndexColumn

 set @IndexColumns = substring(@IndexColumns, 1, len(@IndexColumns)-1)
 set @IncludedColumns = case when len(@IncludedColumns) >0 then substring(@IncludedColumns, 1, len(@IncludedColumns)-1) else '' end

 --set @filter_definition = replace(replace(replace(replace(replace(@filter_definition, '[', ''), ']', ''), '(1)', 'true'), '(0)', 'false'), '=', ' = ')
 set @filter_definition = replace(replace(@filter_definition, '[', ''), ']', '')
 select @filter_definition = replace(@filter_definition,colValue,colReplaceValue)  from @BoolColumns

 set @TSQLScripCreationIndex =''
 set @TSQLScripDisableIndex =''
 set @TSQLScripCreationIndex='CREATE '+ @is_unique  + ' INDEX '  +  replace( replace(  lower (replace(replace(replace(replace(@IndexName,'Registration','reg'),'Patient','pat'),'Additional','add'),'Organisation','org')),'i_x__','ix_'),'__','_') +' ON ' + lower (@SchemaName) +'.'+ lower (@TableName) + '('+@IndexColumns+') '+ 
  case when len(@IncludedColumns)>0 then CHAR(13) +'INCLUDE (' + @IncludedColumns+ ')' else '' end + case  when @filter_definition is null then '' else ' where ' +  @filter_definition end  + ';' + char(13)  + CHAR(13) --+'WITH (' + @IndexOptions+ ') ON ' + QUOTENAME(@FileGroupName) + ';'  

-- print lower(@TSQLScripCreationIndex)
-- print @TSQLScripDisableIndex

	if ltrim(@TSQLScripDisableIndex)<>''
	begin
	insert into @constraints
	select @TSQLScripDisableIndex
	end

 fetch next from CursorIndex into  @SchemaName, @TableName, @IndexName, @is_unique, @IndexTypeDesc, @IndexOptions,@is_disabled, @FileGroupName, @filter_definition

end
close CursorIndex
deallocate CursorIndex


select * from @constraints