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
        public MenuItem GetItemFromTable(int? id)
        {
            return DbSet.Include(x => x.Category).Include(x => x.SubCategory).FirstOrDefault(x => x.Id == id);
        }

        public bool Edit(MenuItem menuItem)
        {
            var foundEntity = DbSet.FirstOrDefault(x => x.Id == menuItem.Id);
            if (foundEntity != null)
            {
                foundEntity.Name = menuItem.Name;
                foundEntity.Description = menuItem.Description;
                foundEntity.Spicyness = menuItem.Spicyness;
                foundEntity.Image = menuItem.Image;
                foundEntity.CategoryId = menuItem.CategoryId;
                foundEntity.SubCategoryId = menuItem.SubCategoryId;
                foundEntity.Price = foundEntity.Price;

                return SaveChanges();
            }
            return false;
        }

    }
}
