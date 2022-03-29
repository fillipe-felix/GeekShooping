using System.Net.Http.Headers;

using GeekShooping.Web.Models;
using GeekShooping.Web.Services.Interfaces;
using GeekShooping.Web.Utils;

namespace GeekShooping.Web.Services;

public class CartService : ICartService
{
    private readonly HttpClient _client;
    public const string BasePath = "api/v1/Cart";

    public CartService(HttpClient client)
    {
        _client = client;
    }

    public async Task<CartViewModel> FindCartByUserId(Guid id, string token)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _client.GetAsync($"{BasePath}/find-cart/{id}");
        return await response.ReadContentAs<CartViewModel>();
    }

    public async Task<CartViewModel> AddItemToCart(CartViewModel cart, string token)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _client.PostAsJson($"{BasePath}/add-cart", cart);

        if (response.IsSuccessStatusCode)
        {
            return await response.ReadContentAs<CartViewModel>();
        }
        else
        {
            throw new Exception("Something went wrong when callinh API");
        }
    }

    public async Task<CartViewModel> UpdateCart(CartViewModel cart, string token)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _client.PostAsJson($"{BasePath}/update-cart", cart);

        if (response.IsSuccessStatusCode)
        {
            return await response.ReadContentAs<CartViewModel>();
        }
        else
        {
            throw new Exception("Something went wrong when callinh API");
        }
    }

    public async Task<bool> RemoveFromCart(string cartId, string token)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _client.DeleteAsync($"{BasePath}/remove-cart/{cartId}");
        
        if (response.IsSuccessStatusCode)
        {
            return await response.ReadContentAs<bool>();
        }
        else
        {
            throw new Exception("Something went wrong when callinh API");
        }
    }

    public async Task<bool> ApplyCoupon(CartViewModel cart, string token)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _client.PostAsJson($"{BasePath}/apply-coupon", cart);
        
        if (response.IsSuccessStatusCode)
        {
            return await response.ReadContentAs<bool>();
        }
        else
        {
            throw new Exception("Something went wrong when callinh API");
        }
    }

    public async Task<bool> RemoveCoupon(Guid userId, string token)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _client.DeleteAsync($"{BasePath}/remove-coupon/{userId}");
        
        if (response.IsSuccessStatusCode)
        {
            return await response.ReadContentAs<bool>();
        }
        else
        {
            throw new Exception("Something went wrong when callinh API");
        }
    }

    public async Task<bool> ClearCart(Guid userId, string token)
    {
        throw new NotImplementedException();
    }

    public async Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
    {
        throw new NotImplementedException();
    }
}
