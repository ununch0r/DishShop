using DS.Services.DTO.DTOs.ContractDTOs;
using System.Threading.Tasks;

namespace DS.Services.Interfaces.Interfaces
{
    public interface IContractsService
    {
        Task<ContractDTO> CreateContractAsync(CreateContractDTO createContractDTO);
    }
}
