using Microsoft.Extensions.DependencyInjection;
using TaskSchedulerConsole;

namespace TaskScheduler.Services.Utility
{
    internal class ConsoleInterface : IUserInterface
    {
        private readonly ConsoleSession _instance;

        public ConsoleInterface(IServiceCollection serviceCollection)
        {
            _instance = new ConsoleSession(serviceCollection);
        }

        public void Run()
        {
            _instance.Run();
        }
    }
}
