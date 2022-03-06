using GeekShooping.ProductAPI.Data.ViewModels;

namespace GeekShooping.ProductAPI.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductViewModel>> FindAll();
    Task<ProductViewModel> FindById(string id);
    Task<ProductViewModel> Create(ProductViewModel viewModel);
    Task<ProductViewModel> Update(ProductViewModel viewModel);
    Task<bool> Delete(string id);
}
