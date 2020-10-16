using System.Collections.Generic;

namespace TaskSchedulerConsole.Services.Main
{
    internal interface IFrame
    {
        void DisplayMenu();
        void GetInput();
        void ProcessInput(out string message);
        IFrame Next();
    }
}