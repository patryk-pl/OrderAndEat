using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderAndEat.Core;

namespace OrderAndEat
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryManager _subCategoryManager;
        private readonly ICategoryManager _categoryManager;
        private readonly ViewModelMapper _viewModelMapper;

        public SubCategoryController(ISubCategoryManager subCategoryManager, ICategoryManager categoryManager, ViewModelMapper viewModelMapper)
        {
            _subCategoryManager = subCategoryManager;
            _categoryManager = categoryManager;
            _viewModelMapper = viewModelMapper;
        }

        //GET - Index
        public IActionResult Index()
        {
            var subCategoryDto = _subCategoryManager.GetAllSubCategories();

            var viewModel = _viewModelMapper.Map(subCategoryDto);
            return View(viewModel);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            var subCategoryDto = _subCategoryManager.GetAllSubCategories();
            var categoryDto = _categoryManager.GetAllCategories();

            var viewModel = new SubCategoryAndCategoryViewModel
            {
                CategoryList = _viewModelMapper.Map(categoryDto),
                SubCategory = new SubCategoryViewModel(),
                SubCategoryList = _viewModelMapper.Map(subCategoryDto).OrderBy(p => p.Name).ToList()
        };

            return View(viewModel);
        }
    }
}
