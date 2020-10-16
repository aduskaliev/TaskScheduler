using System;
using System.Collections.Generic;
using System.Text;
using TaskSchedulerConsole.Services.Main.Menu;

namespace TaskSchedulerConsole.Services.Main
{
    internal class InputFrameContext : FrameContext
    {
        private ICommand _command;
        public ICommand Command => _command;

        private Dictionary<string, string> _dataTemplate;
        public Dictionary<string, string> DataTemplate { get => _dataTemplate; set => _dataTemplate = value; }

        public InputFrameContext(IMenu menu, ICommand command, Dictionary<string, string> dataTemplate)
        {
            _menu = menu;
            _command = command;
            _dataTemplate = dataTemplate;            
        }
    }
}
