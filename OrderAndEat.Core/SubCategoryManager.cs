using OrderAndEat.Database;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public SubCategoryDto GetSubCategory(int? id)
        {
            var subCategoryEntity = _subCategoryRepository.GetItemFromTable(id);

            return _dtoMapper.Map(subCategoryEntity);
        }

        public bool SubCategoryExist(SubCategoryDto subCategoryDto)
        {
            var subCategoryEntity = _dtoMapper.Map(subCategoryDto);

            return _subCategoryRepository.SubCategoryExist(subCategoryEntity);
        }

        public IEnumerable<SubCategoryDto> GetSubCategories(int id)
        {
            var subCategories = new List<SubCategoryDto>();
            var subCategoriesEntity = _subCategoryRepository.GetAllSubCategories();

            subCategories = (from subCategoryEntity in _dtoMapper.Map(subCategoriesEntity)
                             where subCategoryEntity.CategoryId == id
                             select subCategoryEntity).ToList();

            
            return subCategories;
        }

        public bool AddNewSubCategory(SubCategoryDto subCategoryDto)
        {
            var entity = _dtoMapper.Map(subCategoryDto);

            return _subCategoryRepository.AddNew(entity);
        }

        public bool EditSubCategory(SubCategoryDto subCategoryDto)
        {
            var entity = _dtoMapper.Map(subCategoryDto);
            return _subCategoryRepository.Edit(entity);
        }

        public bool DeleteSubCategory(SubCategoryDto subCategoryDto)
        {
            var entity = _dtoMapper.Map(subCategoryDto);
            return _subCategoryRepository.Delete(entity);
        }
    }
}
