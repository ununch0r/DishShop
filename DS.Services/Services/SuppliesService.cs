using AutoMapper;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.SupplyDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.Services.Services
{
    public class SuppliesService : ISuppliesService
    {
        private readonly DishShopContext _dishShopContext;
        private readonly IMapper _mapper;

        public SuppliesService(DishShopContext dishShopContext, IMapper mapper)
        {
            _dishShopContext = dishShopContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SupplyDTO>> GetSuppliesAsync()
        {
            var supplies = await _dishShopContext.Supplies
                .Include(supply => supply.Contract)
                .Include(supply => supply.Shop)
                .Include(supply => supply.Employee)
                .Include(supply => supply.Status)
                .Include(supply => supply.SuppliesContents)
                .ThenInclude(supplyContent => supplyContent.Product)
                .AsNoTracking()
                .ToListAsync();

            var supplyDTOs = _mapper.Map<IEnumerable<SupplyDTO>>(supplies);
            return supplyDTOs;
        }
    }
}
