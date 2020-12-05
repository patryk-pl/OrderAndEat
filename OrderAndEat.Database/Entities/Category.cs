using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderAndEat.Database
{
    public class Category : BaseEntity
    {
        [NotMapped]
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
