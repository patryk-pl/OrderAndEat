using OrderAndEat.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core
{

    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly DtoMapper _DtoMapper;

        public CategoryManager(ICategoryRepository categoryRepository,
                               DtoMapper dtoMapper)
        {
            _categoryRepository = categoryRepository;
            _DtoMapper = dtoMapper;
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categoryEntities = _categoryRepository.GetAllCategories();

            return _DtoMapper.Map(categoryEntities);
        }

        public CategoryDto GetCategory(int? id)
        {
            var categoryEntity = _categoryRepository.GetItemFromTable(id);

            return _DtoMapper.Map(categoryEntity);
        }

        public bool AddNewCategory(CategoryDto categoryDto)
        {
            var entity = _DtoMapper.Map(categoryDto);

            return _categoryRepository.AddNew(entity);
            
        }

        public bool EditCategory(CategoryDto categoryDto)
        {
            var entity = _DtoMapper.Map(categoryDto);
            return _categoryRepository.Edit(entity);
        }

    }

}
