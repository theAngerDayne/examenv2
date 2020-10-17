using System.Collections.Generic;
using System.Threading.Tasks;
using API.Services.CuentaService;
using Core;
using Infrastructure.Dtos.Cuenta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;
        public CuentaController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCuenta(AddCuentaDto newCuenta)
        {
            return Ok(await _cuentaService.AddCuenta(newCuenta));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _cuentaService.GetAllCuentas());
        }

        [HttpPut("DesactivarCuenta/{id}")]
        public async Task<IActionResult> DesactivarCuenta(int id)
        {
            ServiceResponse<List<GetCuentaDto>> response = await _cuentaService.DesactivarCuenta(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _cuentaService.GetCuentaById(id));
        }

        [HttpGet("GetCuentasByIdCliente/{id}")]
        public async Task<IActionResult> GetCuentasByIdCliente(int id)
        {
            return Ok(await _cuentaService.GetCuentasByIdCliente(id));
        }

          [HttpGet("GetCuentasByTipo/{id}")]
        public async Task<IActionResult> GetCuentasByTipo(Core.TipoCuenta id)
        {
            return Ok(await _cuentaService.GetCuentasByTipo(id));
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateCliente(UpdateCuentaDto updateCuenta)
        {
            ServiceResponse<GetCuentaDto> response = await _cuentaService.UpdateCuenta(updateCuenta);
            
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}