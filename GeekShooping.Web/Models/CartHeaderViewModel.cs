namespace GeekShooping.Web.Models;

public class CartHeaderViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string UserId { get; set; }
    
    public string? CouponCode { get; set; }
    
    public decimal PurchaseAmount { get; set; }
}
