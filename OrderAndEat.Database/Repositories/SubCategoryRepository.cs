using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database {
    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        protected override DbSet<SubCategory> DbSet => _dbContext.SubCategories;

        public SubCategoryRepository(OrderAndEatDbContext dbContext) : base(dbContext)
        {

        }
    }
}
