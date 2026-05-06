using FrameworkApp.Core;
using System.Text.Json;

class Program
{
    static void Main()
    {
        var json = File.ReadAllText("appsettings.json");
        var config = JsonSerializer.Deserialize<Config>(json);

        var manager = new ModuleManager();

        var modules = manager.LoadModules(config.Modules);

        var provider = manager.BuildProvider(modules);

        manager.InitializeModules(modules, provider);
    }
}

public class Config
{
    public List<string> Modules { get; set; }
}