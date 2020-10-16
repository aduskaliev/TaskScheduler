using System;
using System.Collections.Generic;
using System.Linq;
using DataClassses;

namespace TaskScheduler.Services.Main
{
    public static class TaskListService
    {
        static internal Dictionary<string, TaskList> listOfTaskLists;

        static TaskListService()
        {
            listOfTaskLists = LoadTaskLists();
        }

        public static Dictionary<string, TaskList> LoadTaskLists()
        {
            // Implement
            return new Dictionary<string, TaskList>();
        }

        public static bool CreateTaskList(string name)
        {
            TaskList taskList = new TaskList();
            taskList.Name = name;
            if (listOfTaskLists.TryAdd(name, taskList))
            {
                //DataHandler.AddtoQueue(CreateTaskList, taskList);
                return true;
            }                
            return false;
        }

        public static List<string> GetTaskListNames()
        {
            return listOfTaskLists.Keys.ToList();
        }

        public static bool EditTaskList(string oldName, string newName)
        {
            TaskList taskList = new TaskList();
            taskList.Name = newName;
            if (listOfTaskLists.TryAdd(newName, taskList))
            {
                listOfTaskLists.Remove(oldName);
                //DataHandler.AddtoQueue(EditTaskList, taskList);
                return true;
            }

            return false;
        }

        public static bool EditTaskList(this TaskList taskList, string newName)
        {
            return EditTaskList(taskList.Name, newName);
        }
    }
}
