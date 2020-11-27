using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryDto Category { get; set; }
    }
}
