using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using Core;
using Infrastructure.Data;
using Infrastructure.Dtos.Cuenta;
using Microsoft.EntityFrameworkCore;

namespace API.Services.CuentaService
{
    public class CuentaService : ICuentaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CuentaService(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public async Task<ServiceResponse<List<GetCuentaDto>>> AddCuenta(AddCuentaDto newCuenta)
        {
            ServiceResponse<List<GetCuentaDto>> serviceResponse = new ServiceResponse<List<GetCuentaDto>>();
            
            var dbCliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == newCuenta.IdCliente);

            if (dbCliente == null)
            {
                 serviceResponse.Success = false;
                    serviceResponse.Message = "Cliente no encontrado.";
                    return serviceResponse;
            }

            Cuenta cuenta = _mapper.Map<Cuenta>(newCuenta);

            cuenta.Cliente = dbCliente;

            await _context.Cuentas.AddAsync(cuenta);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Cuentas.Select(c => _mapper.Map<GetCuentaDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCuentaDto>>> DesactivarCuenta(int id)
        {
            ServiceResponse<List<GetCuentaDto>> serviceResponse = new ServiceResponse<List<GetCuentaDto>>();
            try
            {
                var cuenta = await _context.Cuentas.FirstOrDefaultAsync(c => c.Id == id);

                if(cuenta != null)
                {
                    cuenta.IsActive = false;
                    _context.Cuentas.Update(cuenta);
                    await _context.SaveChangesAsync();
                    serviceResponse.Message = "Cuenta desactivada";
                    serviceResponse.Data = (_context.Cuentas.Where(c => c.IsActive == false).Select(c => _mapper.Map<GetCuentaDto>(c))).ToList();
                }
                else
                {
                    serviceResponse.Message = "Cuenta no encontrada";
                    serviceResponse.Success = false;
                }
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCuentaDto>>> GetAllCuentas()
        {
            ServiceResponse<List<GetCuentaDto>> serviceResponse = new ServiceResponse<List<GetCuentaDto>>();

            List<Cuenta> dbCuentas = await _context.Cuentas.Include(c => c.Cliente).ToListAsync();

            serviceResponse.Data = (dbCuentas.Select(c => _mapper.Map<GetCuentaDto>(c))).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCuentaDto>> GetCuentaById(int id)
        {
            ServiceResponse<GetCuentaDto> serviceResponse = new ServiceResponse<GetCuentaDto>();
            var dbCuenta = await _context.Cuentas.Include(c => c.Cliente).FirstOrDefaultAsync(c => c.Id == id);

            serviceResponse.Data = _mapper.Map<GetCuentaDto>(dbCuenta);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCuentaDto>>> GetCuentasByIdCliente(int idCliente)
        {
            ServiceResponse<List<GetCuentaDto>> serviceResponse = new ServiceResponse<List<GetCuentaDto>>();

            List<Cuenta> dbCuentas = await _context.Cuentas.Include(c => c.Cliente)
            .Where(i => i.Cliente.Id == idCliente).ToListAsync();

            serviceResponse.Data = (dbCuentas.Select(c => _mapper.Map<GetCuentaDto>(c))).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCuentaDto>>> GetCuentasByTipo(Core.TipoCuenta tipoCuenta)
        {
             ServiceResponse<List<GetCuentaDto>> serviceResponse = new ServiceResponse<List<GetCuentaDto>>();             

            List<Cuenta> dbCuentas = await _context.Cuentas.Include(c => c.Cliente).Where(t => t.TipoCuenta.
            Equals(tipoCuenta)).ToListAsync();

            serviceResponse.Data = (dbCuentas.Select(c => _mapper.Map<GetCuentaDto>(c))).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCuentaDto>> UpdateCuenta(UpdateCuentaDto updatedCuenta)
        {
            ServiceResponse<GetCuentaDto> serviceResponse = new ServiceResponse<GetCuentaDto>();
            try
            {
                Cuenta cuenta = await _context.Cuentas.Include(c => c.Cliente)
                .FirstOrDefaultAsync(c => c.Id == updatedCuenta.Id);

                cuenta.TipoCuenta = (Core.TipoCuenta)updatedCuenta.TipoCuenta;                               
                cuenta.Saldo = updatedCuenta.Saldo;
                cuenta.SaldoInicial = updatedCuenta.SaldoInicial;

                _context.Cuentas.Update(cuenta);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetCuentaDto>(cuenta);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }
    }
}