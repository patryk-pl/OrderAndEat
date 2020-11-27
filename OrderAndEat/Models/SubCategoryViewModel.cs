using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAndEat
{
    public class SubCategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "SubCategory Name")]
        public string Name { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
