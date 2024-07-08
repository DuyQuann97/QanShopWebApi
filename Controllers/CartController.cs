using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QanShopWebApi.Models;
using QanShopWebApi.Models.ViewModels;

namespace QanShopWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly QanShopContext _context;

        public CartController(QanShopContext context)
        {
            _context = context;
        }

        #region Get Cart
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAsync() 
        {
            var items = await _context.Carts.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, items);
        }

        #endregion

        #region Create Cart
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCartClass createCart) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var cartItem = await _context.Carts.FirstOrDefaultAsync(x => x.ProductId == createCart.ProductId);
            if (cartItem != null)
            {

                cartItem.Quantity = createCart.Quantity;
                _context.Carts.Update(cartItem);
            }
            else 
            {
                cartItem = new Cart
                {
                    Id = Guid.NewGuid(),
                    Quantity = createCart.Quantity,
                    ProductId = createCart.ProductId
                };
                await _context.Carts.AddAsync(cartItem);
            }
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, cartItem);
        }

        #endregion
    }
}
