using Microsoft.Extensions.DependencyInjection;

namespace FrameworkApp.Core;

public interface IModule
{
    string Name { get; }
    IEnumerable<string> Dependencies { get; }

    void ConfigureServices(IServiceCollection services);
    void Initialize(IServiceProvider provider);
}