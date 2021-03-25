using AutoMapper;
using DS.Domain.Entities.Entities;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.CharacteristicDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DS.Services.Services
{
    public class CharacteristicsService : ICharacteristicService
    {
        private readonly DishShopContext _dishShopContext;
        private readonly IMapper _mapper;

        public CharacteristicsService(DishShopContext dishShopContext, IMapper mapper)
        {
            _dishShopContext = dishShopContext;
            _mapper = mapper;
        }

        public async Task<CharacteristicDTO> CreateCharacteristicAsync(CreateCharacteristicDTO createCharacteristicDto)
        {
            var characteristicEntity = _mapper.Map<Characteristic>(createCharacteristicDto);

            await _dishShopContext.AddAsync(characteristicEntity);
            await _dishShopContext.SaveChangesAsync();

            var createdCharacteristicDTO = _mapper.Map<CharacteristicDTO>(characteristicEntity);
            return createdCharacteristicDTO;
        }

        public async Task<IEnumerable<CharacteristicDTO>> GetCharacteristicsByCategoryIdAsync(int id)
        {
            var characteristics = await _dishShopContext.Characteristics
                .Include(characteristic => characteristic.ValueType)
                .Where(characteristic =>
                    characteristic.CategoriesCharacteristics
                        .Any(categoryCharacteristic => categoryCharacteristic.CategoryId == id))
                .AsNoTracking()
                .ToListAsync();

            var characteristicDTOs = _mapper.Map<IEnumerable<CharacteristicDTO>>(characteristics);

            return characteristicDTOs;
        }
    }
}
