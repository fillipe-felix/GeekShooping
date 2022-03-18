using GeekShooping.Web.Models;
using GeekShooping.Web.Services.Interfaces;
using GeekShooping.Web.Utils;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
            var products = await _productService.FindAllProducts("");
            return View(products);
        }
        
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.CreateProduct(viewModel, token);

                if (response != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(viewModel);
        }
        
        public async Task<IActionResult> ProductUpdate(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var product = await _productService.FindProductById(id, token);

            if (product != null)
            {
                return View(product);
            }
            
            return NotFound();
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(Guid id, ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.UpdateProduct(id, viewModel, token);

                if (response != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(viewModel);
        }
        
        [Authorize]
        public async Task<IActionResult> ProductDelete(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var product = await _productService.FindProductById(id, token);

            if (product != null)
            {
                return View(product);
            }
            
            return NotFound();
        }
        
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(ProductViewModel viewModel)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.DeleteProductById(viewModel.Id, token);

            if (response)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
            

            return View(viewModel);
        }
    }
