using OrderAndEat.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core
{
    public interface ISubCategoryManager
    {
        IEnumerable<SubCategoryDto> GetAllSubCategories();
        bool SubCategoryExist(SubCategoryDto subCategory);
        bool AddNewSubCategory(SubCategoryDto subCategoryDto);
    }
}
