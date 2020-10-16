using System.Collections.Generic;
using TaskSchedulerConsole.Services.Main.Menu;

namespace TaskSchedulerConsole.Services.Main
{
    internal class SimpleFrameContext : FrameContext
    {
        private List<ICommand> _commandList;
        public List<ICommand> CommandList => _commandList;

        public SimpleFrameContext()
        {

        }
        public SimpleFrameContext(IMenu menu, List<ICommand> commandList)
        {
            _menu = menu;
            _commandList = commandList;
        }
    }
}
