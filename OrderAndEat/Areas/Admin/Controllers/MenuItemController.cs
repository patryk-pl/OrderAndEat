using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OrderAndEat.Core;

namespace OrderAndEat.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuItemController : Controller
    {
        private readonly IMenuItemManager _menuItemManager;
        private readonly ViewModelMapper _viewModelMapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MenuItemController(IMenuItemManager menuItemManager, ViewModelMapper viewModelMapper, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _viewModelMapper = viewModelMapper;
            _menuItemManager = menuItemManager;
        }
        public IActionResult Index()
        {
            var menuItemsDto = _menuItemManager.GetAllMenuItems();

            var viewModel = _viewModelMapper.Map(menuItemsDto);
            return View(viewModel);
        }
    }
}
