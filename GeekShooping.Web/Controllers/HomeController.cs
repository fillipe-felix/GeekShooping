using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using GeekShooping.Web.Models;
using GeekShooping.Web.Services.Interfaces;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace GeekShooping.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;
    private readonly ICartService _cartService;

    public HomeController(ILogger<HomeController> logger, 
                          IProductService productService,
                          ICartService cartService)
    {
        _logger = logger;
        _productService = productService;
        _cartService = cartService;
    }

    public async Task<IActionResult> Index()
    {
        //var token = await HttpContext.GetTokenAsync("access_token");
        var products = await _productService.FindAllProducts("");
        return View(products);
    }
    
    [Authorize]
    public async Task<IActionResult> Details(Guid id)
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        var model = await _productService.FindProductById(id, token);
        return View(model);
    }
    
    [Authorize]
    [ActionName("Details")]
    [HttpPost]
    public async Task<IActionResult> DetailsPost(ProductViewModel model)
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        CartViewModel cart = new CartViewModel
        {
            CartHeaderViewModel = new CartHeaderViewModel
            {
                UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value
            }
        };

        CartDetailViewModel cartDetail = new CartDetailViewModel
        {
            Count = model.Count,
            ProductId = model.Id,
            ProductViewModel = await _productService.FindProductById(model.Id, token)
        };

        List<CartDetailViewModel> cartDetais = new List<CartDetailViewModel>();
        cartDetais.Add(cartDetail);

        var response = await _cartService.AddItemToCart(cart, token);

        if (response != null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public IActionResult Logout()
    {
        return SignOut("Cookies", "oidc");
    }
    
    [Authorize]
    public async Task<IActionResult> Login()
    {
        return RedirectToAction(nameof(Index));
    }
}
