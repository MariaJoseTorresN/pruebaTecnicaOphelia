using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSOphelia.Models.Dto;
using WSOphelia.Models;
using WSOphelia.Services.impl;

namespace WSOphelia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private ImplFacturaService _implFacturaService;
        private IMapper mapper;
        protected RespuestaDTO _respuestaDTO;

        public FacturaController(ImplFacturaService _implFacturaService, Mapper mapper)
        {
            this._implFacturaService = _implFacturaService;
            this.mapper = mapper;
            _respuestaDTO = new RespuestaDTO();
        }


        [HttpGet]
        public ActionResult<IEnumerable<FacturaDto>> GetAll()
        {
            try
            {
                List<FacturaDto> facturaDtos = new List<FacturaDto>();
                List<Factura> facturas = _implFacturaService.getAll();
                facturaDtos = mapper.Map<List<FacturaDto>>(facturas);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = facturaDtos;
                _respuestaDTO.Message = "Lista de facturas.";
                return Ok(_respuestaDTO);
            }
            catch (Exception ex)
            {
                _respuestaDTO.Ok = false;
                _respuestaDTO.Message = ex.Message;
                _respuestaDTO.Errors = new List<string> { ex.ToString() };
                return BadRequest(_respuestaDTO);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<FacturaDto>> FindById(int id)
        {
            try
            {
                var factura = _implFacturaService.findById(id);
                if (factura == null)
                {
                    _respuestaDTO.Ok = false;
                    _respuestaDTO.Message = "No se encuentra factura con ese id, vuelva a revisar";
                    return NotFound(_respuestaDTO);
                }
                var facturaDto = mapper.Map<FacturaDto>(factura);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = facturaDto;
                _respuestaDTO.Message = "Factura encontrada";
                return Ok(_respuestaDTO);
            }
            catch (Exception ex)
            {
                _respuestaDTO.Ok = false;
                _respuestaDTO.Message = ex.Message;
                _respuestaDTO.Errors = new List<string> { ex.ToString() };
                return BadRequest(_respuestaDTO);
            }
        }

        [HttpPost]
        public ActionResult<FacturaDto> Create([FromBody] FacturaDto facturaDto)
        {
            try
            {
                var factura = mapper.Map<Factura>(facturaDto);
                if (_implFacturaService.findById(factura.FacturaId) != null)
                {
                    _respuestaDTO.Ok = false;
                    _respuestaDTO.Message = "Factura existente, revice la id";
                    return BadRequest(_respuestaDTO);
                }
                factura = _implFacturaService.create(factura);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = facturaDto;
                _respuestaDTO.Message = "Factura creada";
                return CreatedAtAction("GetFactura", new { id = factura.FacturaId }, _respuestaDTO);
            }
            catch (Exception ex)
            {
                _respuestaDTO.Ok = false;
                _respuestaDTO.Message = ex.Message;
                _respuestaDTO.Errors = new List<string> { ex.ToString() };
                return BadRequest(_respuestaDTO);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<FacturaDto> Update([FromBody] FacturaDto facturaDto, int id)
        {
            try
            {
                var factura = mapper.Map<Factura>(facturaDto);
                factura = _implFacturaService.update(factura);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = facturaDto;
                _respuestaDTO.Message = "Factura actualizada";
                return Ok(_respuestaDTO);
            }
            catch (Exception ex)
            {
                _respuestaDTO.Ok = false;
                _respuestaDTO.Message = ex.Message;
                _respuestaDTO.Errors = new List<string> { ex.ToString() };
                return BadRequest(_respuestaDTO);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                bool delete = _implFacturaService.deleteById(id);
                if (delete)
                {
                    _respuestaDTO.Ok = true;
                    _respuestaDTO.Result = delete;
                    _respuestaDTO.Message = "Factura eliminada";
                    return Ok(_respuestaDTO);
                }
                _respuestaDTO.Ok = false;
                _respuestaDTO.Result = delete;
                _respuestaDTO.Message = "No se encuentra registro";
                return Ok(_respuestaDTO);
            }
            catch (Exception ex)
            {
                _respuestaDTO.Ok = false;
                _respuestaDTO.Message = ex.Message;
                _respuestaDTO.Errors = new List<string> { ex.ToString() };
                return BadRequest(_respuestaDTO);
            }
        }
    }
}
