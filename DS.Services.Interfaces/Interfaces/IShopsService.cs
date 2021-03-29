using System.Collections.Generic;
using System.Threading.Tasks;
using DS.Services.DTO.DTOs.ShopAvailabilityDTOs;
using DS.Services.DTO.DTOs.ShopDTOs;

namespace DS.Services.Interfaces.Interfaces
{
    public interface IShopsService
    {
        Task<IEnumerable<ShopDTO>> GetShopsAsync();
        Task<IEnumerable<ShopAvailabilityDTO>> GetShopAvailabilitiesAsync(int shopId);
        Task<ShopDTO> CreateShopAsync(CreateShopDTO createShopDTO);

    }
}
