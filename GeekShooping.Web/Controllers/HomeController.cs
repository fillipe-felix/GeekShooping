using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using GeekShooping.Web.Models;

using Microsoft.AspNetCore.Authorization;

namespace GeekShooping.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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
        return SignOut("Cookies", "iodc");
    }
    
    [Authorize]
    public async Task<IActionResult> Login()
    {
        return RedirectToAction(nameof(Index));
    }
}
