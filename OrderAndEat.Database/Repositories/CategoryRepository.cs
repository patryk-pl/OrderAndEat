using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderAndEat.Database
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        protected override DbSet<Category> DbSet => _dbContext.Categories;

        public CategoryRepository(OrderAndEatDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Category> GetAllCategories()
        {
            return DbSet;
                //.Select(x => x);
        }

        public Category GetItemFromTable(int? id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        //public bool AddNew(Category category)
        //{
        //    DbSet.Add(category);

        //    return SaveChanges();
        //}

        //public bool Edit(Category category)
        //{
        //    var foundEntity = DbSet.FirstOrDefault(x => x.Id == category.Id);
        //    if (foundEntity != null)
        //    {
        //        foundEntity.Name = category.Name;

        //        return SaveChanges();
        //    }
        //    return false;
        //}

        //public bool Delete(Category category)
        //{
        //    var foundEntity = DbSet.FirstOrDefault(x => x.Id == category.Id);
        //    if (foundEntity != null)
        //    {
        //        DbSet.Remove(foundEntity);

        //        return SaveChanges();
        //    }

        //    return false;
        //}
    }
}
