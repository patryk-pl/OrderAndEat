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
                config.CreateMap<MenuItem, MenuItemDto>()
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

        public SubCategory Map(SubCategoryDto subCategoryDto)
            => _mapper.Map<SubCategory>(subCategoryDto);

        public IEnumerable<SubCategory> Map(IEnumerable<SubCategoryDto> subCategoriesDto)
            => _mapper.Map<IEnumerable<SubCategory>>(subCategoriesDto);
        #endregion

        #region MenuItem Maps
        public MenuItemDto Map(MenuItem menuItem)
            => _mapper.Map<MenuItemDto>(menuItem);
        public IEnumerable<MenuItemDto> Map(IEnumerable<MenuItem> menuItems)
            => _mapper.Map<IEnumerable<MenuItemDto>>(menuItems);
        public MenuItem Map(MenuItemDto menuItemDto)
            => _mapper.Map<MenuItem>(menuItemDto);
        public IEnumerable<MenuItem> Map(IEnumerable<MenuItemDto> menuItemsDto)
            => _mapper.Map<IEnumerable<MenuItem>>(menuItemsDto);
        #endregion
    };
}
