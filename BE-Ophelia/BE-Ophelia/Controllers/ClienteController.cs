using AutoMapper;
using BE_Ophelia.Models;
using BE_Ophelia.Models.Dto;
using BE_Ophelia.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_Ophelia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IMapper mapper, IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientesLista = await _clienteRepository.GetAllClientes();
                var clientesDto = _mapper.Map<IEnumerable<ClienteDto>>(clientesLista);
                return Ok(clientesDto);
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
                var cliente = await _clienteRepository.GetByIdCliente(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                var clienteDto = _mapper.Map<ClienteDto>(cliente);
                return Ok(clienteDto);
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
                var cliente = await _clienteRepository.GetByIdCliente(id);
                if (cliente == null)
                {
                    return NotFound();
                }

                await _clienteRepository.DeleteCliente(cliente);
                
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteDto clienteDto)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDto);
                cliente = await _clienteRepository.CreateCliente(cliente);
                var clientDto = _mapper.Map<ClienteDto>(cliente);
                return CreatedAtAction("Get", new { clienteId = clientDto.clienteId }, clienteDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClienteDto clienteDto)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDto);
                var clienteA = await _clienteRepository.GetByIdCliente(id);
                if (clienteA == null)
                {
                    return NotFound();
                }
                await _clienteRepository.UpdateCliente(cliente);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
