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

    public HomeController(ILogger<HomeController> logger, 
                          IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        var products = await _productService.FindAllProducts(token);
        return View(products);
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
