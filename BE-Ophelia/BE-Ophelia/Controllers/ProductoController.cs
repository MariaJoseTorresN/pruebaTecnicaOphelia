using AutoMapper;
using BE_Ophelia.Models.Dto;
using BE_Ophelia.Models;
using BE_Ophelia.Repositories;
using Microsoft.AspNetCore.Mvc;
using BE_Ophelia.Repositories.Impl;

namespace BE_Ophelia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public ProductoController(IMapper mapper, IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var productosLista = await _productoRepository.GetAllProductos();
                var productosDto = _mapper.Map<IEnumerable<ProductoDto>>(productosLista);
                return Ok(productosDto);
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
                var producto = await _productoRepository.GetByIdProducto(id);
                if (producto == null)
                {
                    return NotFound();
                }
                var productoDto = _mapper.Map<ProductoDto>(producto);
                return Ok(productoDto);
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
                var producto = await _productoRepository.GetByIdProducto(id);
                if (producto == null)
                {
                    return NotFound();
                }

                await _productoRepository.DeleteProducto(producto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductoDto productoDto)
        {
            try
            {
                var producto = _mapper.Map<Producto>(productoDto);
                producto = await _productoRepository.CreateProducto(producto);
                var productDto = _mapper.Map<ProductoDto>(producto);
                return CreatedAtAction("Get", new { productoId = productoDto.productoId }, productoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductoDto productoDto)
        {
            try
            {
                var producto = _mapper.Map<Producto>(productoDto);
                var productoA = await _productoRepository.GetByIdProducto(id);
                if (productoA == null)
                {
                    return NotFound();
                }
                await _productoRepository.UpdateProducto(producto);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
