using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Cloud.ERP.Benchmark.PerformanceTests.Base.DBUpdater
{
    public class PostgresDBUpdater
    {
        public static void InitializeDb(NpgsqlConnection connection)
        {
            string query = "CREATE TABLE IF NOT EXISTS \"Contact\"  (" +
                           "\"Id\"  serial PRIMARY KEY," +
                           "\"Name\"  VARCHAR(255) NOT NULL," +
                           "\"Address\"  VARCHAR(255) NOT NULL," +
                           "\"ContactNo\"  VARCHAR(255) NOT NULL, " +
                           "\"Remarks\" VARCHAR(255) NOT NULL)";

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);


            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("PSQL Table created!");
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
