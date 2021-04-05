using AutoMapper;
using DS.Domain.Entities.Entities;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.ShopDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DS.Services.DTO.DTOs.ShopAvailabilityDTOs;

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
                .Include(shop => shop.Employees)
                .ThenInclude(employee => employee.Position)
                .Include(shop => shop.Supplies)
                    .ThenInclude(supply => supply.Status)
                .Include(shop => shop.ShopsAvailabilities)
                    .ThenInclude(shopAvailability => shopAvailability.Product)
                        .ThenInclude(product => product.Category)
                .Include(shop => shop.City)
                .AsNoTracking()
                .ToListAsync();

            var shopDTOs = _mapper.Map<IEnumerable<ShopDTO>>(shopEntities);

            foreach (var shop in shopDTOs)
            {
                shop.Manager = shop.Employees.SingleOrDefault(employee => employee.Position.Id == 2);
            }

            return shopDTOs;
        }

        public async Task<IEnumerable<ShopAvailabilityDTO>> GetShopAvailabilitiesAsync(int shopId)
        {
            var shopAvailabilities = await _dishShopContext.ShopsAvailabilities
                .Include(shopAvailability =>shopAvailability.Product)
                    .ThenInclude(product => product.Category)
                .Include(shopAvailability => shopAvailability.Product)
                    .ThenInclude(product => product.Producer)
                        .ThenInclude(producer => producer.Country)
                .Include(shopAvailability => shopAvailability.Product)
                    .ThenInclude(product => product.ProductsCharacteristics)
                        .ThenInclude(productCharacteristic => productCharacteristic.Characteristic)
                            .ThenInclude(characteristic => characteristic.ValueType)
                .Where(shopAvailability => shopAvailability.ShopId == shopId)
                .ToListAsync();

            var shopAvailabilityDTOs = _mapper.Map<IEnumerable<ShopAvailabilityDTO>>(shopAvailabilities);
            return shopAvailabilityDTOs;
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
