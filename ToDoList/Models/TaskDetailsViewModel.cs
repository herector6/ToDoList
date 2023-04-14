using ToDoList.DataAccess.Context;
using ToDoList.DataAccess.Repositories;
using System;
using ToDoList.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;


namespace ToDoList.Models
{
   public class TaskDetailsViewModel
    {
        private TaskDetailsRepositories _repo;

        public List<TaskDetailsModel> TaskDetailsList { get; set; }
        public TaskDetailsModel CurrentTaskDetail { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }

        public TaskDetailsViewModel(TaskDetailsDbContext context)
        {
            _repo = new TaskDetailsRepositories(context);
            TaskDetailsList = GetAllTaskDetails();
            CurrentTaskDetail = TaskDetailsList.FirstOrDefault();
        }
        public TaskDetailsViewModel(TaskDetailsDbContext context, int taskId)
        {
            _repo = new TaskDetailsRepositories(context);
            TaskDetailsList = GetAllTaskDetails();

            if (taskId > 0)
            {
                CurrentTaskDetail = GetTaskDetails(taskId);
            }
            else
            {
                CurrentTaskDetail = new TaskDetailsModel();
            }
        }
        public void SaveTask(TaskDetailsModel task)
        {
            if (task.TaskID > 0)
            {
                _repo.Update(task);
            }
            else
            {
                task.TaskID = _repo.Create(task);
            }
            TaskDetailsList = GetAllTaskDetails();
            CurrentTaskDetail = GetTaskDetails(task.TaskID);
        }
        public void RemoveTask(int taskId)
        {
            _repo.Delete(taskId);
            TaskDetailsList = GetAllTaskDetails();
            CurrentTaskDetail = TaskDetailsList.FirstOrDefault();
        }
        public List<TaskDetailsModel> GetAllTaskDetails()
        {
            return _repo.GetAllTaskDetails();
        }
        public TaskDetailsModel GetTaskDetails(int taskId)
        {
            return _repo.GetTaskDetailsByID(taskId);
        }
    }
}