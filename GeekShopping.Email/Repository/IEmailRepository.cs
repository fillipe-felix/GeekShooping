namespace GeekShopping.Email.Repository
{
    public interface IEmailRepository
    {
        Task UpdateOrderPaymentStatus(long orderHeaderId, bool status);
    }
}
