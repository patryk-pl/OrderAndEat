using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderAndEat.Database
{
    public class CouponRepository : BaseRepository<Coupon>, ICouponRepository
    {
        protected override DbSet<Coupon> DbSet => _dbContext.Coupons;

        public CouponRepository(OrderAndEatDbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Coupon> GetAllCoupons()
        {
            return DbSet.Select(x=>x);
        }
        public Coupon GetCouponFromTable(int? id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }
        public bool Edit(Coupon coupon)
        {
            var foundEntity = DbSet.FirstOrDefault(x => x.Id == coupon.Id);
            if (foundEntity != null)
            {
                foundEntity.Name = coupon.Name;
                foundEntity.CouponType = coupon.CouponType;
                foundEntity.Discount = coupon.Discount;
                foundEntity.MinimumAmount = coupon.MinimumAmount;
                foundEntity.Picture = coupon.Picture;
                foundEntity.isActive = coupon.isActive;

                return SaveChanges();
            }
            return false;
        }

    }
}
