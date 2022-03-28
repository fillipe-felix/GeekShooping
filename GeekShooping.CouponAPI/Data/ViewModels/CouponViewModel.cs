namespace GeekShooping.CouponAPI.Data.ViewModels;

public class CouponViewModel
{
    public Guid Id { get; set; }
    
    public string CouponCode { get; set; }

    public decimal DiscountAmount { get; set; }
}
