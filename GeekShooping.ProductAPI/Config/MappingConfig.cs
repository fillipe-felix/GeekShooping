using AutoMapper;

using GeekShooping.ProductAPI.Data.ViewModels;
using GeekShooping.ProductAPI.Model;

namespace GeekShooping.ProductAPI.Config;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<ProductViewModel, Product>().ReverseMap();
    }
}
