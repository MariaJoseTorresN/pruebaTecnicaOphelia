using Microsoft.AspNetCore.Mvc;
using WSOphelia.Models.Dto;
using WSOphelia.Services.impl;

namespace WSOphelia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class ClienteController : ControllerBase
    {
        private ImplClienteService _implClienteService;
        private ClienteDto _ClienteDto;
    }

}
