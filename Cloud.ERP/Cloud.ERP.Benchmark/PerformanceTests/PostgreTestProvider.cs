using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.ERP.Benchmark.PerformanceTests.Base;
using Npgsql;

namespace Cloud.ERP.Benchmark.PerformanceTests
{
    public abstract class PostgreTestProvider : TestProviderBase
    {
        public static void InsertContact(int recordsCount, NpgsqlConnection connection)
        {
            TruncateTable("Contact", connection);
            for (int i = 0; i < recordsCount; i++)
            {
                string insertSql = "INSERT INTO \"Contact\" (\"Id\", \"Name\", \"Address\", \"ContactNo\", \"Remarks\") VALUES (@id, @name, @address, @contactno, @remarks)";
                NpgsqlCommand insertCommand = new NpgsqlCommand(insertSql, connection);

                insertCommand.Parameters.AddWithValue("@id", i);
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

        public static int GetLastRecord(string tableName, NpgsqlConnection connection)
        {
            string selectTop = $"SELECT * FROM \"{tableName}\" ORDER BY \"Id\" DESC LIMIT 1";
            NpgsqlCommand selectTopCommand = new NpgsqlCommand(selectTop, connection);
            connection.Open();
            NpgsqlDataReader reader = selectTopCommand.ExecuteReader();
            while (reader.Read())
            {
               int value = (int)reader["Id"];
               connection.Close();
               return value;
            }
            return 0;
        }

        public static void DropTable(string tableName, NpgsqlConnection connection)
        {
            string dropSql = $"DROP TABLE \"{tableName}\" ";
            NpgsqlCommand dropCommand = new NpgsqlCommand(dropSql, connection);
            ExecuteCommand(dropCommand, connection);
        }

        public static void TruncateTable(string tableName, NpgsqlConnection connection)
        {
            string truncateSql = $"TRUNCATE \"{tableName}\" CASCADE ";
            NpgsqlCommand truncateCommand = new NpgsqlCommand(truncateSql, connection);
            ExecuteCommand(truncateCommand, connection);
        }

        public static void ExecuteCommand(NpgsqlCommand command, NpgsqlConnection connection)
        {
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
