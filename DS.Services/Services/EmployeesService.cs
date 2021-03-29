using AutoMapper;
using DS.Domain.Entities.Entities;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.EmployeeDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DS.Services.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly DishShopContext _dishShopContext;
        private readonly IMapper _mapper;

        public EmployeesService(IMapper mapper, DishShopContext dishShopContext)
        {
            _mapper = mapper;
            _dishShopContext = dishShopContext;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync()
        {
            var employeeEntities = await _dishShopContext.Employees
                .Include(employee => employee.Position)
                .Include(employee => employee.Shop)
                .AsNoTracking()
                .ToListAsync();

            var employeeDTOs = _mapper.Map<IEnumerable<EmployeeDTO>>(employeeEntities);
            return employeeDTOs;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesByShopIdAsync(int id)
        {
            var employeeEntities = await _dishShopContext.Employees
                .Include(employee => employee.Position)
                .Include(employee => employee.Shop)
                .AsNoTracking()
                .Where(employee => employee.ShopId == id)
                .ToListAsync();

            var employeeDTOs = _mapper.Map<IEnumerable<EmployeeDTO>>(employeeEntities);
            return employeeDTOs;
        }

        public async Task<EmployeeDTO> CreateEmployeeAsync(CreateEmployeeDTO createEmployeeDTO)
        {
            var employeeEntity = _mapper.Map<Employee>(createEmployeeDTO);

            await _dishShopContext.AddAsync(employeeEntity);
            await _dishShopContext.SaveChangesAsync();

            var createdEmployeeEntity = await _dishShopContext.Employees
                .Include(employee => employee.Position)
                .Include(employee => employee.Shop)
                .AsNoTracking()
                .SingleOrDefaultAsync(employee => employee.Id == employeeEntity.Id);

            var employeeDTO = _mapper.Map<EmployeeDTO>(createdEmployeeEntity);
            return employeeDTO;
        }
    }
}
