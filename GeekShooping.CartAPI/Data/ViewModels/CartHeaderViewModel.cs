namespace GeekShooping.CartAPI.Data.ViewModels;


public class CartHeaderViewModel
{
    public Guid Id { get; set; }
    
    public string UserId { get; set; }
    
    public string? CouponCode { get; set; }
}
