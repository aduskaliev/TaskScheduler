using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskSchedulerConsole.Services.Main.Menu
{
    internal class MenuFactory
    {
        public static IMenu Create(
            string header,
            List<ICommand> commandList,
            string commandListHeader= null,
            string footer = null
            )
        {            
            IMenuComponent 
                _header = MenuComponentFactory.Create(header),
                _commandListHeader = MenuComponentFactory.Create(commandListHeader),
                _footer = MenuComponentFactory.Create(footer),
                _commandList = MenuComponentFactory.CreateFromListMarked(
                    commandList.Select(el => (el.Name + " - " + el.Description)).ToList()
                );

            List<IMenuComponent> menuComponents = new List<IMenuComponent>
            {
                _header,
                _commandListHeader,
                _commandList,
                _footer,
            }
            .Where(el => el != null).ToList();

            return new Menu(menuComponents);
        }

        public static IMenu CreateTable<DataType>(
            string header,            
            Dictionary<DataType, string> data,
            List<ICommand> commandList,
            string dataHeader = null,
            string commandListHeader = null,
            string footer = null
            )
            where DataType : IFormattable
        {
            IMenuComponent
                _header = MenuComponentFactory.Create(header),
                _dataHeader = MenuComponentFactory.Create(dataHeader),
                _commandListHeader = MenuComponentFactory.Create(commandListHeader),
                _footer = MenuComponentFactory.Create(footer),
                _data = MenuComponentFactory.CreateFromDictionary<DataType>(data),
                _commandList = MenuComponentFactory.CreateFromListMarked(
                    commandList.Select(el => (el.Name + " - " + el.Description)).ToList()
                );

            List<IMenuComponent> menuComponents = new List<IMenuComponent>
            {
                _header,
                _dataHeader,
                _data,
                _commandListHeader,
                _commandList,
                _footer,
            }
            .Where(el => el != null).ToList();

            return new Menu(menuComponents);
        }
    }
}
