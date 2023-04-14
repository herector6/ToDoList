using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.DataAccess.Context;
using ToDoList.DataAccess.Models;

namespace ToDoList.Controllers
{
    public class TaskDetailsController : Controller
    {
        private readonly TaskDetailsDbContext _context;

        public TaskDetailsController(TaskDetailsDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            TaskDetailsViewModel model = new TaskDetailsViewModel(_context);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int taskId, string taskName, string description, DateTime insertedDate, int expectedTime, string dayOfWeek)
        {
            TaskDetailsViewModel model = new TaskDetailsViewModel(_context);

            TaskDetailsModel taskDetails = new(taskId, taskName, description, insertedDate, expectedTime, dayOfWeek);

            model.SaveTask(taskDetails);
            model.IsActionSuccess= true;
            model.ActionMessage = "The Task has been saved successfully!";

            return View(model);
        }
        public IActionResult Update(int id)
        {
            TaskDetailsViewModel model = new TaskDetailsViewModel(_context, id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            TaskDetailsViewModel model = new TaskDetailsViewModel(_context);

            if (id > 0)
            {
                model.RemoveTask(id);
            }
            model.IsActionSuccess = true;
            model.ActionMessage = "Task has been removed succesfully.";
            return View("Index", model);
        }
    }
}
