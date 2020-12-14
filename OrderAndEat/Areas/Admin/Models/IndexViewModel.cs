using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAndEat
{
    public class IndexViewModel
    {
        public IEnumerable<MenuItemViewModel> MenuItemsList { get; set; }
        public IEnumerable<CategoryViewModel> CategoriesList { get; set; }
        public IEnumerable<CouponViewModel> CouponsList { get; set; }
    }
}
