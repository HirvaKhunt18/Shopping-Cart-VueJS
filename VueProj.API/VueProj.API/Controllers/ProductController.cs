using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using VueProj.API.Models;
using VueProj.Lib;

namespace VueProj.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;
        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        //api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = _context.Product
        .OrderBy(x => x.ProductId)
        .Include(x => x.Category)
        .Select(x => new Product
        {
            ProductId = x.ProductId,
            ProductName = x.ProductName,
            CategoryId = x.CategoryId,
            CategoryName = x.Category.CategoryName, 
            Description = x.Description,
            Image = x.Image,
            Price = x.Price
        });
            return await products.ToListAsync();
        }
        //api/Product/categoryName
        [HttpPost]
        public async Task<ActionResult<Product>> CreateUpdate([FromForm] Product product)
        {
            if (product.ImageFile != null)
            {
                string uniqueFileName = ProcessUploadedFile(product.ImageFile);
                product.Image = uniqueFileName;
            }
            else
            {
                product.Image = product.Image;
                product.ImageFile = null;
            }
            if (product.ProductId > 0)
            {
                _context.Product.Update(product);
                await _context.SaveChangesAsync();
            }
            else
            {   
                _context.Product.Add(product);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }


        //IMAGE INTO STRING
        private string ProcessUploadedFile(IFormFile image)
        {
            string uniqueFileName = null;
            if (image != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        //api/Product/categoryName
        [HttpGet("categories/{categoryName}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByCategory(string categoryName)
        {
            var category = await _context.Category.Where(p => p.CategoryName == categoryName).FirstOrDefaultAsync();

            return await _context.Product.OrderBy(x => x.CategoryId).Where(x => x.CategoryId == category.CategoryId).ToListAsync();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var product = await _context.Product.FindAsync(id);
          _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
