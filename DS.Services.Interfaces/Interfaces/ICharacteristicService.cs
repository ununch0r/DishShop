using System.Collections.Generic;
using System.Threading.Tasks;
using DS.Services.DTO.DTOs.CharacteristicDTOs;

namespace DS.Services.Interfaces.Interfaces
{
    public interface ICharacteristicService
    {
        Task<CharacteristicDTO> CreateCharacteristicAsync(CreateCharacteristicDTO createCharacteristicDto);
        Task<IEnumerable<CharacteristicDTO>> GetCharacteristicsByCategoryIdAsync(int id);
    }
}
