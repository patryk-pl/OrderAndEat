using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderAndEat.Core;

namespace OrderAndEat
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryManager _subCategoryManager;
        private readonly ICategoryManager _categoryManager;
        private readonly ViewModelMapper _viewModelMapper;

        [TempData]
        public string StatusMessage { get; set; }

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
            var subCategoryDto = _viewModelMapper.Map(vMmodel.SubCategory);
            var categoriesDtos = _categoryManager.GetAllCategories();
            var subCategoriesDto = _subCategoryManager.GetAllSubCategories();

            if (ModelState.IsValid)
            {
                var doesSubCategoryExists = _subCategoryManager.SubCategoryExist(subCategoryDto);

                if (doesSubCategoryExists)
                {
                    StatusMessage = "Error : Sub Category exists under " + categoriesDtos.Where(x=>x.Id == subCategoryDto.CategoryId).FirstOrDefault().Name + "category. Please use another name";
                }
                else
                {
                    _subCategoryManager.AddNewSubCategory(subCategoryDto);
                    return RedirectToAction(nameof(Index));
                }
            }
            SubCategoryAndCategoryViewModel modelVm = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = _viewModelMapper.Map(categoriesDtos),
                SubCategory = vMmodel.SubCategory,
                SubCategoryList = _viewModelMapper.Map(subCategoriesDto),
                StatusMessage = StatusMessage


            };
            return View(modelVm);
        }

        [ActionName("GetSubCategories")]
        public IActionResult GetSubCategories(int id)
        {
            var subCategoriesDto = _subCategoryManager.GetSubCategories(id);
            var subCategoriesVm = _viewModelMapper.Map(subCategoriesDto);

            return Json(new SelectList(subCategoriesVm, "Id", "Name"));
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subCategoryDto = _subCategoryManager.GetSubCategory(id);
            var subCategoriesDto = _subCategoryManager.GetAllSubCategories();
            var categoriesDto = _categoryManager.GetAllCategories();

            var viewModel = new SubCategoryAndCategoryViewModel
            {
                CategoryList = _viewModelMapper.Map(categoriesDto),
                SubCategory = _viewModelMapper.Map(subCategoryDto),
                SubCategoryList = _viewModelMapper.Map(subCategoriesDto).OrderBy(p => p.Name).ToList()
            };

            return View(viewModel);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, SubCategoryAndCategoryViewModel vMmodel)
        {
            var subCategoryDto = _viewModelMapper.Map(vMmodel.SubCategory);
            var categoriesDtos = _categoryManager.GetAllCategories();
            var subCategoriesDto = _subCategoryManager.GetAllSubCategories();

            if (ModelState.IsValid)
            {
                var doesSubCategoryExists = _subCategoryManager.SubCategoryExist(subCategoryDto);

                if (doesSubCategoryExists)
                {
                    StatusMessage = "Error : Sub Category exists under " + categoriesDtos.Where(x => x.Id == subCategoryDto.CategoryId).FirstOrDefault().Name + "category. Please use another name";
                }
                else
                {
                    _subCategoryManager.EditSubCategory(subCategoryDto);
                    return RedirectToAction(nameof(Index));
                }
            }
            SubCategoryAndCategoryViewModel modelVm = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = _viewModelMapper.Map(categoriesDtos),
                SubCategory = vMmodel.SubCategory,
                SubCategoryList = _viewModelMapper.Map(subCategoriesDto),
                StatusMessage = StatusMessage


            };
            return View(modelVm);
        }
    }
}
