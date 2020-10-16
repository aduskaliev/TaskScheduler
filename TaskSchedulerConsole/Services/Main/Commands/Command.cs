using System;
using System.Collections.Generic;
using System.Text;

namespace TaskSchedulerConsole.Services.Main.Commands
{
    class Command : ICommand
    {
        public string Name => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public bool Execute(object userData, out object returnData, out string message)
        {
            throw new NotImplementedException();
        }
    }
}
