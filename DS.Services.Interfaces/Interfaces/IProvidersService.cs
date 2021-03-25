using System.Threading.Tasks;
using DS.Services.DTO.DTOs.ProviderDTOs;

namespace DS.Services.Interfaces.Interfaces
{
    public interface IProvidersService
    {
        Task<ProviderDTO> CreateProviderAsync(CreateProviderDTO createProviderDTO);
    }
}
