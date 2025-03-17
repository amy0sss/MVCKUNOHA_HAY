using System.ComponentModel.DataAnnotations;

namespace MVCKUNOHA_HAY.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ? Name { get; set; }
        public double Price { get; set; }

        //// add attributes for the activity
        //public string Address { get; set; }
        //[RegularExpression("^[0-9a-zA-Z]+([0-9a-zA-Z]*[-._+])*[0-9a-zA-Z]+@[0-9a-zA-Z]+([-.][0-9a-zA-Z]+)*([0-9a-zA-Z]*[.])[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email")]
        //public string Email { get; set; }
        //public int Age { get; set; }
    }
}
