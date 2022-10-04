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
    public class ProductoController : ControllerBase
    {
        private ImplProductoService _implProductoService;
        private IMapper mapper;
        protected RespuestaDTO _respuestaDTO;

        public ProductoController(ImplProductoService _implProductoService, Mapper mapper)
        {
            this._implProductoService = _implProductoService;
            this.mapper = mapper;
            _respuestaDTO = new RespuestaDTO();
        }


        [HttpGet]
        public ActionResult<IEnumerable<ProductoDto>> GetAll()
        {
            try
            {
                List<ProductoDto> productoDtos = new List<ProductoDto>();
                List<Producto> productos = _implProductoService.getAll();
                productoDtos = mapper.Map<List<ProductoDto>>(productos);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = productoDtos;
                _respuestaDTO.Message = "Lista de productos.";
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
        public ActionResult<IEnumerable<ProductoDto>> FindById(int id)
        {
            try
            {
                var producto = _implProductoService.findById(id);
                if (producto == null)
                {
                    _respuestaDTO.Ok = false;
                    _respuestaDTO.Message = "No se encuentra producto con ese id, vuelva a revisar";
                    return NotFound(_respuestaDTO);
                }
                var productoDto = mapper.Map<ProductoDto>(producto);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = productoDto;
                _respuestaDTO.Message = "Producto encontrado";
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
        public ActionResult<ProductoDto> Create([FromBody] ProductoDto productoDto)
        {
            try
            {
                var producto = mapper.Map<Producto>(productoDto);
                if (_implProductoService.findById(producto.ProductoId) != null)
                {
                    _respuestaDTO.Ok = false;
                    _respuestaDTO.Message = "Producto existente, revice la id";
                    return BadRequest(_respuestaDTO);
                }
                producto = _implProductoService.create(producto);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = productoDto;
                _respuestaDTO.Message = "Producto creado";
                return CreatedAtAction("GetProducto", new { id = producto.ProductoId }, _respuestaDTO);
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
        public ActionResult<ProductoDto> Update([FromBody] ProductoDto productoDto, int id)
        {
            try
            {
                var producto = mapper.Map<Producto>(productoDto);
                producto = _implProductoService.update(producto);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = productoDto;
                _respuestaDTO.Message = "Producto actualizado";
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
                bool delete = _implProductoService.deleteById(id);
                if (delete)
                {
                    _respuestaDTO.Ok = true;
                    _respuestaDTO.Result = delete;
                    _respuestaDTO.Message = "Producto eliminado";
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
