using AutoMapper;
using DS.Domain.Entities.Entities;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.ShopDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.Services.Services
{
    public class ShopsService : IShopsService
    {
        private readonly DishShopContext _dishShopContext;
        private readonly IMapper _mapper;

        public ShopsService(IMapper mapper, DishShopContext dishShopContext)
        {
            _mapper = mapper;
            _dishShopContext = dishShopContext;
        }

        public async Task<IEnumerable<ShopDTO>> GetShopsAsync()
        {
            var shopEntities = await _dishShopContext.Shops
                .Include(shop => shop.City)
                .AsNoTracking()
                .ToListAsync();

            var shopDTOs = _mapper.Map<IEnumerable<ShopDTO>>(shopEntities);
            return shopDTOs;
        }

        public async Task<ShopDTO> CreateShopAsync(CreateShopDTO createShopDTO)
        {
            var shopEntity = _mapper.Map<Shop>(createShopDTO);

            await _dishShopContext.AddAsync(shopEntity);
            await _dishShopContext.SaveChangesAsync();

            var createdShopEntity = await _dishShopContext.Shops
                .Include(shop => shop.City)
                .AsNoTracking()
                .SingleOrDefaultAsync(shop => shop.Id == shopEntity.Id);

            var shopDTO = _mapper.Map<ShopDTO>(createdShopEntity);
            return shopDTO;
        }
    }
}
