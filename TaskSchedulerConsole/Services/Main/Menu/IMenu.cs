using System.Collections.Generic;

namespace TaskSchedulerConsole.Services.Main.Menu
{
    internal interface IMenu
    {
        public List<IMenuComponent> MenuContext { get; }
        void Display();
    }
}
