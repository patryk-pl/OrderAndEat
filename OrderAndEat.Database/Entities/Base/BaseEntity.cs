using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderAndEat.Database
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
