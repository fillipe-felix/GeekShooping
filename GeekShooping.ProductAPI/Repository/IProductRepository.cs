using GeekShooping.ProductAPI.Data.ViewModels;

namespace GeekShooping.ProductAPI.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductViewModel>> FindAll();
    Task<ProductViewModel> FindById(Guid id);
    Task<ProductViewModel> Create(ProductInputModel inputModel);
    Task<ProductViewModel> Update(Guid id, ProductViewModel viewModel);
    Task<bool> Delete(Guid id);
}
