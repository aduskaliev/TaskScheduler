using System;
using System.Collections.Generic;

namespace TaskSchedulerConsole.Services.Main.Menu
{
    internal class Menu : IMenu
    {
        private readonly List<IMenuComponent> _menuContext;
        public List<IMenuComponent> MenuContext => _menuContext;
        public Menu(List<IMenuComponent> menuContext)
        {
            _menuContext = menuContext;
        }

        public void Display()
        {
            foreach (var el in _menuContext)
            {
                Console.Write(el);
            }
        }
    }
}
