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
    public class CompraController : ControllerBase
    {
        private ImplCompraService _implCompraService;
        private IMapper mapper;
        protected RespuestaDTO _respuestaDTO;

        public CompraController(ImplCompraService implCompraService, Mapper mapper)
        {
            this._implCompraService = implCompraService;
            this.mapper = mapper;
            _respuestaDTO = new RespuestaDTO();
        }


        [HttpGet]
        public ActionResult<IEnumerable<CompraDto>> GetAll()
        {
            try
            {
                List<CompraDto> compraDtos = new List<CompraDto>();
                List<Compra> compras = _implCompraService.getAll();
                compraDtos = mapper.Map<List<CompraDto>>(compras);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = compraDtos;
                _respuestaDTO.Message = "Lista de compras.";
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
        public ActionResult<IEnumerable<CompraDto>> FindById(int id)
        {
            try
            {
                var compra = _implCompraService.findById(id);
                if (compra == null)
                {
                    _respuestaDTO.Ok = false;
                    _respuestaDTO.Message = "No se encuentra compra con ese id, vuelva a revisar";
                    return NotFound(_respuestaDTO);
                }
                var compraDto = mapper.Map<CompraDto>(compra);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = compraDto;
                _respuestaDTO.Message = "Compra encontrada";
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
        public ActionResult<CompraDto> Create([FromBody] CompraDto compraDto)
        {
            try
            {
                var compra = mapper.Map<Compra>(compraDto);
                if (_implCompraService.findById(compra.CompraId) != null)
                {
                    _respuestaDTO.Ok = false;
                    _respuestaDTO.Message = "Compra existente, revice la id";
                    return BadRequest(_respuestaDTO);
                }
                compra = _implCompraService.create(compra);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = compraDto;
                _respuestaDTO.Message = "Compra creada";
                return CreatedAtAction("GetCompra", new { id = compra.CompraId }, _respuestaDTO);
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
        public ActionResult<CompraDto> Update([FromBody] CompraDto compraDto, int id)
        {
            try
            {
                var compra = mapper.Map<Compra>(compraDto);
                compra = _implCompraService.update(compra);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = compraDto;
                _respuestaDTO.Message = "Compra actualizada";
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
                bool delete = _implCompraService.deleteById(id);
                if (delete)
                {
                    _respuestaDTO.Ok = true;
                    _respuestaDTO.Result = delete;
                    _respuestaDTO.Message = "Compra eliminada";
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
