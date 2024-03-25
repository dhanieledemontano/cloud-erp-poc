
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Reflection;
using Newtonsoft.Json;
using System.Dynamic;

BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args);


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
    }

    private (string json, string appSettingsPath, string dbTypeString) ReadAppsettingsJson()
    {
        var appSettingsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "appsettings.json");
        var json = File.ReadAllText(appSettingsPath);
        var jsonSettings = new JsonSerializerSettings();
        dynamic config = DeserializeJsonObject(json, jsonSettings);
        string dbTypeString = config.ConnectionStrings.ConnectionString;
        Console.WriteLine(dbTypeString);
        return (json: json, appSettingsPath: appSettingsPath, dbTypeString: dbTypeString);
    }

    private dynamic DeserializeJsonObject(string json, JsonSerializerSettings jsonSettings)
    {
        dynamic configResult = JsonConvert.DeserializeObject<ExpandoObject>(json, jsonSettings);
        return (configResult != null ? configResult : null);
    }

}




