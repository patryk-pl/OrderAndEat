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

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubCategoryAndCategoryViewModel vMmodel)
        {
            

            if (ModelState.IsValid)
            {
                var subCategoryDto = _viewModelMapper.Map(vMmodel.SubCategory);
                var doesSubCategoryExists = _subCategoryManager.SubCategoryExist(subCategoryDto);

                if (doesSubCategoryExists)
                {
                    //Error
                }
                else
                {
                    _subCategoryManager.AddNewSubCategory(subCategoryDto);
                    return RedirectToAction(nameof(Index));
                }
            }
            var categoriesDtos = _categoryManager.GetAllCategories();
            var subCategoryDto = _subCategoryManager.GetAllSubCategories();
            SubCategoryAndCategoryViewModel modelVm = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = _viewModelMapper.Map(categoriesDtos),
                SubCategory = modelVm.SubCategory,
                SubCategoryList = 


            }
            return View(vMmodel);
        }
    }
}
