using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.ProducerDTOs;
using DS.Services.DTO.DTOs.ProducerDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DS.Services.Services
{
    public class ProducersService : IProducersService
    {
        private readonly DishShopContext _dishShopContext;
        private readonly IMapper _mapper;

        public ProducersService(DishShopContext dishShopContext, IMapper mapper)
        {
            _dishShopContext = dishShopContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProducerDTO>> GetProducersAsync()
        {
            var producers = await _dishShopContext.Producers
                .Include(producer => producer.Country)
                .AsNoTracking()
                .ToListAsync();

            var producerDTOs = _mapper.Map<IEnumerable<ProducerDTO>>(producers);
            return producerDTOs;
        }
    }
}
