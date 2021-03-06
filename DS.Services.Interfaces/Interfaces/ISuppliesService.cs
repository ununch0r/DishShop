using DS.Services.DTO.DTOs.SupplyDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.Services.Interfaces.Interfaces
{
    public interface ISuppliesService
    {
        Task<IEnumerable<SupplyDTO>> GetSuppliesAsync();
        Task<SupplyDTO> CreateSupplyAsync(CreateSupplyDTO createSupplyDTO);
        Task ReceiveSupplyAsync(int id);
        Task CancelSupplyAsync(int id);
    }
}
