using OrderAndEat.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core
{

    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoriesMapper _categoriesMapper;

        public CategoryManager(ICategoryRepository categoryRepository,
                               CategoriesMapper categoriesMapper)
        {
            _categoryRepository = categoryRepository;
            _categoriesMapper = categoriesMapper;
        }

        public IEnumerable<CategoryDto> GetAllCategory()
        {
            var categoryEntities = _categoryRepository.GetAllCategories();

            return _categoriesMapper.Map(categoryEntities);
        }

    }

}
