using System.Collections.Generic;
using System.Threading.Tasks;
using DS.Services.DTO.DTOs.ProviderDTOs;

namespace DS.Services.Interfaces.Interfaces
{
    public interface ISuppliesService
    {
        Task<IEnumerable<ProviderDTO>> GetSuppliesAsync();
    }
}
