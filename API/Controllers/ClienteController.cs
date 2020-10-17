using System.Collections.Generic;
using System.Threading.Tasks;
using API.Services.ClienteService;
using Core;
using Infrastructure.Dtos.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _clienteService.GetAllClientes());
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCliente(AddClienteDto newCliente)
        {
            return Ok(await _clienteService.AddCliente(newCliente));
        }

        [HttpGet("GetCantidadClientes")]
        public async Task<IActionResult> GetCantidadClientes()
        {
            return Ok(await _clienteService.GetCantidadClientes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _clienteService.GetClienteById(id));
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            return Ok(await _clienteService.GetClientesByName(name));
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateCliente(UpdateClienteDto updateCliente)
        {
            ServiceResponse<GetClienteDto> response = await _clienteService.UpdateCliente(updateCliente);
            
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetClienteDto>> response = await _clienteService.DeleteCliente(id);
            
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}