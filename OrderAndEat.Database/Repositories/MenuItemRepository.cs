using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderAndEat.Database
{
    public class MenuItemRepository : BaseRepository<MenuItem>, IMenuItemRepository
    {
        protected override DbSet<MenuItem> DbSet => _dbContext.MenuItems;

        public MenuItemRepository(OrderAndEatDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<MenuItem> GetAllMenuItems()
        {
            return DbSet.Include(m => m.Category).Include(m => m.SubCategory).Select(x => x);
        }

    }
}
