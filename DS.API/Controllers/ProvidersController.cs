using System.Collections.Generic;
using AutoMapper;
using DS.API.ViewModels.ViewModels.ProviderViewModels;
using DS.Services.DTO.DTOs.ProviderDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DS.API.Controllers
{
    [Route("api/providers")]
    [Produces("application/json")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IProvidersService _providersService;
        private readonly IMapper _mapper;

        public ProvidersController(IMapper mapper, IProvidersService providersService)
        {
            _mapper = mapper;
            _providersService = providersService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProviderAsync(
            [FromBody][Required] CreateProviderViewModel createProviderViewModel
        )
        {
            var createProviderDTO = _mapper.Map<CreateProviderDTO>(createProviderViewModel);

            var createdProviderDTO = await _providersService.CreateProviderAsync(createProviderDTO);
            var createdProviderViewModel = _mapper.Map<ProviderViewModel>(createdProviderDTO);

            return Ok(createdProviderViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetProvidersAsync()
        {
            var providerDTOs = await _providersService.GetProvidersAsync();

            var providerViewModels = _mapper.Map<IEnumerable<ProviderViewModel>>(providerDTOs);

            return Ok(providerViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProviderByIdAsync(int id)
        {
            var providerDTO = await _providersService.GetProviderByIdAsync(id);

            var providerViewModel = _mapper.Map<ProviderViewModel>(providerDTO);

            return Ok(providerViewModel);
        }
    }
}
