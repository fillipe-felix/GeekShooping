using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShooping.Web.Models;

[Table("cart_detail")]
public class CartDetailViewModel
{
    public Guid Id { get; set; }
    
    public Guid CartHeaderId { get; set; }
    
    public CartHeaderViewModel CartHeaderViewModel { get; set; }
    
    public Guid ProductId { get; set; }
    
    public ProductViewModel ProductViewModel { get; set; }
    
    public int Count { get; set; }
    
}
