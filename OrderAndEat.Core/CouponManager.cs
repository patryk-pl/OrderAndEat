using OrderAndEat.Database;
using System.Collections.Generic;

namespace OrderAndEat.Core
{

    public class CouponManager : ICouponManager
    {
        private readonly ICouponRepository _couponRepository;
        private readonly DtoMapper _dtoMapper;

        public CouponManager(ICouponRepository couponRepository,
                               DtoMapper dtoMapper)
        {
            _couponRepository = couponRepository;
            _dtoMapper = dtoMapper;
        }


        public IEnumerable<CouponDto> GetAllCoupons()
        {
            var couponEntities = _couponRepository.GetAllCoupons();

            return _dtoMapper.Map(couponEntities);
        }
        public bool AddNewCoupon(CouponDto couponDto)
        {
            var entity = _dtoMapper.Map(couponDto);

            return _couponRepository.AddNew(entity);
        }



    }

}
