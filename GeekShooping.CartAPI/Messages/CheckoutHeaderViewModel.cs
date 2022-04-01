using GeekShooping.CartAPI.Data.ViewModels;

namespace GeekShooping.CartAPI.Messages;

public class CheckoutHeaderViewModel
{
    public Guid Id { get; set; }// = Guid.NewGuid();
    public string UserId { get; set; }
    public string? CouponCode { get; set; }
    public decimal PurchaseAmount { get; set; }
    
    public decimal DiscountAmount { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateTime { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string ExperyMothYear { get; set; }

    public int CartTotalItens { get; set; }
    public IEnumerable<CartDetailViewModel> CartDetails { get; set; }
}
