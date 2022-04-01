using GeekShooping.CartAPI.Data.ViewModels;
using GeekShooping.CartAPI.Repositories.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.CartAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet("find-cart/{userId}")]
        public async Task<ActionResult<CartViewModel>> FindById(Guid userId)
        {
            var cart = await _repository.FindCartByUserId(userId);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CartViewModel>> AddCart(CartViewModel vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartViewModel>> UpdateCart(CartViewModel vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<CartViewModel>> RemoveCart(Guid id)
        {
            var status = await _repository.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
        
        [HttpPost("apply-coupon")]
        public async Task<ActionResult<CartViewModel>> ApplyCoupon(CartViewModel vo)
        {
            var status = await _repository.ApplyCoupon(Guid.Parse(vo.CartHeader.UserId), vo.CartHeader.CouponCode);
            if (!status) return NotFound();
            return Ok(status);
        }
        
        [HttpDelete("remove-coupon/{userId}")]
        public async Task<ActionResult<CartViewModel>> ApplyCoupon(Guid userId)
        {
            var status = await _repository.RemoveCoupon(userId);
            if (!status) return NotFound();
            return Ok(status);
        }
        
        [HttpDelete("checkout")]
        public async Task<ActionResult<CartViewModel>> Checkout()
        {
            var status = await _repository.RemoveCoupon(userId);
            if (!status) return NotFound();
            return Ok(status);
        }
    }
}
