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
        Cart cart = new Cart
        {
            CartHeader = await _cartApiContext.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId),
            
        };

        cart.CartDetails = _cartApiContext.CartDetails
            .Where(c => c.CartHeaderId == cart.CartHeader.Id)
            .Include(c => c.Product);
        
        return _mapper.Map<CartViewModel>(cart);
    }

    public async Task<CartViewModel> SaveOrUpdateCart(CartViewModel cartViewModel)
    {
        Cart cart = _mapper.Map<Cart>(cartViewModel);

        // Check if the product is already saved in the database if it does not exist then save
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
        else
        {
            // If cartHeader is not null
            // Check is CArtDetails has same product
            var cartDetail = await _cartApiContext.CartDetails
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ProductId == cartViewModel.CartDetails.FirstOrDefault().ProductId 
                                          && c.CartHeaderId == cartHeader.Id);

            if (cartDetail == null)
            {
                // Create cartDetails
                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                cart.CartDetails.FirstOrDefault().Product = null;
                _cartApiContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await _cartApiContext.SaveChangesAsync();
            }
            else
            {
                // Update product count and cartDetails
                cart.CartDetails.FirstOrDefault().Product = null;
                cart.CartDetails.FirstOrDefault().Count += cartDetail.Count;
                cart.CartDetails.FirstOrDefault().Id = cartDetail.Id;
                cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetail.CartHeaderId;
                _cartApiContext.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                await _cartApiContext.SaveChangesAsync();
            }
        }

        return _mapper.Map<CartViewModel>(cart);
    }

    public async Task<bool> RemoveFromCart(Guid cartDetailsId)
    {
        try
        {
            CartDetail cartDetail = await _cartApiContext.CartDetails.FirstOrDefaultAsync(c => c.Id == cartDetailsId);

            int total = _cartApiContext.CartDetails.Where(c => c.CartHeaderId == cartDetail.CartHeaderId).Count();

            _cartApiContext.CartDetails.Remove(cartDetail);

            if (total == 1)
            {
                var cartHeaderToRemove = await _cartApiContext.CartHeaders.FirstOrDefaultAsync(c => c.Id == cartDetail.CartHeaderId);
                _cartApiContext.CartHeaders.Remove(cartHeaderToRemove);
            }

            await _cartApiContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
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
        var cartHeader = await _cartApiContext.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId);

        if (cartHeader != null)
        {
            _cartApiContext.CartDetails
                .RemoveRange(_cartApiContext.CartDetails.Where(c => c.CartHeaderId == cartHeader.Id));

            _cartApiContext.CartHeaders.Remove(cartHeader);
            await _cartApiContext.SaveChangesAsync();
            
            return true;
        }

        return false;
    }
}
