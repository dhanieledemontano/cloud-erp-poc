using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Reflection;
using Newtonsoft.Json;
using System.Dynamic;
using Cloud.ERP.Benchmark.PerformanceTests.Base;
using Microsoft.Extensions.Configuration;
using Npgsql;


BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args);


//void TestPgsql()
//{
//    string cnString = SetConfig.PostgreConnectionStrings;
//    NpgsqlConnection connection = new NpgsqlConnection(cnString);


//    try
//    {
//        connection.Open();
//        Console.WriteLine("Connected to PostgreSQL!");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Error: {ex.Message}");
//    }
//    finally
//    {
//        connection.Close();
//    }

//    string query = "SELECT * FROM  \"ConfigDb\" ";
//    NpgsqlCommand queryCommand = new NpgsqlCommand(query, connection);

//    try
//    {
//        connection.Open();
//        NpgsqlDataReader reader = queryCommand.ExecuteReader();
//        while (reader.Read())
//        {
//            Console.WriteLine($"Connection Name: {reader["ConnectionName"]} ");
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Error: {ex.Message}");
//    }
//    finally
//    {
//        connection.Close();
//    }

//}




#region MyRegion
//string ReadAppsettingsJson()
//{
//    var appSettingsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "appsettings.json");
//    var json = File.ReadAllText(appSettingsPath);
//    var jsonSettings = new JsonSerializerSettings();
//    dynamic config = DeserializeJsonObject(json, jsonSettings);
//    return json;
//}

//dynamic DeserializeJsonObject(string json, JsonSerializerSettings jsonSettings)
//{
//    dynamic configResult = JsonConvert.DeserializeObject<ExpandoObject>(json, jsonSettings);
//    return (configResult != null ? configResult : null);
//}
#endregion


[MemoryDiagnoser]
[ShortRunJob]
//[MediumRunJob]
//[LongRunJob]
public class CloudERPBenchmarks
{
    //Always run in Release build

    [Benchmark]
    public void TestBenchmark()
    {
        //Test something
        //TestPostgres();
    }

    [Benchmark]
    public void TestPostgres()
    {
        string cnString = SetConfig.PostgreConnectionStrings;
        NpgsqlConnection connection = new NpgsqlConnection(cnString);

        string query = "SELECT * FROM  \"ConfigDb\" ";
        NpgsqlCommand queryCommand = new NpgsqlCommand(query, connection);

        try
        {
            connection.Open();
            NpgsqlDataReader reader = queryCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Connection Name: {reader["ConnectionName"]} ");
            }
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



