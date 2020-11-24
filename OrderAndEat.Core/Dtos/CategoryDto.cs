using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core
{
    public class CategoryDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
