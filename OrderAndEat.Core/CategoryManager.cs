using OrderAndEat.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core
{

    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly DtoMapper _dtoMapper;

        public CategoryManager(ICategoryRepository categoryRepository,
                               DtoMapper dtoMapper)
        {
            _categoryRepository = categoryRepository;
            _dtoMapper = dtoMapper;
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categoryEntities = _categoryRepository.GetAllCategories();

            return _dtoMapper.Map(categoryEntities);
        }

        public CategoryDto GetCategory(int? id)
        {
            var categoryEntity = _categoryRepository.GetItemFromTable(id);

            return _dtoMapper.Map(categoryEntity);
        }

        public bool AddNewCategory(CategoryDto categoryDto)
        {
            var entity = _dtoMapper.Map(categoryDto);

            return _categoryRepository.AddNew(entity);
            
        }

        public bool EditCategory(CategoryDto categoryDto)
        {
            var entity = _dtoMapper.Map(categoryDto);
            return _categoryRepository.Edit(entity);
        }

        public bool DeleteCategory(CategoryDto categoryDto)
        {
            var entity = _dtoMapper.Map(categoryDto);
            return _categoryRepository.Delete(entity);
        }

    }

}
