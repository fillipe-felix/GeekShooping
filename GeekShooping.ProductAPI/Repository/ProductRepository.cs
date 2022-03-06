using AutoMapper;

using GeekShooping.ProductAPI.Data.ViewModels;
using GeekShooping.ProductAPI.Model;
using GeekShooping.ProductAPI.Model.Context;

using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;
    private IMapper _mapper;

    public ProductRepository(ProductContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductViewModel>> FindAll()
    {
        var product = await _context.Products.ToListAsync();

        return _mapper.Map<IEnumerable<ProductViewModel>>(product);
    }

    public async Task<ProductViewModel> FindById(string id)
    {
        var product = await _context
            .Products
            .Where(s => s.Id.Equals(id))
            .FirstOrDefaultAsync();

        return _mapper.Map<ProductViewModel>(product);
    }

    public async Task<ProductViewModel> Create(ProductViewModel viewModel)
    {
        var product = _mapper.Map<Product>(viewModel);

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        
        return _mapper.Map<ProductViewModel>(product);
    }

    public async Task<ProductViewModel> Update(ProductViewModel viewModel)
    {
        var product = _mapper.Map<Product>(viewModel);

        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        
        return _mapper.Map<ProductViewModel>(product);
    }

    public async Task<bool> Delete(string id)
    {
        try
        {
            var product = await _context
                .Products
                .Where(s => s.Id.Equals(id))
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}
