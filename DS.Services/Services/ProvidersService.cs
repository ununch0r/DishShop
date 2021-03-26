using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DS.Domain.Entities.Entities;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.ProviderDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DS.Services.Services
{
    public class ProvidersService : IProvidersService
    {
        private readonly DishShopContext _dishShopContext;
        private readonly IMapper _mapper;

        public ProvidersService(IMapper mapper, DishShopContext dishShopContext)
        {
            _mapper = mapper;
            _dishShopContext = dishShopContext;
        }

        public async Task<ProviderDTO> CreateProviderAsync(CreateProviderDTO createProviderDTO)
        {
            var providerEntity = _mapper.Map<Provider>(createProviderDTO);

            await _dishShopContext.AddAsync(providerEntity);
            await _dishShopContext.SaveChangesAsync();

            var createdEntity = await _dishShopContext.Providers
                .Include(provider => provider.City)
                    .ThenInclude(city => city.Country)
                .AsNoTracking()
                .SingleOrDefaultAsync(provider => provider.Id == providerEntity.Id);

            var createdProviderDTO = _mapper.Map<ProviderDTO>(createdEntity);
            return createdProviderDTO;
        }

        public async Task<IEnumerable<ProviderDTO>> GetProvidersAsync()
        {
            var providers = await _dishShopContext.Providers
                .Include(provider => provider.Contracts)
                .ThenInclude(contract => contract.ContractsContents)
                .ThenInclude(contractContent => contractContent.Product)
                .AsNoTracking()
                .ToListAsync();

            var providerDTOs = _mapper.Map<IEnumerable<ProviderDTO>>(providers);
            return providerDTOs;
        }
    }
}
