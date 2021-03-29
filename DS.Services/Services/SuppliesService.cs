using System;
using AutoMapper;
using DS.Domain.Entities.Entities;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.SupplyDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
                    .ThenInclude(shop => shop.City)
                .Include(supply => supply.Employee)
                .Include(supply => supply.Status)
                .Include(supply => supply.SuppliesContents)
                    .ThenInclude(supplyContent => supplyContent.Product)
                .AsNoTracking()
                .ToListAsync();

            var supplyDTOs = _mapper.Map<IEnumerable<SupplyDTO>>(supplies);
            return supplyDTOs;
        }

        public async Task<SupplyDTO> CreateSupplyAsync(CreateSupplyDTO createSupplyDTO)
        {
            var supplyEntity = _mapper.Map<Supply>(createSupplyDTO);

            await _dishShopContext.AddAsync(supplyEntity);
            await _dishShopContext.SaveChangesAsync();

            var createdSupplyEntity = await _dishShopContext.Supplies
                .Include(supply => supply.Contract)
                .Include(supply => supply.Shop)
                    .ThenInclude(shop => shop.City)
                .Include(supply => supply.Employee)
                .Include(supply => supply.Status)
                .Include(supply => supply.SuppliesContents)
                    .ThenInclude(supplyContent => supplyContent.Product)
                .AsNoTracking()
                .SingleOrDefaultAsync(supply => supply.Id == supplyEntity.Id);

            var supplyDTO = _mapper.Map<SupplyDTO>(createdSupplyEntity);
            return supplyDTO;
        }

        public async Task ReceiveSupplyAsync(int id)
        {
            var supplyEntity = await _dishShopContext.Supplies
                .Include(supply => supply.Contract)
                .Include(supply => supply.Shop)
                .ThenInclude(shop => shop.City)
                .Include(supply => supply.Employee)
                .Include(supply => supply.Status)
                .Include(supply => supply.SuppliesContents)
                .SingleOrDefaultAsync(supply => supply.Id == id);

            IsSupplyStatusInProgress(supplyEntity);
            supplyEntity.StatusId = 2;

            // add logic
            var shopAvailabilities = supplyEntity.SuppliesContents.Select(content => 
                new ShopsAvailability
                {
                    Amount = content.Count,
                    ProductId = content.ProductId,
                    ShopId = supplyEntity.ShopId
                })
                .ToList();

            await _dishShopContext.AddRangeAsync(shopAvailabilities);

            await _dishShopContext.SaveChangesAsync();
        }

        private void IsSupplyStatusInProgress(Supply supply)
        {
            if (supply.StatusId != 1)
            {
                throw new Exception("You can't apply this operation.");
            }
        }
    }
}
