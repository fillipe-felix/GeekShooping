using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Email.Model.Context
{
    public class EmailApiContext : DbContext
    {
        public EmailApiContext(DbContextOptions<EmailApiContext> options) : base(options) {}
        
        public DbSet<EmailLog> Emails { get; set; }
    }
}
