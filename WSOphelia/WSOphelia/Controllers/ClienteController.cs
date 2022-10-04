﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WSOphelia.Models;
using WSOphelia.Models.Dto;
using WSOphelia.Services.impl;

namespace WSOphelia.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    
    public class ClienteController : ControllerBase
    {
        private ImplClienteService _implClienteService;
        private IMapper mapper;
        protected RespuestaDTO _respuestaDTO;

        public ClienteController(ImplClienteService _implClienteService, Mapper mapper) { 
            this._implClienteService = _implClienteService;
            this.mapper = mapper;
            _respuestaDTO = new RespuestaDTO();
        }


        [HttpGet]
        public ActionResult<IEnumerable<ClienteDto>> GetAll()
        {
            try
            {
                List<ClienteDto> clientesDto = new List<ClienteDto>();
                List<Cliente> clientes = _implClienteService.getAll();
                clientesDto = mapper.Map<List<ClienteDto>>(clientes);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = clientesDto;
                _respuestaDTO.Message = "Lista de clientes.";
                return Ok(_respuestaDTO);
            }
            catch (Exception ex) { 
                _respuestaDTO.Ok = false;
                _respuestaDTO.Message = ex.Message;
                _respuestaDTO.Errors = new List<string> { ex.ToString() };
                return BadRequest(_respuestaDTO);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ClienteDto>> FindById(int id)
        {
            try
            {
                var cliente = _implClienteService.findById(id);
                if (cliente == null)
                {
                    _respuestaDTO.Ok = false;
                    _respuestaDTO.Message = "No se encuentra cliente con ese id, vuelva a revisar";
                    return NotFound(_respuestaDTO);
                }
                var clienteDto = mapper.Map<ClienteDto>(cliente);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = clienteDto;
                _respuestaDTO.Message = "Cliente encontrado";
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
        public ActionResult<ClienteDto> Create([FromBody] ClienteDto clienteDto)
        {
            try
            {
                var cliente = mapper.Map<Cliente>(clienteDto);
                if (_implClienteService.findById(cliente.ClienteId) != null)
                {
                    _respuestaDTO.Ok = false;
                    _respuestaDTO.Message = "Cliente existente, revice la id";
                    return BadRequest(_respuestaDTO);
                }
                cliente = _implClienteService.create(cliente);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = clienteDto;
                _respuestaDTO.Message = "Cliente creado";
                return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, _respuestaDTO);
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
        public ActionResult<ClienteDto> Update([FromBody] ClienteDto clienteDto, int id)
        {
            try
            {
                var cliente = mapper.Map<Cliente>(clienteDto);
                cliente = _implClienteService.update(cliente);
                _respuestaDTO.Ok = true;
                _respuestaDTO.Result = clienteDto;
                _respuestaDTO.Message = "Cliente actualizado";
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
                bool delete = _implClienteService.deleteById(id);
                if (delete)
                {
                    _respuestaDTO.Ok = true;
                    _respuestaDTO.Result = delete;
                    _respuestaDTO.Message = "Cliente eliminado";
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
