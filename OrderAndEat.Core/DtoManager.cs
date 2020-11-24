using OrderAndEat.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core
{

    public class DtoManager : IDtoManager
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly DtoMapper _DtoMapper;

        public DtoManager(ICategoryRepository categoryRepository,
                               DtoMapper categoriesMapper)
        {
            _categoryRepository = categoryRepository;
            _DtoMapper = categoriesMapper;
        }

        public IEnumerable<CategoryDto> GetAllCategory()
        {
            var categoryEntities = _categoryRepository.GetAllCategories();

            return _DtoMapper.Map(categoryEntities);
        }

    }

}
