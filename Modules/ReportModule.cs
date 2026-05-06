using FrameworkApp.Core;
using FrameworkApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FrameworkApp.Modules;

public class ReportModule : IModule
{
    public string Name => "ReportModule";

    public IEnumerable<string> Dependencies => new[] { "LoggingModule" };

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ReportService>();
    }

    public void Initialize(IServiceProvider provider)
    {
        var service = provider.GetRequiredService<ReportService>();
        service.Run();
    }
}

public class ReportService
{
    private readonly Logger _logger;

    public ReportService(Logger logger)
    {
        _logger = logger;
    }

    public void Run()
    {
        _logger.Log("Генерация отчёта");
    }
}