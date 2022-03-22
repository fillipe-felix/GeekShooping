using System.ComponentModel.DataAnnotations.Schema;

using GeekShooping.CartAPI.Model.Base;

namespace GeekShooping.CartAPI.Model;

[Table("cart_detail")]
public class CartDetail : BaseEntity
{
    public Guid CartHeaderId { get; set; }

    [ForeignKey("CartHeaderId")]
    public virtual CartHeader CartHeader { get; set; }
    
    public Guid ProductId { get; set; }
    
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
    
    [Column("count")]
    public int Count { get; set; }
    
}
