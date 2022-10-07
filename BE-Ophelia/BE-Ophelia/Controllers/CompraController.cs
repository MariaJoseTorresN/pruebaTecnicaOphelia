using AutoMapper;
using BE_Ophelia.Models.Dto;
using BE_Ophelia.Models;
using BE_Ophelia.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BE_Ophelia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : Controller
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IMapper _mapper;

        public CompraController(IMapper mapper, ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var compraLista = await _compraRepository.GetAllCompra();
                var comprasDto = _mapper.Map<IEnumerable<CompraDto>>(compraLista);
                return Ok(comprasDto);
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
                var compra = await _compraRepository.GetByIdCompra(id);
                if (compra == null)
                {
                    return NotFound();
                }
                var compraDto = _mapper.Map<CompraDto>(compra);
                return Ok(compraDto);
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
                var compra = await _compraRepository.GetByIdCompra(id);
                if (compra == null)
                {
                    return NotFound();
                }

                await _compraRepository.DeleteCompra(compra);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CompraDto compraDto)
        {
            try
            {
                var compra = _mapper.Map<Compra>(compraDto);
                compra = await _compraRepository.CreateCompra(compra);
                var buyDto = _mapper.Map<CompraDto>(compra);
                return CreatedAtAction("Get", new { compraId = buyDto.compraId }, compraDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CompraDto compraDto)
        {
            try
            {
                var compra = _mapper.Map<Compra>(compraDto);
                var compraA = await _compraRepository.GetByIdCompra(id);
                if (compraA == null)
                {
                    return NotFound();
                }
                await _compraRepository.UpdateCompra(compra);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
