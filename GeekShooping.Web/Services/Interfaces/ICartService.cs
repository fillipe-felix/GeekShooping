using GeekShooping.Web.Models;

namespace GeekShooping.Web.Services.Interfaces;

public interface ICartService
{
    Task<CartViewModel> FindCartByUserId(Guid id, string token);
    Task<CartViewModel> AddItemToCart(CartViewModel cart, string token);
    Task<CartViewModel> UpdateCart(CartViewModel cart, string token);
    Task<bool> RemoveFromCart(string cartId, string token);
    Task<bool> ApplyCoupon(CartViewModel cart, string token);
    Task<bool> RemoveCoupon(Guid userId, string token);
    Task<bool> ClearCart(Guid userId, string token);
    Task<CartHeaderViewModel> Checkout(CartHeaderViewModel cartHeader, string token);
}
