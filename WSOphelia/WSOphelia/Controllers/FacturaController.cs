using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSOphelia.Models.Dto;
using WSOphelia.Models;
using WSOphelia.Services.impl;
using Microsoft.EntityFrameworkCore;
using WSOphelia.Repositories;

namespace WSOphelia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        //private readonly ImplFacturaService _facturaService;
        private readonly facturacionOpheliaContext opheliaContext;
        protected RespuestaDTO _respuestaDTO;

        public FacturaController(facturacionOpheliaContext facturacionOpheliaContext)
        {
            opheliaContext = facturacionOpheliaContext;
            //_facturaService = implFacturaService;
            _respuestaDTO = new RespuestaDTO();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var facturas = await opheliaContext.Facturas.ToListAsync();
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = facturas;
                _respuestaDTO.Message = "Facturas";
                return Ok(_respuestaDTO);
            }
            catch (Exception ex)
            {
                _respuestaDTO.Ok = false;
                _respuestaDTO.Message = ex.Message;
                _respuestaDTO.Errors = new List<string> { ex.ToString()};
                return BadRequest(_respuestaDTO);
            }
        }
    }
}
