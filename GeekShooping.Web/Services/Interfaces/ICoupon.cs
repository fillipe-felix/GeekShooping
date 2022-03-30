using GeekShooping.Web.Models;

namespace GeekShooping.Web.Services.Interfaces;

public interface ICouponService
{
    Task<CouponViewModel> GetCoupon(string code, string token);
}
