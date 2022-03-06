using GeekShooping.Web.Models;

namespace GeekShooping.Web.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> FindAllProducts();
    Task<ProductViewModel> FindProductById(Guid id);
    Task<ProductViewModel> CreateProduct(ProductViewModel viewModel);
    Task<ProductViewModel> UpdateProduct(Guid id, ProductViewModel viewModel);
    Task<bool> DeleteProductById(Guid id);
}
