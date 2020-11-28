using OrderAndEat.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core
{
    public class SubCategoryManager : ISubCategoryManager
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly DtoMapper _dtoMapper;

        public SubCategoryManager(ISubCategoryRepository subCategoryRepository, DtoMapper dtoMapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _dtoMapper = dtoMapper;
        }

        public IEnumerable<SubCategoryDto> GetAllSubCategories()
        {
            var subCategoryEntities = _subCategoryRepository.GetAllSubCategories();

            return _dtoMapper.Map(subCategoryEntities);
        }

        public bool AddNewSubCategory(SubCategoryDto subCategoryDto)
        {
            var entity = _dtoMapper.Map(subCategoryDto);

            return _subCategoryRepository.AddNew(entity);
        }
    }
}
