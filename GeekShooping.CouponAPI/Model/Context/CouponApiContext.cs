using Microsoft.EntityFrameworkCore;

namespace GeekShooping.CouponAPI.Model.Context;

public class CouponApiContext : DbContext
{
    public CouponApiContext(DbContextOptions<CouponApiContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
