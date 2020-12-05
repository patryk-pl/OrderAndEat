using Microsoft.EntityFrameworkCore;
using OrderAndEat.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database
{
    public class OrderAndEatDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public OrderAndEatDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
