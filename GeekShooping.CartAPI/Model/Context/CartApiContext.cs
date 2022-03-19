using Microsoft.EntityFrameworkCore;

namespace GeekShooping.CartAPI.Model.Context;

public class CartApiContext : DbContext
{
    public CartApiContext(DbContextOptions<CartApiContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
