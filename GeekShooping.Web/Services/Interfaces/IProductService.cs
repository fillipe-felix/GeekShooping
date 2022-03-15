using GeekShooping.Web.Models;

namespace GeekShooping.Web.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> FindAllProducts(string token);
    Task<ProductViewModel> FindProductById(Guid id, string token);
    Task<ProductViewModel> CreateProduct(ProductViewModel viewModel, string token);
    Task<ProductViewModel> UpdateProduct(Guid id, ProductViewModel viewModel, string token);
    Task<bool> DeleteProductById(Guid id, string token);
}
