using AutoMapper;
using DS.API.ViewModels.ViewModels.ProducerViewModels;
using DS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.API.Controllers
{
    [Route("api/producers")]
    [Produces("application/json")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly IProducersService _producersService;
        private readonly IMapper _mapper;

        public ProducersController(IMapper mapper, IProducersService producersService)
        {
            _mapper = mapper;
            _producersService = producersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducersAsync()
        {
            var catalogProducerDTOs = await _producersService.GetProducersAsync();

            var catalogProducerViewModels = _mapper.Map<IEnumerable<ProducerViewModel>>(catalogProducerDTOs);

            return Ok(catalogProducerViewModels);
        }
    }
}