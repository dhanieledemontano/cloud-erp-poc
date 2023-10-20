using Cloud.ERP.Module.BusinessObjects.Configuration;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;

namespace Cloud.ERP.Module.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
        base(objectSpace, currentDBVersion) {
    }
    public override void UpdateDatabaseAfterUpdateSchema() {
        base.UpdateDatabaseAfterUpdateSchema();
        //string name = "MyName";
        //DomainObject1 theObject = ObjectSpace.FirstOrDefault<DomainObject1>(u => u.Name == name);
        //if(theObject == null) {
        //    theObject = ObjectSpace.CreateObject<DomainObject1>();
        //    theObject.Name = name;
        //}

        //ObjectSpace.CommitChanges(); //Uncomment this line to persist created object(s).

        var mssqlConn = ObjectSpace.FirstOrDefault<ConfigDb>(x => x.ConnectionName == "Microsoft SQL");
        if (mssqlConn is null)
        {
            mssqlConn = ObjectSpace.CreateObject<ConfigDb>();
            mssqlConn.ConnectionName = "Microsoft SQL";
            mssqlConn.ConnectionValue = "XpoProvider=MSSqlServer;User=sa;Password=1t_r3publ1c;Pooling=false;Data Source=localhost,1533;Initial Catalog=CloudERPDb;Encrypt=False";
            mssqlConn.IsActive = true;
        }
        var postgresConn = ObjectSpace.FirstOrDefault<ConfigDb>(x => x.ConnectionName == "Postgres");
        if (postgresConn is null)
        {
            postgresConn = ObjectSpace.CreateObject<ConfigDb>();
            postgresConn.ConnectionName = "Postgres";
            postgresConn.ConnectionValue = "XpoProvider=Postgres;Host=localhost;Port=5532;User ID=postgres;Password=1t_r3publ1c;Database=CloudERPDb;Encoding=UNICODE";
            postgresConn.IsActive = true;
        }
        ObjectSpace.CommitChanges();
    }
    public override void UpdateDatabaseBeforeUpdateSchema() {
        base.UpdateDatabaseBeforeUpdateSchema();
        //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
        //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
        //}
    }
}
