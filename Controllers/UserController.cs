using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCKUNOHA_HAY.Data;
using MVCKUNOHA_HAY.Models;

namespace MVCKUNOHA_HAY.Controllers
{
    public class UserController : Controller
    {
        private readonly MyAppContext _context;

        // Add Dependency Injection
        public UserController(MyAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexUser()
        {
            var allUsers = await _context.Users.ToListAsync();
            return View(allUsers);
        }


        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask
            ([Bind("UserId, FirstName, MiddleName, LastName, Address, Email, Age")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("IndexUser");
            }
            return View(user);
        }
    }
}
