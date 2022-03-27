namespace GeekShooping.Web.Models;

public class CartDetailViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Guid CartHeaderId { get; set; } = Guid.NewGuid();
    
    public CartHeaderViewModel CartHeader { get; set; }
    
    public Guid ProductId { get; set; }
    
    public ProductViewModel Product { get; set; }
    
    public int Count { get; set; }
    
}
