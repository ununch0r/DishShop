using System.Collections.Generic;
using System.Threading.Tasks;
using DS.Services.DTO.DTOs.EmployeeDTOs;

namespace DS.Services.Interfaces.Interfaces
{
    public  interface IEmployeesService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync();
        Task<IEnumerable<EmployeeDTO>> GetEmployeesByShopIdAsync(int id);
        Task<EmployeeDTO> CreateEmployeeAsync(CreateEmployeeDTO createEmployeeDTO);
        Task PromoteEmployeeByIdAsync(int id);
    }
}
