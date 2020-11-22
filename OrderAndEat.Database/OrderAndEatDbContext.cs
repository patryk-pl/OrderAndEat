using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database
{
    public class OrderAndEatDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public OrderAndEatDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
