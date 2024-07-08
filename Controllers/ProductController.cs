using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QanShopWebApi.Models;

namespace QanShopWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly QanShopContext _context;

        public ProductController(QanShopContext context) 
        {
            _context = context;
        }

        #region Get: api/product
        //Get: api/product
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var product = _context.Products.ToList();

            return StatusCode(StatusCodes.Status200OK,product);
        }

        #endregion
    }
}
