﻿using System;
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
        private readonly ICategoryManager _categoryManager;
        private readonly ViewModelMapper _viewModelMapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public MenuItemAndSubCListAndCListViewModel menuItemAndSubCListAndCListVm { get; set; }

        public MenuItemController(
            IMenuItemManager menuItemManager,
            ICategoryManager categoryManager,
            ViewModelMapper viewModelMapper, 
            IWebHostEnvironment webHostEnvironment
            )
        {
            _webHostEnvironment = webHostEnvironment;
            _viewModelMapper = viewModelMapper;
            _menuItemManager = menuItemManager;
            _categoryManager = categoryManager;
            menuItemAndSubCListAndCListVm = new MenuItemAndSubCListAndCListViewModel()
            {
                MenuItem = new MenuItemViewModel()
            };
        }
        public IActionResult Index()
        {
            var menuItemsDto = _menuItemManager.GetAllMenuItems();

            var viewModel = _viewModelMapper.Map(menuItemsDto);
            return View(viewModel);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            var categoriesList = _categoryManager.GetAllCategories();
            menuItemAndSubCListAndCListVm.CategoriesList = _viewModelMapper.Map(categoriesList);

            return View(menuItemAndSubCListAndCListVm);
        }
    }
}
