using System.Threading.Tasks;
using AutoMapper;
using DS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DS.API.Controllers
{
    [Route("api/utilities")]
    [Produces("application/json")]
    [ApiController]
    public class UtilitiesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUtilitiesService _utilitiesService;

        public UtilitiesController(IMapper mapper, IUtilitiesService utilitiesService)
        {
            _mapper = mapper;
            _utilitiesService = utilitiesService;
        }


        [HttpGet("cities")]
        public async Task<IActionResult> GetAllCitiesAsync(int id)
        {
            var cities = await _utilitiesService.GetAllCitiesAsync();

            return Ok(cities);
        }
    }
}
