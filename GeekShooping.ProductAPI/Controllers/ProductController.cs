using GeekShooping.ProductAPI.Data.ViewModels;
using GeekShooping.ProductAPI.Repository;
using GeekShooping.ProductAPI.Utils;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.ProductAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new 
            ArgumentNullException(nameof(productRepository));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productRepository.FindAll();
        
        return Ok(products);
    }
    
    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _productRepository.FindById(id);

        if (product == null)
        {
            return NotFound();
        }
        
        return Ok(product);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] ProductInputModel inputModel)
    {
        if (inputModel == null)
        {
            return BadRequest();
        }
        
        var products = await _productRepository.Create(inputModel);
        
        return Ok(products);
    }
    
    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProductViewModel viewModel)
    {
        if (viewModel == null)
        {
            return BadRequest();
        }
        
        var products = await _productRepository.Update(id, viewModel);
        
        return Ok(products);
    }
    
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = Role.Admin)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var status = await _productRepository.Delete(id);

        if (status == false)
        {
            return BadRequest();
        }
        
        return Ok(status);
    }
}
