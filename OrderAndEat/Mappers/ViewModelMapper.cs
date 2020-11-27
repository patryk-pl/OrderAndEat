using AutoMapper;
using OrderAndEat.Core;
using OrderAndEat.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat
{
    public class ViewModelMapper
    {
        private IMapper _mapper;

        public ViewModelMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<CategoryDto, CategoryViewModel>()
                      .ReverseMap();
                config.CreateMap<SubCategoryDto, SubCategoryViewModel>()
                      .ReverseMap();
            }).CreateMapper();
        }

        #region Category Maps
        public CategoryViewModel Map(CategoryDto category) 
            => _mapper.Map<CategoryViewModel>(category);

        public IEnumerable<CategoryViewModel> Map(IEnumerable<CategoryDto> categories)
            => _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

        public CategoryDto Map(CategoryViewModel category)
            => _mapper.Map<CategoryDto>(category);

        public IEnumerable<CategoryDto> Map(IEnumerable<CategoryViewModel> categories)
            => _mapper.Map<IEnumerable<CategoryDto>>(categories);
        #endregion

        #region SubCategory Maps
        public SubCategoryViewModel Map(SubCategoryDto subCategory)
            => _mapper.Map<SubCategoryViewModel>(subCategory);

        public IEnumerable<SubCategoryViewModel> Map(IEnumerable<SubCategoryDto> subCategories)
            => _mapper.Map<IEnumerable<SubCategoryViewModel>>(subCategories);

        public SubCategoryDto Map(SubCategoryViewModel subCategory)
            => _mapper.Map<SubCategoryDto>(subCategory);
        public IEnumerable<SubCategoryDto> Map(IEnumerable<SubCategoryViewModel> subCategories)
            => _mapper.Map<IEnumerable<SubCategoryDto>>(subCategories);
        #endregion
    }
}
