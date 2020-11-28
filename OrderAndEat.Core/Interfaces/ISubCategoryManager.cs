using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core
{
    public interface ISubCategoryManager
    {
        IEnumerable<SubCategoryDto> GetAllSubCategories();
        bool AddNewSubCategory(SubCategoryDto subCategoryDto);
    }
}
