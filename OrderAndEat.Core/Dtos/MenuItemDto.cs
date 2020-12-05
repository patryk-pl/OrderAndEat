using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderAndEat.Core
{
    public class MenuItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<SubCategoryDto> SubCategories { get; set; }
        public string Description { get; set; }
        public string Spicyness { get; set; }
        public enum ESpicy { NA = 0, NotSpicy = 1, Spicy = 2, VerySpicy = 3 }
        public string Image { get; set; }

        public int CategoryId { get; set; }
        public virtual CategoryDto Category { get; set; }

        public int SubCategoryId { get; set; }
        public virtual SubCategoryDto SubCategory { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Price should be grater thab ${1}")]
        public double Price { get; set; }
    }
}
