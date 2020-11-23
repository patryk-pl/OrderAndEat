using AutoMapper;
using OrderAndEat.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core.Mappers
{
    public class CategoriesMapper
    {
        private IMapper _mapper;

        public CategoriesMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Category, CategoryDto>()
                      .ReverseMap();
            }).CreateMapper();
        }

        public CategoryDto Map(Category category) 
            => _mapper.Map<CategoryDto>(category);

        public IEnumerable<CategoryDto> Map(IEnumerable<Category> categories)
            => _mapper.Map<IEnumerable<CategoryDto>>(categories);

        public Category Map(CategoryDto category)
            => _mapper.Map<CategoryDto>(category);

        public IEnumerable<Category> Map(IEnumerable<CategoryDto> categories)
            => _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }
}
