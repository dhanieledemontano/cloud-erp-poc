using System.Data.SqlClient;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Reflection;
using Newtonsoft.Json;
using System.Dynamic;
using Cloud.ERP.Benchmark.PerformanceTests;
using Cloud.ERP.Benchmark.PerformanceTests.Base;
using Cloud.ERP.Benchmark.PerformanceTests.Base.DBUpdater;
using Microsoft.Extensions.Configuration;
using Npgsql;

UpdatePostgresDb();
UpdateMssqlDb();

BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args);
void UpdatePostgresDb()
{
    string cnString = SetConfig.PostgreConnectionStrings;
    NpgsqlConnection connection = new NpgsqlConnection(cnString);
    PostgresDBUpdater.InitializeDb(connection);
}
void UpdateMssqlDb()
{
    string cnString = SetConfig.MssqlConnectionStrings;
    SqlConnection connection = new SqlConnection(cnString);
    MssqlDBUpdater.InitializeDb(connection);
}



[Config(typeof(AntiVirusPassConfig))]
[MemoryDiagnoser]
//[ShortRunJob]
//[MediumRunJob]
//[LongRunJob]
public class CloudErpBenchmarks
{
    //Always run in Release build

    List<int>? _list;

    [Params(1_000, 5_000, 8_000, 10_000)]
    public int ListSize;

    [GlobalSetup]
    public void Setup()
    {
        _list = new List<int>();
        for (int i = 0; i < ListSize; i++)
        {
            _list.Add(i);
        }
    }

    [Benchmark]
    public void PostgreInsertContact()
    {
        string cnString = SetConfig.PostgreConnectionStrings;
        NpgsqlConnection connection = new NpgsqlConnection(cnString);
        PostgreTestProvider.InsertContact(_list.Count, connection);
    }

    [Benchmark]
    public void MssqlInsertContact()
    {
        string cnString = SetConfig.MssqlConnectionStrings;
        SqlConnection connection = new SqlConnection(cnString);
        MssqlTestProvider.InsertContact(_list.Count, connection);
    }
}



