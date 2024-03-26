using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.ERP.Benchmark.PerformanceTests.Base;
using Npgsql;

namespace Cloud.ERP.Benchmark.PerformanceTests
{
    public abstract class MssqlTestProvider : TestProviderBase
    {
        public static void InsertContact(int recordsCount, SqlConnection connection)
        {
            TruncateTable("Contact", connection);
            for (int i = 0; i < recordsCount; i++)
            {
                string insertSql = "INSERT INTO dbo.Contact (Name, Address, ContactNo, Remarks) VALUES " +
                                   "(@name, @address, @contactno, @remarks)";
                SqlCommand insertCommand = new SqlCommand(insertSql, connection);

                insertCommand.Parameters.AddWithValue("@name", $"John Doe{i}");
                insertCommand.Parameters.AddWithValue("@address", $"Address {i}");
                insertCommand.Parameters.AddWithValue("@contactno", $"320{i}");
                insertCommand.Parameters.AddWithValue("@remarks", $"remarks {i}");

                try
                {
                    connection.Open();
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    //Console.WriteLine($"Inserted {rowsAffected} row(s)!");
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

        public static void TruncateTable(string tableName, SqlConnection connection)
        {
            string truncateSql = $"TRUNCATE TABLE dbo.{tableName}";
            SqlCommand truncateCommand = new SqlCommand(truncateSql, connection);
            ExecuteCommand(truncateCommand, connection);
        }

        public static void ExecuteCommand(SqlCommand command, SqlConnection connection)
        {
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
