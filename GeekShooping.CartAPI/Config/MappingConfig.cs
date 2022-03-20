using AutoMapper;

using GeekShooping.CartAPI.Data.ViewModels;
using GeekShooping.CartAPI.Model;

namespace GeekShooping.CartAPI.Config;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<ProductViewModel, Product>().ReverseMap();
        CreateMap<CartHeaderViewModel, CartHeader>().ReverseMap();
        CreateMap<CartDetailViewModel, CartDetail>().ReverseMap();
        CreateMap<CartViewModel, Cart>().ReverseMap();
    }
}
