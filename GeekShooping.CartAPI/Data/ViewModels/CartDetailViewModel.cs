using System.ComponentModel.DataAnnotations.Schema;

using GeekShooping.CartAPI.Model.Base;

namespace GeekShooping.CartAPI.Data.ViewModels;

[Table("cart_detail")]
public class CartDetailViewModel
{
    public Guid Id { get; set; }
    
    public Guid CartHeaderId { get; set; }
    
    public CartHeaderViewModel CartHeader { get; set; }
    
    public Guid ProductId { get; set; }
    
    public ProductViewModel Product { get; set; }
    
    public int Count { get; set; }
    
}
