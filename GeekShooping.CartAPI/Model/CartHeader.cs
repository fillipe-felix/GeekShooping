using System.ComponentModel.DataAnnotations.Schema;

using GeekShooping.CartAPI.Model.Base;

namespace GeekShooping.CartAPI.Model;

[Table("cart_header")]
public class CartHeader : BaseEntity
{
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("coupon_code")]
    public string CouponCode { get; set; }
}
