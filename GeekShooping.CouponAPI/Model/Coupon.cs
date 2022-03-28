using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using GeekShooping.CouponAPI.Model.Base;

namespace GeekShooping.CouponAPI.Model;

[Table("coupon")]
public class Coupon : BaseEntity
{
    [Column("coupon_code")]
    [Required]
    [StringLength(30)]
    public string CouponCode { get; set; }

    [Column("discount_amount")]
    [Required]
    public decimal DiscountAmount { get; set; }
}
