using SharedClasses;
using SharedClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SharedClasses.ClassWraps
{
    class TaskListWrap : IIdentifiable
    {
        private static List<string> _nonEmptyFields = new List<string>
        {
            "Name"
        };
        public static List<string> NonEmptyFields => _nonEmptyFields;

        private int _id;
        private Dictionary<string, string> _stringFields;        

        public int Id => _id;
        public Dictionary<string, string> StringFields { get => _stringFields; set=> _stringFields = value; }

        public TaskListWrap()
        {
            _stringFields = new Dictionary<string, string>
            {
                ["Name"] = ""
            };
        }

        public TaskListWrap(TaskList taskList)
        {
            _id = taskList.Id;
            _stringFields = new Dictionary<string, string>
            {
                ["Name"] = taskList.Name
            };
        }
    }
}
