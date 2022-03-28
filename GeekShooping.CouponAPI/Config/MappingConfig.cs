using AutoMapper;

using GeekShooping.CouponAPI.Data.ViewModels;
using GeekShooping.CouponAPI.Model;

namespace GeekShooping.CouponAPI.Config;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<CouponViewModel, Coupon>().ReverseMap();
    }
}
