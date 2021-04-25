using System.Collections.Generic;
using System.Threading.Tasks;
using DS.Services.DTO.DTOs.EmployeeDTOs;
using DS.Services.DTO.DTOs.PositionDTOs;

namespace DS.Services.Interfaces.Interfaces
{
    public  interface IEmployeesService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync();
        Task<IEnumerable<EmployeeDTO>> GetEmployeesByShopIdAsync(int id);
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task<EmployeeDTO> CreateEmployeeAsync(CreateEmployeeDTO createEmployeeDTO);
        Task PromoteEmployeeByIdAsync(int id);
        Task FireEmployeeByIdAsync(int id);
        Task<IEnumerable<PositionDTO>> GetAllPositionsAsync();
        Task<EmployeeDTO> AuthenticateUser(string email, string password);
    }
}
