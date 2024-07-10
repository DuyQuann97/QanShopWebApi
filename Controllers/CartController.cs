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
            var items = await _context.Carts.Include(x => x.Product).ToListAsync();
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

                cartItem.Quantity += 1;
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

        #region Delete Cart Item
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _context.Carts.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null) return NotFound(id);

            _context.Carts.Remove(result);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, result);
        }

        #endregion
    }
}
