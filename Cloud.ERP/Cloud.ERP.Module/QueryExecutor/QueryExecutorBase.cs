using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.ERP.Module.QueryExecutor
{
    public abstract class QueryExecutorBase
    {
        protected readonly List<QueryExecutorBase> ExecutorBase = new List<QueryExecutorBase>();
        public string DisplayConnectionString(string connectionString)
        {
            Console.WriteLine(connectionString);
            return connectionString;
        }

        public abstract void LoadData();
        public abstract void SaveData();
        public abstract string LoadConfigDb();

        public void Add(QueryExecutorBase queryExecutor) => ExecutorBase.Add(queryExecutor);
        public void Remove(QueryExecutorBase queryExecutor) => ExecutorBase.Remove(queryExecutor);
    }
}
