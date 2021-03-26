using AutoMapper;
using DS.Domain.Entities.Entities;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.ContractDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.Services.Services
{
    public class ContractsService : IContractsService
    {
        private readonly DishShopContext _dishShopContext;
        private readonly IMapper _mapper;

        public ContractsService(IMapper mapper, DishShopContext dishShopContext)
        {
            _mapper = mapper;
            _dishShopContext = dishShopContext;
        }

        public async Task<ContractDTO> CreateContractAsync(CreateContractDTO createContractDTO)
        {
            var contractEntity = _mapper.Map<Contract>(createContractDTO);

            await _dishShopContext.AddAsync(contractEntity);
            await _dishShopContext.SaveChangesAsync();

            var createdContractEntity = await _dishShopContext.Contracts
                .Include(contract => contract.ContractsContents)
                    .ThenInclude(contractContent => contractContent.Product)
                        .ThenInclude(product => product.Category)
                .Include(contract => contract.ContractsContents)
                    .ThenInclude(contractContent => contractContent.Product)
                        .ThenInclude(product => product.Producer)
                            .ThenInclude(producer => producer.Country)
                .Include(contract => contract.ContractsContents)
                    .ThenInclude(contractContent => contractContent.Product)
                        .ThenInclude(product => product.ProductsCharacteristics)
                            .ThenInclude(productCharacteristic => productCharacteristic.Characteristic)
                                .ThenInclude(characteristic => characteristic.ValueType)
                .AsNoTracking()
                .SingleOrDefaultAsync(contract => contract.Id == contractEntity.Id);

            var createdContractDTO = _mapper.Map<ContractDTO>(createdContractEntity);
            return createdContractDTO;
        }

        public async Task<IEnumerable<ContractDTO>> GetContractsAsync()
        {
            var contracts = await _dishShopContext.Contracts
                .Include(contract => contract.ContractsContents)
                    .ThenInclude(contractContent => contractContent.Product)
                        .ThenInclude(product => product.Category)
                .Include(contract => contract.ContractsContents)
                    .ThenInclude(contractContent => contractContent.Product)
                        .ThenInclude(product => product.Producer)
                            .ThenInclude(producer => producer.Country)
                .Include(contract => contract.ContractsContents)
                    .ThenInclude(contractContent => contractContent.Product)
                        .ThenInclude(product => product.ProductsCharacteristics)
                            .ThenInclude(productCharacteristic => productCharacteristic.Characteristic)
                                .ThenInclude(characteristic => characteristic.ValueType)
                .Include(contract => contract.Provider)
                .AsNoTracking()
                .ToListAsync();

            var contractDTOs = _mapper.Map<IEnumerable<ContractDTO>>(contracts);
            return contractDTOs;
        }
    }
}
