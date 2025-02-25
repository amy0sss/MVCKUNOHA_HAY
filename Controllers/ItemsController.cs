using Microsoft.AspNetCore.Mvc;
using MVCKUNOHA_HAY.Models;

namespace MVCKUNOHA_HAY.Controllers
{
    public class ItemsController : Controller
    {
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
    }

}
