using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAndEat
{
    public class MenuItemAndSubCListAndCListViewModel
    {
        public MenuItemViewModel MenuItem { get; set; }
        public IEnumerable<CategoryViewModel> CategoriesList { get; set; }
        public IEnumerable<SubCategoryViewModel> SubCategoriesList { get; set; }
    }
}
