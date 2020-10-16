using Microsoft.Extensions.DependencyInjection;
using TaskScheduler.Services.Utiliity;

namespace TaskScheduler
{
    class Startup
    {
        static void Main()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            Configure(serviceCollection);
            RegisterServices(serviceCollection);

            serviceCollection.AddSingleton(provider => new Application());
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();            
            Application app = serviceProvider.GetService<Application>();
            app.Run(serviceCollection);
        }

        static void Configure(IServiceCollection serviceCollection)
        {
            string pathToConfig = "config.ini";
  
            serviceCollection.AddSingleton(provider => IniConfiguration.ConfigurationBuilder(serviceCollection, pathToConfig));
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<IniConfiguration>();
        }

        static void RegisterServices(IServiceCollection serviceCollection)
        {

        }
    }
}
