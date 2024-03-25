using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.ERP.Benchmark.PerformanceTests.Base
{
    public class SetConfig
    {
        public static string XPOConnectionStrings => "XpoProvider=MSSqlServer;" + ConfigurationManager.ConnectionStrings["ConnectionString_XPO"].ConnectionString;
        public static string EFCoreConnectionStrings => ConfigurationManager.ConnectionStrings["ConnectionString_EFCore"].ConnectionString;
        public static string PostgreConnectionStrings => ConfigurationManager.ConnectionStrings["ConnectionString_Postgres"].ConnectionString;

        public SetConfig()
        {
            //TestConfig();
        }

        private void TestConfig()
        {
            string cnString = SetConfig.PostgreConnectionStrings;
            NpgsqlConnection connection = new NpgsqlConnection(cnString);

            try
            {
                connection.Open();
                Console.WriteLine("Connected to PostgreSQL!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
