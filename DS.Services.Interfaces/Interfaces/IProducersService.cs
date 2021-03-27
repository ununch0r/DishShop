using DS.Services.DTO.DTOs.ProducerDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.Services.Interfaces.Interfaces
{
    public interface IProducersService
    {
        Task<IEnumerable<ProducerDTO>> GetProducersAsync();
    }
}
