using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database
{
    public class CouponRepository : BaseRepository<Coupon>, ICouponRepository
    {
        protected override DbSet<Coupon> DbSet => _dbContext.Coupons;

        public CouponRepository(OrderAndEatDbContext dbContext) : base(dbContext)
        {

        }

    }
}
