using System.ComponentModel.DataAnnotations;

namespace MVCKUNOHA_HAY.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ? Name { get; set; }
        public double Price { get; set; }
    }
}
