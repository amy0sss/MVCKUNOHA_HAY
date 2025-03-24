using Microsoft.EntityFrameworkCore;
using MVCKUNOHA_HAY.Models;

namespace MVCKUNOHA_HAY.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext>options) : base(options){}

        // Set Database using the Item model class
        public DbSet<Item> Items { get; set; }
        public DbSet<TaskList> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
