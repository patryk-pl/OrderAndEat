using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAllCategories();
        bool AddNew(Category category);
        bool Delete(Category category);

    }
}
