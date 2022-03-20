using AutoMapper;

using GeekShooping.CartAPI.Data.ViewModels;
using GeekShooping.CartAPI.Model.Context;
using GeekShooping.CartAPI.Repositories.Interfaces;

namespace GeekShooping.CartAPI.Repositories;

public class CartRepository : ICartRepository
{
    private readonly CartApiContext _cartApiContext;
    private IMapper _mapper;

    public CartRepository(CartApiContext cartApiContext, IMapper mapper)
    {
        _cartApiContext = cartApiContext;
        _mapper = mapper;
    }

    public Task<CartViewModel> FindCartByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<CartViewModel> SaveOrUpdateCart(CartViewModel cartViewModel)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveFromCart(Guid cartDetailsId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ApplyCoupon(Guid userId, string couponCode)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveCoupon(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ClearCart(Guid userId)
    {
        throw new NotImplementedException();
    }
}
