using System.Collections.Generic;
using AutoMapper;
using DS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DS.API.ViewModels.ViewModels.CityViewModels;
using DS.API.ViewModels.ViewModels.CountryViewModels;
using DS.API.ViewModels.ViewModels.UtilityViewModels;
using DS.API.ViewModels.ViewModels.ValueTypeViewModels;
using DS.Services.DTO.DTOs.UtilityDTOs;

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

            var cityViewModels = _mapper.Map<IEnumerable<CityViewModel>>(cities);

            return Ok(cityViewModels);
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetAllCountriesAsync(int id)
        {
            var countryDtos = await _utilitiesService.GetAllCountriesAsync();

            var countryViewModels = _mapper.Map<IEnumerable<CountryViewModel>>(countryDtos);

            return Ok(countryViewModels);
        }

        [HttpGet("value-types")]
        public async Task<IActionResult> GetAllValueTypesAsync(int id)
        {
            var valueTypes = await _utilitiesService.GetAllValueTypesAsync();

            var countryViewModels = _mapper.Map<IEnumerable<ValueTypeViewModel>>(valueTypes);

            return Ok(countryViewModels);
        }

        [HttpPost("value-type")]
        public async Task<IActionResult> CreateValueTypeAsync(CreateValueTypeViewModel createValueTypeViewModel)
        {
            var valueTypeDto = _mapper.Map<CreateValueTypeDTO>(createValueTypeViewModel);

            await _utilitiesService.CreateValueTypeAsync(valueTypeDto);

            return Ok();
        }

        [HttpPost("country")]
        public async Task<IActionResult> CreateCountryAsync(CreateCountryViewModel createCountryViewModel)
        {
            var createCountryDto = _mapper.Map<CreateCountryDTO>(createCountryViewModel);

            await _utilitiesService.CreateCountryAsync(createCountryDto);

            return Ok();
        }

        [HttpPost("city")]
        public async Task<IActionResult> CreateCityAsync(CreateCityViewModel createCityViewModel)
        {
            var cityDto = _mapper.Map<CreateCityDTO>(createCityViewModel);

            await _utilitiesService.CreateCityAsync(cityDto);

            return Ok();
        }

        [HttpPost("characteristic")]
        public async Task<IActionResult> CreateCharacteristicAsync(CreateCharacteristicViewModel createCharacteristicViewModel)
        {
            var characteristicDto = _mapper.Map<CreateCharacteristicDTO>(createCharacteristicViewModel);

            await _utilitiesService.CreateCharacteristicAsync(characteristicDto);

            return Ok();
        }

        [HttpPost("producer")]
        public async Task<IActionResult> CreateProducerAsync(CreateProducerViewModel createProducerViewModel)
        {
            var producerDto = _mapper.Map<CreateProducerDTO>(createProducerViewModel);

            await _utilitiesService.CreateProducerAsync(producerDto);

            return Ok();
        }
    }
}
