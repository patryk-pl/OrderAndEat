using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderAndEat.Database
{
    public class Coupon : BaseEntity
    {
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
