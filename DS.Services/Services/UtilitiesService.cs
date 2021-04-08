using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.CityDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DS.Services.Services
{
    public class UtilitiesService : IUtilitiesService
    {
        private readonly DishShopContext _dishShopContext;
        private readonly IMapper _mapper;

        public UtilitiesService(DishShopContext dishShopContext, IMapper mapper)
        {
            _dishShopContext = dishShopContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDTO>> GetAllCitiesAsync()
        {
            var cities = await _dishShopContext.Cities.AsNoTracking().ToListAsync();

            var cityDTOs = _mapper.Map<IEnumerable<CityDTO>>(cities);

            return cityDTOs;
        }
    }
}
