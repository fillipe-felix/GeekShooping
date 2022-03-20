using AutoMapper;

using GeekShooping.CartAPI.Data.ViewModels;
using GeekShooping.CartAPI.Model;
using GeekShooping.CartAPI.Model.Context;
using GeekShooping.CartAPI.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

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

    public async Task<CartViewModel> FindCartByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<CartViewModel> SaveOrUpdateCart(CartViewModel cartViewModel)
    {
        Cart cart = _mapper.Map<Cart>(cartViewModel);

        var product = await _cartApiContext.Products
            .FirstOrDefaultAsync(p => p.Id == cartViewModel.CartDetails.FirstOrDefault().ProductId);

        if (product == null)
        {
            _cartApiContext.Products.Add(cart.CartDetails.FirstOrDefault().Product);
            await _cartApiContext.SaveChangesAsync();
        }

        // Check if CartHeader is null
        var cartHeader = await _cartApiContext.CartHeaders
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.UserId == cart.CartHeader.UserId);

        if (cartHeader == null)
        {
            // Create CartHeader and CartDetails
            _cartApiContext.CartHeaders.Add(cart.CartHeader);
            await _cartApiContext.SaveChangesAsync();
            
            cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
            cart.CartDetails.FirstOrDefault().Product = null;
            _cartApiContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());
            await _cartApiContext.SaveChangesAsync();
        }
    }

    public async Task<bool> RemoveFromCart(Guid cartDetailsId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ApplyCoupon(Guid userId, string couponCode)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveCoupon(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ClearCart(Guid userId)
    {
        throw new NotImplementedException();
    }
}
