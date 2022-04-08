using Microsoft.EntityFrameworkCore;

namespace GeekShopping.OrderAPI.Model.Context
{
    public class OrderApiContext : DbContext
    {
        public OrderApiContext(DbContextOptions<OrderApiContext> options) : base(options) {}
        
        public DbSet<OrderDetail> Details { get; set; }
        public DbSet<OrderHeader> Headers { get; set; }
    }
}
