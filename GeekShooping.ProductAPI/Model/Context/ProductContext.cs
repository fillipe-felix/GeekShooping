using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Model.Context;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
