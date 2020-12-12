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
                config.CreateMap<MenuItemDto, MenuItemViewModel>()
                      .ReverseMap();
                config.CreateMap<CouponDto, CouponViewModel>()
                     .ReverseMap();
            }).CreateMapper();
        }

        #region Category Maps
        public CategoryViewModel Map(CategoryDto category) 
            => _mapper.Map<CategoryViewModel>(category);

        public IEnumerable<CategoryViewModel> Map(IEnumerable<CategoryDto> categories)
            => _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

        public CategoryDto Map(CategoryViewModel categoryVm)
            => _mapper.Map<CategoryDto>(categoryVm);

        public IEnumerable<CategoryDto> Map(IEnumerable<CategoryViewModel> categoriesVm)
            => _mapper.Map<IEnumerable<CategoryDto>>(categoriesVm);
        #endregion

        #region SubCategory Maps
        public SubCategoryViewModel Map(SubCategoryDto subCategoryDto)
            => _mapper.Map<SubCategoryViewModel>(subCategoryDto);

        public IEnumerable<SubCategoryViewModel> Map(IEnumerable<SubCategoryDto> subCategoriesDto)
            => _mapper.Map<IEnumerable<SubCategoryViewModel>>(subCategoriesDto);

        public SubCategoryDto Map(SubCategoryViewModel subCategoryVm)
            => _mapper.Map<SubCategoryDto>(subCategoryVm);
        public IEnumerable<SubCategoryDto> Map(IEnumerable<SubCategoryViewModel> subCategoriesVm)
            => _mapper.Map<IEnumerable<SubCategoryDto>>(subCategoriesVm);
        #endregion

        #region MenuItem Maps
        public MenuItemViewModel Map(MenuItemDto menuItemDto)
            => _mapper.Map<MenuItemViewModel>(menuItemDto);

        public IEnumerable<MenuItemViewModel> Map(IEnumerable<MenuItemDto> menuItemsDto)
            => _mapper.Map<IEnumerable<MenuItemViewModel>>(menuItemsDto);

        public MenuItemDto Map(MenuItemViewModel menuItemVm)
            => _mapper.Map<MenuItemDto>(menuItemVm);

        public IEnumerable<MenuItemDto> Map(IEnumerable<MenuItemViewModel> menuItemsVm)
            => _mapper.Map<IEnumerable<MenuItemDto>>(menuItemsVm);

        #endregion

        #region Coupon Maps
        public CouponViewModel Map(CouponDto couponDto)
            => _mapper.Map<CouponViewModel>(couponDto);
        public CouponDto Map(CouponViewModel coupon)
            => _mapper.Map<CouponDto>(coupon);
        #endregion
    }
}
