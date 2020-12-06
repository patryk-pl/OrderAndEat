using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePOST()
        {
            var menuItemVm = menuItemAndSubCListAndCListVm.MenuItem;

            menuItemVm.SubCategoryId = Convert.ToInt32(Request.Form["SubCategoryId"].ToString());

            if (!ModelState.IsValid)
            {
                return View(menuItemAndSubCListAndCListVm);
            }

            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var uniqueNameOfString = Math.Round((DateTime.Now - DateTime.MinValue).TotalMilliseconds).ToString();
            if (files.Count > 0)
            {
                //files has been uploaded
                var uploads = Path.Combine(webRootPath, "images");
                var extension = Path.GetExtension(files[0].FileName);

                using (var filesStream = new FileStream(Path.Combine(uploads, uniqueNameOfString + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                menuItemVm.Image = @"\images\" + uniqueNameOfString + extension;
            }
            else
            {
                // nofile was uploaded, so use default
                var uploads = Path.Combine(webRootPath,@"images\" + SD.DefaultFoodImage);
                System.IO.File.Copy(uploads, webRootPath + @"\images\" + uniqueNameOfString + ".png");
                menuItemVm.Image = @"\images\" + uniqueNameOfString + ".png";
            }

            var menuItemDto = _viewModelMapper.Map(menuItemVm);
            _menuItemManager.AddNewMenuItem(menuItemDto);
            

            return RedirectToAction(nameof(Index));


        }
    }
}
