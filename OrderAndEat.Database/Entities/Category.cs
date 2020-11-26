using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderAndEat.Database
{
    public class Category : BaseEntity
    {
        
        [Required]
        public string Name { get; set; }
    }
}
