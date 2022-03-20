namespace GeekShooping.CartAPI.Data.ViewModels;

public class ProductViewModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public string Description { get; set; }
    
    public string CategoryName { get; set; }
    
    public string ImageURL { get; set; }
}
