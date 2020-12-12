﻿using OrderAndEat.Database;
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



    }

}