using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCKUNOHA_HAY.Data;
using MVCKUNOHA_HAY.Models;

namespace MVCKUNOHA_HAY.Controllers
{
    public class TasksController : Controller
    {
        private readonly MyAppContext _context;

        // Add Dependency Injection
        public TasksController(MyAppContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexTask()
        {
            var allTasks = await _context.Tasks.ToListAsync();

            var indexTasks = allTasks.Where(t => t.DateDeadline >= DateTime.Now).ToList(); // Exclude overdue
            var overdueTasks = allTasks.Where(t => t.DateDeadline < DateTime.Now).ToList(); // Only overdue

            ViewBag.OverdueTasks = overdueTasks;
            return View(indexTasks);
        }


        public IActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([Bind("Id, FirstName, LastName, TaskName, Description, Status, DateAssigned, DateDeadline, AssignedBy")] TaskList task)
        {
            if (ModelState.IsValid)
            {
                if (task.DateDeadline < DateTime.Now)
                {
                    task.Status = "Overdue";
                }
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction("IndexTask");
            }
            return View(task);
        }

        public async Task<IActionResult> EditTask(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(i => i.Id == id);
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> EditTask(int id, [Bind("Id, FirstName, LastName, TaskName, Description, Status, DateAssigned, DateDeadline, AssignedBy")] TaskList task)
        {
            if (ModelState.IsValid)
            {
                if (task.DateDeadline < DateTime.Now)
                {
                    task.Status = "Overdue";
                }
                _context.Update(task);
                await _context.SaveChangesAsync();
                return RedirectToAction("IndexTask");
            }
            return View(task);
        }

        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(i => i.Id == id);
            return View(task);
        }

        [HttpPost, ActionName("DeleteTask")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(i => i.Id == id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("IndexTask");
        }
    }
}
