using System.Collections.Generic;
using System.Threading.Tasks;
using DS.Services.DTO.DTOs.CharacteristicDTOs;
using DS.Services.DTO.DTOs.UtilityDTOs;

namespace DS.Services.Interfaces.Interfaces
{
    public interface ICharacteristicService
    {
        Task<CharacteristicDTO> CreateCharacteristicAsync(CreateCharacteristicDTO createCharacteristicDto);
        Task<IEnumerable<CharacteristicDTO>> GetCharacteristicsByCategoryIdAsync(int id);
        Task<IEnumerable<CharacteristicDTO>> GetCharacteristicsAsync();
    }
}
