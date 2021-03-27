using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using DS.API.ViewModels.ViewModels.ShopViewModels;
using DS.Services.DTO.DTOs.ShopDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DS.API.Controllers
{
    [Route("api/shops")]
    [Produces("application/json")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IShopsService _shopsService;
        private readonly IMapper _mapper;

        public ShopsController(IShopsService shopsService, IMapper mapper)
        {
            _shopsService = shopsService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShopAsync(
            [FromBody][Required] CreateShopViewModel createShopViewModel
        )
        {
            var createShopDTO = _mapper.Map<CreateShopDTO>(createShopViewModel);

            var createdShopDTO = await _shopsService.CreateShopAsync(createShopDTO);
            var createdShopViewModel = _mapper.Map<ShopViewModel>(createdShopDTO);

            return Ok(createdShopViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetShopsAsync()
        {
            var catalogShopDTOs = await _shopsService.GetShopsAsync();

            var catalogShopViewModels = _mapper.Map<IEnumerable<ShopViewModel>>(catalogShopDTOs);

            return Ok(catalogShopViewModels);
        }
    }
}
