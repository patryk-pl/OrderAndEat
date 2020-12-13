using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderAndEat.Core;

namespace OrderAndEat
{
    [Area("Admin")]
    public class CouponController : Controller
    {
        private readonly ICouponManager _couponManager;
        private readonly ViewModelMapper _viewModelMapper;
        public CouponController(ICouponManager couponManager, ViewModelMapper viewModelMapper)
        {
            _couponManager = couponManager;
            _viewModelMapper = viewModelMapper;
        }
        public IActionResult Index()
        {
            var couponDto = _couponManager.GetAllCoupons();
            var viewModel = _viewModelMapper.Map(couponDto);
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
