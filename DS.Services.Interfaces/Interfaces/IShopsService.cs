using System.Collections.Generic;
using System.Threading.Tasks;
using DS.Services.DTO.DTOs.ShopDTOs;

namespace DS.Services.Interfaces.Interfaces
{
    public interface IShopsService
    {
        Task<IEnumerable<ShopDTO>> GetShopsAsync();
        Task<ShopDTO> CreateShopAsync(CreateShopDTO createShopDTO);

    }
}
