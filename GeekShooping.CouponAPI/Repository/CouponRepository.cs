using AutoMapper;

using GeekShooping.CouponAPI.Data.ViewModels;
using GeekShooping.CouponAPI.Model.Context;

using Microsoft.EntityFrameworkCore;

namespace GeekShooping.CouponAPI.Repository;

public class CouponRepository : ICouponRepository
{
    private readonly CouponApiContext _couponApiContext;
    private IMapper _mapper;

    public CouponRepository(CouponApiContext couponApiContext, IMapper mapper)
    {
        _couponApiContext = couponApiContext;
        _mapper = mapper;
    }

    public async Task<CouponViewModel> GetCouponByCouponCode(string couponCode)
    {
        var coupon = await _couponApiContext.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);

        return _mapper.Map<CouponViewModel>(coupon);
    }
}
