using System;
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
            var categoriesDto = _categoryManager.GetAllCategories();
            var viewModel = _viewModelMapper.Map(categoriesDto);

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
        public IActionResult Create(CategoryViewModel categoryVm)
        {
            if (ModelState.IsValid)
            {
                var dto = _viewModelMapper.Map(categoryVm);
                _categoryManager.AddNewCategory(dto);

                return RedirectToAction(nameof(Index));
            }
            return View(categoryVm);
        }

        //GET - Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryDto = _categoryManager.GetCategory(id);
            var viewModel = _viewModelMapper.Map(categoryDto);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        //POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryViewModel categoryVm)
        {
            if (ModelState.IsValid)
            {
                var dto = _viewModelMapper.Map(categoryVm);
                _categoryManager.EditCategory(dto);

                return RedirectToAction(nameof(Index));
            }

            return View(categoryVm);
        }

        //GET - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryDto = _categoryManager.GetCategory(id);
            var viewModel = _viewModelMapper.Map(categoryDto);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        //POST - Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _categoryManager.DeleteCategory(new CategoryDto { Id = (int)id });

            return RedirectToAction(nameof(Index));
        }

        //GET - Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryDto = _categoryManager.GetCategory(id);
            var viewModel = _viewModelMapper.Map(categoryDto);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);

        }
    }
}
