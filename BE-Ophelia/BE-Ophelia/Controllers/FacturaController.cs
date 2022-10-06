using AutoMapper;
using BE_Ophelia.Models.Dto;
using BE_Ophelia.Models;
using BE_Ophelia.Repositories;
using BE_Ophelia.Repositories.Impl;
using Microsoft.AspNetCore.Mvc;

namespace BE_Ophelia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : Controller
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IMapper _mapper;

        public FacturaController(IMapper mapper, IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var facturasLista = await _facturaRepository.GetAllFacturas();
                var facturasDto = _mapper.Map<IEnumerable<FacturaDto>>(facturasLista);
                return Ok(facturasDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var factura = await _facturaRepository.GetByIdFactura(id);
                if (factura == null)
                {
                    return NotFound();
                }
                var facturaDto = _mapper.Map<FacturaDto>(factura);
                return Ok(facturaDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var factura = await _facturaRepository.GetByIdFactura(id);
                if (factura == null)
                {
                    return NotFound();
                }

                await _facturaRepository.DeleteFactura(factura);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(FacturaDto facturaDto)
        {
            try
            {
                var factura = _mapper.Map<Factura>(facturaDto);
                factura = await _facturaRepository.CreateFactura(factura);
                var billDto = _mapper.Map<FacturaDto>(factura);
                return CreatedAtAction("Get", new { clienteId = billDto.facturaId }, facturaDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FacturaDto facturaDto)
        {
            try
            {
                var factura = _mapper.Map<Factura>(facturaDto);
                var facturaA = await _facturaRepository.GetByIdFactura(id);
                if (facturaA == null)
                {
                    return NotFound();
                }
                await _facturaRepository.UpdateFactura(factura);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
