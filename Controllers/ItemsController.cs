using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCKUNOHA_HAY.Data;
using MVCKUNOHA_HAY.Models;

namespace MVCKUNOHA_HAY.Controllers
{
    public class ItemsController : Controller
    {
        private readonly MyAppContext _context;

        // Add Dependency Injection
        public ItemsController(MyAppContext context)
        {
            _context = context;
        }

        public IActionResult Overview()
        {
            //Creating the item object
            var item = new Item() { Name = "keyboard" };
            //Passing the item object to the view
            return View(item);
        }
        //IActionResult parameters passing and filter id direct to URL
        public IActionResult Edit(int id)
        {
            //get and displaying data passed by IActionResult parameters
            return Content("id = " +id);
        }

        public async Task<IActionResult> Index()
        {
            var item = await _context.Items.ToListAsync();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name, Price")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

    }

}
