﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderAndEat.Core
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<SubCategoryDto> SubCategories { get; set; }
    }
}
