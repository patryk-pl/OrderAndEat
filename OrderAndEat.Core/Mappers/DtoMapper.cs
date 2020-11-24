﻿using AutoMapper;
using OrderAndEat.Database;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}