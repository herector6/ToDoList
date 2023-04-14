using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Context;
using ToDoList.DataAccess.Models;

namespace ToDoList.DataAccess.Repositories
{
    public class TaskDetailsRepositories
    {
        private readonly TaskDetailsDbContext _dbContext;

        public TaskDetailsRepositories(TaskDetailsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(TaskDetailsModel taskDetails)
        {
            _dbContext.Add(taskDetails);
            _dbContext.SaveChanges();

            return taskDetails.TaskID;
        }
        public int Update(TaskDetailsModel newTaskDetails)
        {
            TaskDetailsModel existingTasks = _dbContext.TaskDetails.Find(newTaskDetails.TaskID);

            existingTasks.TaskName = newTaskDetails.TaskName;
            existingTasks.Description = newTaskDetails.Description;
            existingTasks.InsertedDate = newTaskDetails.InsertedDate;
            existingTasks.ExpectedTime= newTaskDetails.ExpectedTime;
            existingTasks.DayOfWeek = newTaskDetails.DayOfWeek;

            _dbContext.SaveChanges();

            return existingTasks.TaskID;
        }
        public bool Delete(int taskId)
        {
            TaskDetailsModel task = _dbContext.TaskDetails.Find(taskId);
            _dbContext.Remove(task);
            _dbContext.SaveChanges();

            return true;
        }
        public List<TaskDetailsModel> GetAllTaskDetails()
        {
            List<TaskDetailsModel> taskDetailsList = _dbContext.TaskDetails.ToList();

            return taskDetailsList;
        }
        public TaskDetailsModel GetTaskDetailsByID(int taskId)
        {
            TaskDetailsModel taskDetails = _dbContext.TaskDetails.Find(taskId);

            return taskDetails;
        }
    }
}
