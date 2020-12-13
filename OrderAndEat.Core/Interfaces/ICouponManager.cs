using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core
{
    public interface ICouponManager
    {
        IEnumerable<CouponDto> GetAllCoupons();
        bool AddNewCoupon(CouponDto couponDto);
    }
}
