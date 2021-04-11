using DS.Services.DTO.DTOs.CityDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using DS.Services.DTO.DTOs.CountryDTOs;
using DS.Services.DTO.DTOs.UtilityDTOs;
using DS.Services.DTO.DTOs.ValueTypeDTOs;

namespace DS.Services.Interfaces.Interfaces
{
    public interface IUtilitiesService
    {
        Task<IEnumerable<CityDTO>> GetAllCitiesAsync();
        Task<IEnumerable<CountryDTO>> GetAllCountriesAsync();
        Task<IEnumerable<ValueTypeDTO>> GetAllValueTypesAsync();
        Task CreateProducerAsync(CreateProducerDTO createProducerDto);
        Task CreateCityAsync(CreateCityDTO createCity);
        Task CreateCountryAsync(CreateCountryDTO createCountryDto);
        Task CreateCharacteristicAsync(CreateCharacteristicDTO createCharacteristicDto);
        Task CreateValueTypeAsync(CreateValueTypeDTO createValueTypeDto);
    }
}
