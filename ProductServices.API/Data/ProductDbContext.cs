using ProductServices.API.Model;
using Microsoft.EntityFrameworkCore;

namespace ProductServices.API.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
    }
}
