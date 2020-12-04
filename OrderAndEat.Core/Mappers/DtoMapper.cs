using AutoMapper;
using OrderAndEat.Database;
using System.Collections.Generic;

namespace OrderAndEat.Core
{
    public class DtoMapper
    {
        private IMapper _mapper;

        public DtoMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Category, CategoryDto>()
                      .ReverseMap();
                config.CreateMap<SubCategory, SubCategoryDto>()
                      .ReverseMap();
            }).CreateMapper();
        }

        #region Category Maps
        public CategoryDto Map(Category category) 
            => _mapper.Map<CategoryDto>(category);

        public IEnumerable<CategoryDto> Map(IEnumerable<Category> categories)
            => _mapper.Map<IEnumerable<CategoryDto>>(categories);

        public Category Map(CategoryDto category)
            => _mapper.Map<Category>(category);

        public IEnumerable<Category> Map(IEnumerable<CategoryDto> categories)
            => _mapper.Map<IEnumerable<Category>>(categories);
        #endregion

        #region SubCategory Maps
        public SubCategoryDto Map(SubCategory subCategory)
            => _mapper.Map<SubCategoryDto>(subCategory);

        public IEnumerable<SubCategoryDto> Map(IEnumerable<SubCategory> subCategories)
            => _mapper.Map<IEnumerable<SubCategoryDto>>(subCategories);

        public SubCategory Map(SubCategoryDto subCategory)
            => _mapper.Map<SubCategory>(subCategory);

        public IEnumerable<SubCategory> Map(IEnumerable<SubCategoryDto> subCategories)
            => _mapper.Map<IEnumerable<SubCategory>>(subCategories);
        #endregion
    }
}
