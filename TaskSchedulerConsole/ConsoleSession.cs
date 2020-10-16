using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskSchedulerConsole.Services.Main;
using TaskSchedulerConsole.Services.Main.Frame;

namespace TaskSchedulerConsole
{
    public class ConsoleSession
    {
        private readonly object _instance;
        private static IServiceCollection _serviceCollection;
        public static IServiceCollection ServiceCollection => _serviceCollection;

        public ConsoleSession(IServiceCollection serviceCollection)
        {
            _instance = new object();
            _serviceCollection = serviceCollection;
            RegisterServices();
        }

        public void Run()
        {
            IFrame frame = new StartFrame();
            string message = null;

            do {
                frame.DisplayMenu();
                frame.GetInput();
                frame.ProcessInput(out message);
                frame = frame.Next();

                if (message != null)
                {
                    DisplayMessage(message);
                    message = null;
                }
            } while (frame != null);
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void RegisterServices()
        {

        }
    }
}
