using GeekShooping.CouponAPI.Data.ViewModels;

namespace GeekShooping.CouponAPI.Repository;

public interface ICouponRepository
{
    Task<CouponViewModel> GetCouponByCouponCode(string couponCode);
}
