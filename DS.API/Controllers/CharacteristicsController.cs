using AutoMapper;
using DS.API.ViewModels.ViewModels.CharacteristicViewModels;
using DS.Services.DTO.DTOs.CharacteristicDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DS.API.ViewModels.ViewModels.UtilityViewModels;
using DS.Services.DTO.DTOs.UtilityDTOs;

namespace DS.API.Controllers
{
    [Route("api/characteristics")]
    [Produces("application/json")]
    [ApiController]
    public class CharacteristicsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICharacteristicService _characteristicService;

        public CharacteristicsController(ICharacteristicService characteristicService, IMapper mapper)
        {
            _characteristicService = characteristicService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> GetCatalogProductsAsync(
            [FromBody] [Required] CreateCharacteristicViewModel createCharacteristicViewModel
            )
        {
            var createCharacteristicDTO = _mapper.Map<CreateCharacteristicDTO>(createCharacteristicViewModel);

            var createdCharacteristicDTO = await _characteristicService.CreateCharacteristicAsync(createCharacteristicDTO);
            var createdCharacteristicViewModel = _mapper.Map<CharacteristicViewModel>(createdCharacteristicDTO);

            return Ok(createdCharacteristicViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacteristicsByCategoryIdAsync(int id)
        {
            var characteristicDTOs = await _characteristicService.GetCharacteristicsByCategoryIdAsync(id);

            var characteristicViewModels = _mapper.Map<IEnumerable<CharacteristicViewModel>>(characteristicDTOs);

            return Ok(characteristicViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> GetCharacteristicsAsync()
        {
            var characteristicDTOs = await _characteristicService.GetCharacteristicsAsync();

            var characteristicViewModels = _mapper.Map<IEnumerable<CharacteristicViewModel>>(characteristicDTOs);

            return Ok(characteristicViewModels);
        }
    }
}
