using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAllCategories();
        Category GetItemFromTable(int? id);
        bool Edit(Category category);

    }
}
