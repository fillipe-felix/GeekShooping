using GeekShooping.CartAPI.Data.ViewModels;

namespace GeekShooping.CartAPI.Repositories.Interfaces;

public interface ICartRepository
{
    Task<CartViewModel> FindCartByUserId(Guid userId);
    Task<CartViewModel> SaveOrUpdateCart(CartViewModel cartViewModel);
    Task<bool> RemoveFromCart(Guid cartDetailsId);
    Task<bool> ApplyCoupon(Guid userId, string couponCode);
    Task<bool> RemoveCoupon(Guid userId);
    Task<bool> ClearCart(Guid userId);

}
