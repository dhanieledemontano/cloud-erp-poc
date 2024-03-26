using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.ERP.Benchmark.PerformanceTests.Base.DBUpdater
{
    public class MssqlDBUpdater
    {
        public static void InitializeDb(SqlConnection connection)
        {
            string query = "IF OBJECT_ID(N'dbo.Contact', N'U') IS NULL " +
                           "CREATE TABLE dbo.Contact (Id INT Identity(1,1) PRIMARY KEY, " +
                           "Name VARCHAR(255) NOT NULL, " +
                           "Address VARCHAR(255) NOT NULL, " +
                           "ContactNo VARCHAR(255) NOT NULL, " +
                           "Remarks VARCHAR(255) NOT NULL)";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("MSSQL Table created!");
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
