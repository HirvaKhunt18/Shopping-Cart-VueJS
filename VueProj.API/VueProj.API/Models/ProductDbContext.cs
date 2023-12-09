using Microsoft.EntityFrameworkCore;
using VueProj.Lib;

namespace VueProj.API.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Orders> Order { get; set; }
        public DbSet<Pages> Pages { get; set; }

    }
}
