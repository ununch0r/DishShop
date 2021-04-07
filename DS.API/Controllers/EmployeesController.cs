using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using DS.API.ViewModels.ViewModels.EmployeeViewModels;
using DS.Services.DTO.DTOs.EmployeeDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DS.API.Controllers
{
    [Route("api/employees")]
    [Produces("application/json")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeesService employeesService, IMapper mapper)
        {
            _employeesService = employeesService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync(
            [FromBody][Required] CreateEmployeeViewModel createEmployeeViewModel
        )
        {
            var createEmployeeDTO = _mapper.Map<CreateEmployeeDTO>(createEmployeeViewModel);

            var createdEmployeeDTO = await _employeesService.CreateEmployeeAsync(createEmployeeDTO);
            var createdEmployeeViewModel = _mapper.Map<EmployeeViewModel>(createdEmployeeDTO);

            return Ok(createdEmployeeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var employeeDTOs = await _employeesService.GetEmployeesAsync();

            var employeeViewModels = _mapper.Map<IEnumerable<EmployeeViewModel>>(employeeDTOs);

            return Ok(employeeViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeesByShopIdAsync(int id)
        {
            var employeeDTOs = await _employeesService.GetEmployeesByShopIdAsync(id);

            var employeeViewModels = _mapper.Map<IEnumerable<EmployeeViewModel>>(employeeDTOs);

            return Ok(employeeViewModels);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> PromoteEmployeeByIdAsync(int id)
        {
            await _employeesService.PromoteEmployeeByIdAsync(id);

            return Ok();
        }
    }
}