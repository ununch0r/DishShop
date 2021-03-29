using DS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DS.API.Controllers
{
    [Route("api/supplies")]
    [Produces("application/json")]
    [ApiController]
    public class SuppliesController : ControllerBase
    {
        private readonly IProvidersService _providersService;
        private readonly IMapper _mapper;

        public SuppliesController(IProvidersService providersService, IMapper mapper)
        {
            _providersService = providersService;
            _mapper = mapper;
        }
    }
}
