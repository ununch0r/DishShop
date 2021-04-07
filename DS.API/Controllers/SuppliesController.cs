using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using DS.API.ViewModels.ViewModels.SupplyViewModels;
using DS.Services.DTO.DTOs.SupplyDTOs;
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

        [HttpPost]
        public async Task<IActionResult> CreateSupplyAsync(
            [FromBody][Required] CreateSupplyViewModel createSupplyViewModel
        )
        {
            // problem can be in missing default value for 'created supply' field
            var createSupplyDTO = _mapper.Map<CreateSupplyDTO>(createSupplyViewModel);

            var createdSupplyDTO = await _suppliesService.CreateSupplyAsync(createSupplyDTO);
            var createdSupplyViewModel = _mapper.Map<SupplyViewModel>(createdSupplyDTO);

            return Ok(createdSupplyViewModel);
        }

        [HttpPut("{id}/receive")]
        public async Task<IActionResult> ReceiveSupplyAsync(int id)
        {
            await _suppliesService.ReceiveSupplyAsync(id);

            return Ok();
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelSupplyAsync(int id)
        {
            await _suppliesService.CancelSupplyAsync(id);

            return Ok();
        }
    }
}
