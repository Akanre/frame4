using FrameworkApp.Core;
using FrameworkApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FrameworkApp.Modules;

public class LoggingModule : IModule
{
    public string Name => "LoggingModule";

    public IEnumerable<string> Dependencies => new List<string>();

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<Logger>();
    }

    public void Initialize(IServiceProvider provider)
    {
        var logger = provider.GetRequiredService<Logger>();
        logger.Log("LoggingModule инициализирован");
    }
}