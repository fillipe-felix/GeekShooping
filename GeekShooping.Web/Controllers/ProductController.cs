using GeekShooping.Web.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.Web.Controllers;

    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }
    }
