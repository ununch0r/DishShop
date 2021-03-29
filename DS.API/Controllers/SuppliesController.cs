using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DS.API.ViewModels.ViewModels.SupplyViewModels;
using DS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DS.API.Controllers
{
    [Route("api/supplies")]
    [Produces("application/json")]
    [ApiController]
    public class SuppliesController : ControllerBase
    {
        private readonly ISuppliesService _suppliesService;
        private readonly IMapper _mapper;

        public SuppliesController(ISuppliesService suppliesService, IMapper mapper)
        {
            _suppliesService = suppliesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSuppliesAsync()
        {
            var supplyDTOs = await _suppliesService.GetSuppliesAsync();

            var supplyViewModels = _mapper.Map<IEnumerable<SupplyViewModel>>(supplyDTOs);

            return Ok(supplyViewModels);
        }
    }
}
