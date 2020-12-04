using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAndEat
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
