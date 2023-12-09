using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VueProj.Lib
{
    public class Orders
    {
        [Key]
        [Required]
        public int OrderId { get; set; }
        [Required]
        public string OrderName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public string Cart { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
