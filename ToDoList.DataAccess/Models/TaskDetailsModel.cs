using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DataAccess.Models
{
    public class TaskDetailsModel
    {
        
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime InsertedDate { get; set; }

        public int ExpectedTime { get; set; }
        public string DayOfWeek { get; set; }

        public TaskDetailsModel(int taskID, string taskName, string description, DateTime insertedDate, int expectedTime, string dayOfWeek)
        {
            TaskID = taskID;
            TaskName = taskName;
            Description = description;
            InsertedDate = insertedDate;
            ExpectedTime = expectedTime;
            DayOfWeek = dayOfWeek;
        }
        public TaskDetailsModel()
        {
            
        }

    }
}
