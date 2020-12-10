using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderAndEat.Database.Entities
{
    class Coupon : BaseEntity
    {
        [Required]
        public string CouponType { get; set; }
        public enum ECouponType { Percent = 0, Dollar = 1 }

        [Required]
        public double Discount { get; set; }
    }
}
