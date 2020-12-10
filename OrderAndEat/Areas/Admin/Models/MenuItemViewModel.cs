using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAndEat
{
    public class MenuItemViewModel
    {
        public int Id { get; set; }

        //[Display(Name = "Menu Item Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Spicyness { get; set; }
        public enum ESpicy { NA = 0, NotSpicy = 1, Spicy = 2, VerySpicy = 3 }
        public string Image { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual CategoryViewModel Category { get; set; }

        [Display(Name = "SubCategory")]
        public int SubCategoryId { get; set; }
        public virtual SubCategoryViewModel SubCategory { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Price should be grater thab ${1}")]
        public double Price { get; set; }
    }
}
