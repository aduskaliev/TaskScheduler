using System;
using System.Collections.Generic;

namespace DataClassses
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeExpired { get; set; }
        public int? ReminderID { get; set; }        
        public int? RecurringTaskID { get; set; }
        public bool Hidden { get; set; }
        public string Comment { get; set; }
        public int TaskListID { get; set; }
        public StatusType Status { get; set; }

        public List<int> tagIds;
        
        /*public Task(TaskList taskList, DateTime timeCreated)
        {
            TaskListID = taskList.Id;
            TimeCreated = timeCreated;
            Hidden = false;
            Status = StatusType.NotCompleted;
        }*/
    }
}
