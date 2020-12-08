using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // maybe not necessary
        public int CategoryId { get; set; }
        public virtual CategoryDto Category { get; set; }
    }
}
