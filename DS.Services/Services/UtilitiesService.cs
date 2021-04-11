using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DS.Domain.Entities.Entities;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.CityDTOs;
using DS.Services.DTO.DTOs.CountryDTOs;
using DS.Services.DTO.DTOs.UtilityDTOs;
using DS.Services.DTO.DTOs.ValueTypeDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DS.Services.Services
{
    public class UtilitiesService : IUtilitiesService
    {
        private readonly DishShopContext _dishShopContext;
        private readonly IMapper _mapper;

        public UtilitiesService(DishShopContext dishShopContext, IMapper mapper)
        {
            _dishShopContext = dishShopContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDTO>> GetAllCitiesAsync()
        {
            var cities = await _dishShopContext.Cities.AsNoTracking().ToListAsync();

            var cityDTOs = _mapper.Map<IEnumerable<CityDTO>>(cities);

            return cityDTOs;
        }

        public async Task<IEnumerable<CountryDTO>> GetAllCountriesAsync()
        {
            var countries = await _dishShopContext.Countries.AsNoTracking().ToListAsync();

            var countryDtos = _mapper.Map<IEnumerable<CountryDTO>>(countries);

            return countryDtos;
        }

        public async Task<IEnumerable<ValueTypeDTO>> GetAllValueTypesAsync()
        {
            var valueTypes = await _dishShopContext.ValueTypes.AsNoTracking().ToListAsync();

            var valueTypeDtos = _mapper.Map<IEnumerable<ValueTypeDTO>>(valueTypes);

            return valueTypeDtos;
        }

        public async Task CreateProducerAsync(CreateProducerDTO createProducerDto)
        {
            var producer = _mapper.Map<Producer>(createProducerDto);

            await _dishShopContext.AddAsync(producer);
            await _dishShopContext.SaveChangesAsync();
        }

        public async Task CreateCityAsync(CreateCityDTO createCity)
        {
            var city = _mapper.Map<City>(createCity);

            await _dishShopContext.AddAsync(city);
            await _dishShopContext.SaveChangesAsync();
        }

        public async Task CreateCountryAsync(CreateCountryDTO createCountryDto)
        {
            var country = _mapper.Map<Country>(createCountryDto);

            await _dishShopContext.AddAsync(country);
            await _dishShopContext.SaveChangesAsync();
        }

        public async Task CreateCharacteristicAsync(CreateCharacteristicDTO createCharacteristicDto)
        {
            var characteristic = _mapper.Map<Characteristic>(createCharacteristicDto);

            await _dishShopContext.AddAsync(characteristic);
            await _dishShopContext.SaveChangesAsync();
        }

        public async Task CreateValueTypeAsync(CreateValueTypeDTO createValueTypeDto)
        {
            var valueType = _mapper.Map<ValueType>(createValueTypeDto);

            await _dishShopContext.AddAsync(valueType);
            await _dishShopContext.SaveChangesAsync();
        }
    }
}
