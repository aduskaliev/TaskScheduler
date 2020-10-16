using System;
using System.Collections.Generic;
using System.Text;

namespace TaskSchedulerConsole.Services.Main
{
    internal interface ICommand
    {
        public string Name { get; }
        public string Description { get; }
        bool Execute(object userData, out object returnData, out string message);
    }
}
