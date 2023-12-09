using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VueProj.Lib
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
