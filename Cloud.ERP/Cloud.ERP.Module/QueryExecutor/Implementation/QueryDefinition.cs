using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.ERP.Module.QueryExecutor.Implementation
{
    public class QueryDefinition : QueryExecutorBase
    {
        private readonly string _connectionString;

        public QueryDefinition(string connectionString) =>
            _connectionString = connectionString;

        public override void LoadData()
        {
            throw new NotImplementedException();
        }

        public override void SaveData()
        {
            throw new NotImplementedException();
        }

        public override string LoadConfigDb()
        {
            foreach (QueryExecutorBase executionBase in ExecutorBase)
            {
                return executionBase.LoadConfigDb();
            }

            return null;
        }
    }
}
