using System;
using System.Collections.Generic;
using TaskSchedulerConsole.Services.Main.Menu;

namespace TaskSchedulerConsole.Services.Main
{
    class TableFrameContext<KeyType, ValueType> : FrameContext
        where KeyType : IFormattable
    {
        private List<ICommand> _commandList;
        public List<ICommand> CommandList => _commandList;

        private Dictionary<KeyType, ValueType> _data;
        public Dictionary<KeyType, ValueType> Data => _data;

        public TableFrameContext(IMenu menu, List<ICommand> commandList, Dictionary<KeyType, ValueType> data)
        {
            _menu = menu;
            _commandList = commandList;
            _data = data;
        }
    }
}
