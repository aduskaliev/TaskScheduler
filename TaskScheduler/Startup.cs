using Microsoft.Extensions.DependencyInjection;
using TaskScheduler.Services.Utility;

namespace TaskScheduler
{
    public class Startup
    {
        private static IServiceCollection _serviceCollection;
        private static string _pathToConfig;

        static Startup()
        {
            _serviceCollection = new ServiceCollection();
            _pathToConfig = "config.ini";
        }

        static void Main()
        {
            RegisterServices();
            Configure();            
          
            Application app = _serviceCollection.BuildServiceProvider().GetService<Application>();
            app.Run(_serviceCollection);
        }        

        private static void RegisterServices()
        {
            _serviceCollection.AddSingleton(provider => new Application());
            _serviceCollection.AddSingleton(provider => IniConfiguration.ConfigurationBuilder(_serviceCollection, _pathToConfig));
        }

        private static void Configure()
        {
            _serviceCollection.BuildServiceProvider().GetService<IniConfiguration>();
        }
    }
}
