using Microsoft.EntityFrameworkCore;

namespace GeekShooping.CouponAPI.Model.Context;

public class CouponApiContext : DbContext
{
    public CouponApiContext(DbContextOptions<CouponApiContext> options) : base(options)
    {
    }

    public DbSet<Coupon> Coupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Coupon>().HasData(new Coupon
        {
            Id = Guid.NewGuid(),
            CouponCode = "ERUDIO_2022_10",
            DiscountAmount = 10
        });
        
        modelBuilder.Entity<Coupon>().HasData(new Coupon
        {
            Id = Guid.NewGuid(),
            CouponCode = "ERUDIO_2022_15",
            DiscountAmount = 15
        });
    }
}
