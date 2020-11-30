using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderAndEat.Database
{
    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        protected override DbSet<SubCategory> DbSet => _dbContext.SubCategories;

        public SubCategoryRepository(OrderAndEatDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<SubCategory> GetAllSubCategories()
        {
            return DbSet.Include(x => x.Category).Select(x => x);
        }
        public bool SubCategoryExist(SubCategory subCategory)
        {
            if (!(DbSet.Include(s => s.Category).Where(s => s.Name == subCategory.Name && s.Category.Id == subCategory.Id).Count() > 0))
            {
                return false;
            }
            return true;

        }
    public bool AddNew(SubCategory subCategory)
    {
        DbSet.Add(subCategory);

        return SaveChanges();
    }
    public bool Delete(SubCategory subCategory)
    {
        var foundEntity = DbSet.FirstOrDefault(x => x.Id == subCategory.Id);
        if (foundEntity != null)
        {
            DbSet.Remove(foundEntity);

            return SaveChanges();
        }

        return false;

    }
}
}
