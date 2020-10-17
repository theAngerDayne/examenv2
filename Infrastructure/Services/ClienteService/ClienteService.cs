using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Infrastructure.Data;
using Infrastructure.Dtos.Cliente;
using Microsoft.EntityFrameworkCore;

namespace API.Services.ClienteService
{
    public class ClienteService : IClienteService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ClienteService(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public async Task<ServiceResponse<List<GetClienteDto>>> AddCliente(AddClienteDto newCliente)
        {
            ServiceResponse<List<GetClienteDto>> serviceResponse = new ServiceResponse<List<GetClienteDto>>();

            Cliente cliente = _mapper.Map<Cliente>(newCliente);


            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Clientes.Select(c => _mapper.Map<GetClienteDto>(c)
            )).ToList();
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetClienteDto>>> DeleteCliente(int id)
        {
            ServiceResponse<List<GetClienteDto>> serviceResponse = new ServiceResponse<List<GetClienteDto>>();
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

                if (cliente != null)
                {
                    _context.Clientes.Remove(cliente);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = (_context.Clientes.Select(c => _mapper.Map<GetClienteDto>(c))).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Cliente no encontrado";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetClienteDto>>> GetAllClientes()
        {
            ServiceResponse<List<GetClienteDto>> serviceResponse = new ServiceResponse<List<GetClienteDto>>();
            List<Cliente> dbClientes = await _context.Clientes.ToListAsync();

            serviceResponse.Data = dbClientes.Select(c => _mapper.Map<GetClienteDto>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<int>> GetCantidadClientes()
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();

            var dbClientes = await _context.Clientes.CountAsync();

            serviceResponse.Message = "Cantidad de clientes: " + dbClientes;
            serviceResponse.Data = dbClientes;

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetClienteDto>> GetClienteById(int id)
        {
            ServiceResponse<GetClienteDto> serviceResponse = new ServiceResponse<GetClienteDto>();

            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            serviceResponse.Data = _mapper.Map<GetClienteDto>(cliente);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetClienteDto>>> GetClientesByName(string nombre)
        {
            ServiceResponse<List<GetClienteDto>> serviceResponse = new ServiceResponse<List<GetClienteDto>>();

            var dbClientes = await _context.Clientes
            .Where(c => c.Nombre.ToLower().Contains(nombre.ToLower()))
            .ToListAsync();

            serviceResponse.Data = (dbClientes.Select(c => _mapper.Map<GetClienteDto>(c))).ToList();

            return serviceResponse;

        }

        public async Task<ServiceResponse<GetClienteDto>> UpdateCliente(UpdateClienteDto updatedCliente)
        {
            ServiceResponse<GetClienteDto> serviceResponse = new ServiceResponse<GetClienteDto>();

            try
            {
                Cliente cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == updatedCliente.Id);

                cliente.Rut = updatedCliente.Rut;
                cliente.Nombre = updatedCliente.Nombre;
                cliente.Apellidos = updatedCliente.Apellidos;
                cliente.FechaNacimiento = updatedCliente.FechaNacimiento;
                cliente.Direccion = updatedCliente.Direccion;
                cliente.Telefono = updatedCliente.Telefono;

                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetClienteDto>(cliente);


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