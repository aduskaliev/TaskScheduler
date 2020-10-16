using System;
using System.Collections.Generic;
using System.Text;

namespace TaskSchedulerConsole.Services.Main.Commands
{
    class GetTaskListsCommand : ICommand
    {
        private string _name = "ShowTaskLists";
        public string Name => _name;

        private string _description = "Shows all task lists";
        public string Description => throw new NotImplementedException();

        public bool Execute(object userData, out object returnData, out string message)
        {
            object reply = null;
            reply = GetTaskLists(out message);
            if (reply != null)
            {
                returnData = reply;
                return true;
            }
            returnData = null;
            message ??= "Failed to load data. Please try again";
            return false;
        }
    }
}
