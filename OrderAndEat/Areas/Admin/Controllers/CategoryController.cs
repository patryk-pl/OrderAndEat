﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderAndEat.Core;

namespace OrderAndEat
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;
        private readonly ViewModelMapper _viewModelMapper;

        public CategoryController(ICategoryManager categoryManager, ViewModelMapper viewModelMapper)
        {
            _categoryManager = categoryManager;
            _viewModelMapper = viewModelMapper;
        }

        //GET - Index
        public IActionResult Index()
        {
            var categoryDto = _categoryManager.GetAllCategories();

            var viewModel = _viewModelMapper.Map(categoryDto);
            return View(viewModel.ToList());
        }
    }
}
