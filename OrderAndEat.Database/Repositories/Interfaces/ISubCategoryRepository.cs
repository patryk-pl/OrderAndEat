using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        IEnumerable<SubCategory> GetAllSubCategories();
        bool AddNew(SubCategory subCategory);
        bool Delete(SubCategory subCategory);
    }
}
