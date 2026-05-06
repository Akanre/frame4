using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FrameworkApp.Core;

public class ModuleManager
{
    public List<IModule> LoadModules(IEnumerable<string> moduleNames)
    {
        var modules = new List<IModule>();

        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => typeof(IModule).IsAssignableFrom(t) && !t.IsInterface);

        foreach (var name in moduleNames)
        {
            var type = types.FirstOrDefault(t => t.Name == name);

            if (type == null)
                throw new Exception($"❌ Модуль не найден: {name}");

            modules.Add((IModule)Activator.CreateInstance(type)!);
        }

        return Sort(modules);
    }

    private List<IModule> Sort(List<IModule> modules)
    {
        var result = new List<IModule>();
        var visited = new HashSet<string>();
        var visiting = new HashSet<string>();

        void Visit(IModule module)
        {
            if (visited.Contains(module.Name))
                return;

            if (visiting.Contains(module.Name))
                throw new Exception($"❌ Циклическая зависимость: {module.Name}");

            visiting.Add(module.Name);

            foreach (var dep in module.Dependencies)
            {
                var depModule = modules.FirstOrDefault(m => m.Name == dep);

                if (depModule == null)
                    throw new Exception($"❌ Нет зависимости: {dep}");

                Visit(depModule);
            }

            visiting.Remove(module.Name);
            visited.Add(module.Name);
            result.Add(module);
        }

        foreach (var m in modules)
            Visit(m);

        return result;
    }

    public IServiceProvider BuildProvider(List<IModule> modules)
    {
        var services = new ServiceCollection();

        foreach (var module in modules)
        {
            module.ConfigureServices(services);
        }

        return services.BuildServiceProvider();
    }

    public void InitializeModules(List<IModule> modules, IServiceProvider provider)
    {
        foreach (var module in modules)
        {
            Console.WriteLine($"➡️ Запуск: {module.Name}");
            module.Initialize(provider);
        }
    }
}