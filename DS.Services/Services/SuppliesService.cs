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
using DS.Services.DTO.DTOs.SupplyContentDTOs;

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
                .Include(supply => supply.Creator)
                .Include(supply => supply.Canceller)
                .Include(supply => supply.Receiver)
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
            supplyEntity.StatusId = 1;
            supplyEntity.DateCreated = DateTime.Now;
            supplyEntity.TotalPrice =
                await CalculateTotalPriceAsync(supplyEntity.ContractId, createSupplyDTO.SuppliesContents);

            await _dishShopContext.AddAsync(supplyEntity);
            await _dishShopContext.SaveChangesAsync();

            var createdSupplyEntity = await _dishShopContext.Supplies
                .Include(supply => supply.Contract)
                .Include(supply => supply.Shop)
                    .ThenInclude(shop => shop.City)
                .Include(supply => supply.Creator)
                .Include(supply => supply.Canceller)
                .Include(supply => supply.Receiver)
                .Include(supply => supply.Status)
                .Include(supply => supply.SuppliesContents)
                    .ThenInclude(supplyContent => supplyContent.Product)
                .AsNoTracking()
                .SingleOrDefaultAsync(supply => supply.Id == supplyEntity.Id);

            var supplyDTO = _mapper.Map<SupplyDTO>(createdSupplyEntity);
            return supplyDTO;
        }

        private async Task<decimal> CalculateTotalPriceAsync(int contractId, IEnumerable<CreateSupplyContentDTO> supplyContent)
        {
            var contract = await _dishShopContext.Contracts
                .Include(contract => contract.ContractsContents)
                .SingleOrDefaultAsync(contract => contract.Id == contractId);

            var sum = supplyContent.Sum(supplyContentDto => contract.ContractsContents
                .First(contractContent => contractContent.ProductId == supplyContentDto.ProductId)
                .PricePerUnit * supplyContentDto.Count);

            return sum;
        }

        public async Task ReceiveSupplyAsync(int id)
        {
            var supplyEntity = await _dishShopContext.Supplies
                .Include(supply => supply.Contract)
                .Include(supply => supply.Shop)
                .ThenInclude(shop => shop.City)
                .Include(supply => supply.Creator)
                .Include(supply => supply.Status)
                .Include(supply => supply.SuppliesContents)
                .SingleOrDefaultAsync(supply => supply.Id == id);

            IsSupplyStatusInProgress(supplyEntity);
            supplyEntity.ReceiverId = 27; //HERE!!!!!!!!!!!!!
            supplyEntity.StatusId = 2;
            supplyEntity.DateReceived = DateTime.Now;

            var shopAvailabilities = supplyEntity.SuppliesContents.Select(content => 
                new ShopsAvailability
                {
                    Amount = content.Count,
                    ProductId = content.ProductId,
                    ShopId = supplyEntity.ShopId
                })
                .ToList();

            await ApplyAvailabilitiesAsync(shopAvailabilities);

            await _dishShopContext.SaveChangesAsync();
        }

        private async Task ApplyAvailabilitiesAsync(IEnumerable<ShopsAvailability> availabilities)
        {
            foreach (var availability in availabilities)
            {
                var containedAvailability = await _dishShopContext.ShopsAvailabilities.SingleOrDefaultAsync(shopAvailability =>
                    shopAvailability.ProductId == availability.ProductId &&
                    shopAvailability.ShopId == availability.ShopId);

                if (containedAvailability != null)
                {
                    containedAvailability.Amount += availability.Amount;
                }
                else
                {
                    await _dishShopContext.ShopsAvailabilities.AddAsync(availability);
                }
            }
        }

        public async Task CancelSupplyAsync(int id)
        {
            var supplyToBeCanceled = await _dishShopContext.Supplies
                .SingleOrDefaultAsync(supply => supply.Id == id);

            supplyToBeCanceled.DateCanceled = DateTime.Now; 
            supplyToBeCanceled.CancellerId = 27; // HERE!!!!!!!!
            supplyToBeCanceled.StatusId = 3;

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
