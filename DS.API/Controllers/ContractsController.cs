using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using DS.API.ViewModels.ViewModels.ContractViewModels;
using DS.Services.DTO.DTOs.ContractDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DS.API.Controllers
{
    [Route("api/contracts")]
    [Produces("application/json")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContractsService _contractsService;

        public ContractsController(IMapper mapper, IContractsService contractsService)
        {
            _mapper = mapper;
            _contractsService = contractsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContractAsync(
            [FromBody][Required] CreateContractViewModel createContractViewModel
        )
        {
            var createContractDTO = _mapper.Map<CreateContractDTO>(createContractViewModel);

            var createdContractDTO = await _contractsService.CreateContractAsync(createContractDTO);
            var createdContractViewModel = _mapper.Map<ContractViewModel>(createdContractDTO);

            return Ok(createdContractViewModel);
        }
    }
}
