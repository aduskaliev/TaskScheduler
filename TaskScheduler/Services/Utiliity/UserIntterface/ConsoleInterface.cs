using TaskSchedulerConsole;

namespace TaskScheduler.Services.Utiliity
{
    internal class ConsoleInterface : IUserInterface
    {
        private readonly ConsoleSession _instance;

        public ConsoleInterface()
        {
            _instance = new ConsoleSession();
        }

        public void Run()
        {
            _instance.Run();
        }
    }
}
