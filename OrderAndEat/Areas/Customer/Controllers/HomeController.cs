using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderAndEat.Core;
using OrderAndEat.Models;

namespace OrderAndEat
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IMenuItemManager _menuItemManager;
        private readonly ICategoryManager _categoryManager;
        private readonly ICouponManager _couponManager;
        private readonly ViewModelMapper _viewModelMapper;
        [BindProperty]
        public IndexViewModel indexVm { get; set; }
        public HomeController(
            IMenuItemManager menuItemManager,
            ICategoryManager categoryManager,
            ICouponManager couponManager,
            ViewModelMapper viewModelMapper
            )
        {
            _menuItemManager = menuItemManager;
            _categoryManager = categoryManager;
            _couponManager = couponManager;
            _viewModelMapper = viewModelMapper;
            indexVm = new IndexViewModel();
        }

        public IActionResult Index()
        {
            var menuItemsDto = _menuItemManager.GetAllMenuItems();
            var categoriesDto = _categoryManager.GetAllCategories();
            var couponsDto = _couponManager.GetAllCoupons();

            indexVm.MenuItemsList = _viewModelMapper.Map(menuItemsDto);
            indexVm.CategoriesList = _viewModelMapper.Map(categoriesDto);
            indexVm.CouponsList = _viewModelMapper.Map(couponsDto);

            return View(indexVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
