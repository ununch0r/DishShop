using DS.Services.DTO.DTOs.CityDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.Services.Interfaces.Interfaces
{
    public interface IUtilitiesService
    {
        Task<IEnumerable<CityDTO>> GetAllCitiesAsync();
    }
}
