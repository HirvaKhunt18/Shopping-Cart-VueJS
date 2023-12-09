using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VueProj.Lib
{
    public class Pages
    {
        [Key]
        [Required]
        public int PageId { get; set; }
        [Required]
        public string PageName { get; set; }
        [Required]
        public string Content { get; set; }
        public string Slug { get; set; }
    }
}
