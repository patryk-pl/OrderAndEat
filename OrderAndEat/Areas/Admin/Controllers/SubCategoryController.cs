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
        //private readonly ISubCategoryManager _subCategoryManager;
        private readonly ViewModelMapper _viewModelMapper;

        public SubCategoryController(/*ISubCategoryManager subCategoryManager,*/ ViewModelMapper viewModelMapper)
        {
            //_subCategoryManager = subCategoryManager;
            _viewModelMapper = viewModelMapper;
        }

        //GET - Index
        public IActionResult Index()
        {
            return View();
        }
    }
}
