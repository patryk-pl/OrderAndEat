using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database
{
    public interface ICouponRepository : IRepository<Coupon>
    {
        IEnumerable<Coupon> GetAllCoupons();
        Coupon GetCouponFromTable(int? id);
        bool Edit(Coupon coupon);
    }
}
