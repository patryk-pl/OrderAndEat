using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database
{
    public class MenuItemRepository : BaseRepository<MenuItem>, IMenuItemRepository
    {
        protected override DbSet<MenuItem> DbSet => _dbContext.MenuItems;

        public MenuItemRepository(OrderAndEatDbContext dbContext) : base(dbContext)
        {

        }

    }
}
