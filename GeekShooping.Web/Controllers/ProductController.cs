using GeekShooping.Web.Models;
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
        
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(viewModel);

                if (response != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(viewModel);
        }
    }
