using OrderAndEat.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core
{
    public interface ISubCategoryManager
    {
        IEnumerable<SubCategoryDto> GetAllSubCategories();
        SubCategoryDto GetSubCategory(int? id);
        bool SubCategoryExist(SubCategoryDto subCategory);
        IEnumerable<SubCategoryDto> GetSubCategories(int id);
        bool AddNewSubCategory(SubCategoryDto subCategoryDto);
        bool EditSubCategory(SubCategoryDto subCategoryDto);
    }
}
