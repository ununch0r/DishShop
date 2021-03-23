using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DS.API.Controllers
{
    [Route("api/orders")]
    [Produces("application/json")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var a = 3;
            return Ok(a);
        }
    }
}
