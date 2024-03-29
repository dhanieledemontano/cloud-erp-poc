﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.ERP.Module.QueryExecutor.Implementation
{
    public class QueryExecutor : QueryExecutorBase
    {

        private readonly string _connectionString;

        public QueryExecutor(string connectionString) =>
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
            if (!string.IsNullOrEmpty(_connectionString))
            {
                return (_connectionString.Contains("postgre") ? "SELECT * FROM \"ConfigDb\" " : "SELECT * FROM [dbo].[ConfigDb]");
            }
            return null;
        }
    }
}
