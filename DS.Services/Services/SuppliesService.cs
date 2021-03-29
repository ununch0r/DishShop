using System.Collections.Generic;
using System.Threading.Tasks;
using DS.Services.DTO.DTOs.SupplyDTOs;
using DS.Services.Interfaces.Interfaces;

namespace DS.Services.Services
{
    public class SuppliesService : ISuppliesService
    {
        public async Task<IEnumerable<SupplyDTO>> GetSuppliesAsync()
        {
            var supplies = await _dishShopContext.Supplies
                .Include(supply => supply.Contract)
                .Include(supply => supply.Shop)
                .Include(supply => supply.Employee)
                .Include(supply => supply.SupplyStatus)
                .Include(supply => supply.SuppliesCOntents)
                .ThenInclude(supplyContent => supplyContent.Product)
                .AsNoTracking()
                .ToListAsync();

            var supplyDTOs = _mapper.Map<IEnumerable<SupplyDTO>>(supplies);
            return supplyDTOs;
        }
    }
}
