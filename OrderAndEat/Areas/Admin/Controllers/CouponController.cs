using System;
using System.Collections.Generic;
using System.IO;
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

        //GET - Index
        public IActionResult Index()
        {
            var couponDto = _couponManager.GetAllCoupons();
            var viewModel = _viewModelMapper.Map(couponDto);
            return View(viewModel);
        }

        //GET - Create
        public IActionResult Create()
        {
            return View();
        }

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CouponViewModel couponVm)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    couponVm.Picture = p1;
                }
                var dto = _viewModelMapper.Map(couponVm);
                _couponManager.AddNewCoupon(dto);

                return RedirectToAction(nameof(Index));
            }
            return View(couponVm);
        }

        //GET - Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var couponDto = _couponManager.GetCoupon(id);
            var viewModel = _viewModelMapper.Map(couponDto);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CouponViewModel couponVm)
        {
            if (!ModelState.IsValid)
            {
                return View(couponVm);
            }
            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
            {
                byte[] p1 = null;
                using (var fs1 = files[0].OpenReadStream())
                {
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                }
                couponVm.Picture = p1;
            }
            var dto = _viewModelMapper.Map(couponVm);
            _couponManager.EditCoupon(dto);

            return RedirectToAction(nameof(Index));

        }
    }
}
