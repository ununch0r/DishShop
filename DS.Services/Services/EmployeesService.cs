using AutoMapper;
using DS.Domain.Entities.Entities;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.EmployeeDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DS.Services.DTO.DTOs.PositionDTOs;

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
                .Where(employee => employee.IsFired == false)
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
                .Where(employee => employee.ShopId == id && employee.IsFired == false)
                .ToListAsync();

            var employeeDTOs = _mapper.Map<IEnumerable<EmployeeDTO>>(employeeEntities);
            return employeeDTOs;
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var employeeEntities = await _dishShopContext.Employees
                .Include(employee => employee.Position)
                .Include(employee => employee.Shop)
                .AsNoTracking()
                .SingleOrDefaultAsync(employee => employee.Id == id);

            var employeeDTOs = _mapper.Map<EmployeeDTO>(employeeEntities);
            return employeeDTOs;
        }

        public async Task<EmployeeDTO> CreateEmployeeAsync(CreateEmployeeDTO createEmployeeDTO)
        {
            var employeeEntity = _mapper.Map<Employee>(createEmployeeDTO);
            employeeEntity.IsFired = false;

            employeeEntity.PasswordHash = GetHashedPassword(employeeEntity.PasswordHash);

            if (createEmployeeDTO.PositionId == 2)
            {
                var manager = await _dishShopContext.Employees
                    .SingleOrDefaultAsync(employee => employee.Position.Id == 2
                                                      && employee.ShopId == createEmployeeDTO.ShopId);

                if (manager != null)
                {
                    manager.PositionId = 1;
                }
            }

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

        private string GetHashedPassword(string passwordHash)
        {
            var data = Encoding.ASCII.GetBytes(passwordHash);
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(data);
            var hashedPassword = ASCIIEncoding.ASCII.GetString(md5data);
            return hashedPassword;
        }

        public async Task PromoteEmployeeByIdAsync(int id)
        {
            var employeeToBePromoted = await _dishShopContext.Employees
                .SingleOrDefaultAsync(employee => employee.Id == id);

            var manager = await _dishShopContext.Employees
                .SingleOrDefaultAsync(employee => employee.Position.Id == 2 && employee.ShopId == employeeToBePromoted.ShopId);

            manager.PositionId = 1;
            employeeToBePromoted.PositionId = 2;

            await _dishShopContext.SaveChangesAsync();
        }

        public async Task FireEmployeeByIdAsync(int id)
        {
            var employeeToBeFired = await _dishShopContext.Employees
                .SingleOrDefaultAsync(employee => employee.Id == id);
            employeeToBeFired.IsFired = true;

            await _dishShopContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PositionDTO>> GetAllPositionsAsync()
        {
            var positions = await _dishShopContext.Positions.ToListAsync();

            var positionDTOs = _mapper.Map<IEnumerable<PositionDTO>>(positions);

            return positionDTOs;
        }

        public async Task<EmployeeDTO> AuthenticateUser(string email, string password)
        {
            var user = await _dishShopContext.Employees
                .Include(user => user.Position)
                .SingleOrDefaultAsync(employee =>
                employee.Email == email && employee.PasswordHash == GetHashedPassword(password) && !employee.IsFired.Value);

            var userDto = _mapper.Map<EmployeeDTO>(user);

            return userDto;
        }
    }
}
