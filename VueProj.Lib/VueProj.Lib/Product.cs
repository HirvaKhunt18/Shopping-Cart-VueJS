using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace VueProj.Lib
{
    public class Product
    {

        [Key]
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; } 
        [Required]
        public decimal Price { get; set; }
    }
}
