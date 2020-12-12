﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAndEat
{
    public class CouponViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [Required]
        public string CouponType { get; set; }
        public enum ECouponType { Percent = 0, Dollar = 1 }

        [Required]
        public double Discount { get; set; }
        [Required]
        public double MinimumAmount { get; set; }

        public byte[] Picture { get; set; }

        public bool isActive { get; set; }
    }
}
