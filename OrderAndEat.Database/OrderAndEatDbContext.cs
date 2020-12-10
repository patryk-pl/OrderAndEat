using Microsoft.EntityFrameworkCore;

namespace OrderAndEat.Database
{
    public class OrderAndEatDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public OrderAndEatDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
