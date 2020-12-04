using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAndEat
{
    public class SubCategoryAndCategoryViewModel
    {
        public IEnumerable<CategoryViewModel> CategoryList { get; set; }
        public SubCategoryViewModel SubCategory { get; set; }
        public IEnumerable<SubCategoryViewModel> SubCategoryList { get; set; }
        public string StatusMessage { get; set; }
    }
}
