using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        IEnumerable<SubCategory> GetAllSubCategories();
        SubCategory GetItemFromTable(int? id);
        bool SubCategoryExist(SubCategory subCategory);
        //bool AddNew(SubCategory subCategory);
        //bool Edit(SubCategory subCategory);
        //bool Delete(SubCategory subCategory);
    }
}
