using GeekShopping.Email.Model.Context;

using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<EmailApiContext> _context;

        public EmailRepository(DbContextOptions<EmailApiContext> context)
        {
            _context = context;
        }

        public async Task UpdateOrderPaymentStatus(long orderHeaderId, bool status)
        {
            await using var _db = new EmailApiContext(_context);
            var header = await _db.Emails.FirstOrDefaultAsync(o => o.Id == orderHeaderId);
            
            if (header != null)
            {
                
                await _db.SaveChangesAsync();
            }
        }
    }
}
