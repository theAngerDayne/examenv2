using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Infrastructure.Dtos.Cliente;

namespace API.Services.ClienteService
{
    public interface IClienteService
    {
        Task<ServiceResponse<List<GetClienteDto>>> GetAllClientes();
        Task<ServiceResponse<List<GetClienteDto>>> AddCliente(AddClienteDto newCliente);
        Task<ServiceResponse<GetClienteDto>> UpdateCliente(UpdateClienteDto updatedCliente);
        Task<ServiceResponse<List<GetClienteDto>>> DeleteCliente(int id);

        Task<ServiceResponse<GetClienteDto>> GetClienteById(int id);
        Task<ServiceResponse<List<GetClienteDto>>> GetClientesByName(string nombre);
        Task<ServiceResponse<int>> GetCantidadClientes();

    }
}