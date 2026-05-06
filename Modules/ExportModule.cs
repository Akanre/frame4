using FrameworkApp.Core;
using FrameworkApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FrameworkApp.Modules;

public class ExportModule : IModule
{
    public string Name => "ExportModule";

    public IEnumerable<string> Dependencies => new[] { "ReportModule" };

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ExportService>();
    }

    public void Initialize(IServiceProvider provider)
    {
        var service = provider.GetRequiredService<ExportService>();
        service.Run();
    }
}

public class ExportService
{
    private readonly Logger _logger;

    public ExportService(Logger logger)
    {
        _logger = logger;
    }

    public void Run()
    {
        _logger.Log("Экспорт данных");
    }
}