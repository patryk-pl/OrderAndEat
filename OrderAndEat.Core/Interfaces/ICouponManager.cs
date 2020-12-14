using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core
{
    public interface ICouponManager
    {
        IEnumerable<CouponDto> GetAllCoupons();
        bool AddNewCoupon(CouponDto couponDto);
        CouponDto GetCoupon(int? id);
        bool EditCoupon(CouponDto couponDto);
        bool DeleteCoupon(CouponDto couponDto);
    }
}
