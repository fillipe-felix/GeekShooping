using System.Net.Http.Headers;

using GeekShooping.Web.Models;
using GeekShooping.Web.Services.Interfaces;
using GeekShooping.Web.Utils;

namespace GeekShooping.Web.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _client;
    public const string BasePath = "api/v1/Product";

    public ProductService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<ProductViewModel>> FindAllProducts(string token)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _client.GetAsync(BasePath);
        return await response.ReadContentAs<IEnumerable<ProductViewModel>>();
    }

    public async Task<ProductViewModel> FindProductById(Guid id, string token)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _client.GetAsync($"{BasePath}/{id}");
        return await response.ReadContentAs<ProductViewModel>();
    }

    public async Task<ProductViewModel> CreateProduct(ProductViewModel viewModel, string token)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _client.PostAsJson(BasePath, viewModel);

        if (response.IsSuccessStatusCode)
        {
            return await response.ReadContentAs<ProductViewModel>();
        }
        else
        {
            throw new Exception("Something went wrong when callinh API");
        }
    }

    public async Task<ProductViewModel> UpdateProduct(Guid id, ProductViewModel viewModel, string token)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _client.PutAsJson($"{BasePath}/{id}", viewModel);

        if (response.IsSuccessStatusCode)
        {
            return await response.ReadContentAs<ProductViewModel>();
        }
        else
        {
            throw new Exception("Something went wrong when callinh API");
        }
    }

    public async Task<bool> DeleteProductById(Guid id, string token)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _client.DeleteAsync($"{BasePath}/{id}");
        
        if (response.IsSuccessStatusCode)
        {
            return await response.ReadContentAs<bool>();
        }
        else
        {
            throw new Exception("Something went wrong when callinh API");
        }
    }
}
