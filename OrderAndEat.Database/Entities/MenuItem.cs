﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderAndEat.Database
{
    public class MenuItem : BaseEntity
    {
        public string Description { get; set; }
        public string Spicyness { get; set; }
        public enum ESpicy { NA=0, NotSpicy=1, Spicy=2, VerySpicy=3 }
        public string Image { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Price should be grater thab ${1}")]
        public double Price { get; set; }
    }
}
