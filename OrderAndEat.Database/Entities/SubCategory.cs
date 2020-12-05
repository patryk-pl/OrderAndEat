using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderAndEat.Database
{
    public class SubCategory : BaseEntity
    {
        /// <summary>
        /// One to Many.
        /// One Category may have many SubCategories
        /// </summary>
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
