using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DS.API.Controllers
{
    [Route("api/orders")]
    [Produces("application/json")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DishShopContext _dishShopContext;

        public ProductsController(DishShopContext dishShopContext)
        {
            _dishShopContext = dishShopContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var a = await _dishShopContext.Countries.ToListAsync();
            return Ok(a);
        }
    }
}
