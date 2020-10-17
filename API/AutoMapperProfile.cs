using AutoMapper;
using Core;
using Infrastructure.Dtos.Cliente;
using Infrastructure.Dtos.Cuenta;
using Infrastructure.Dtos.User;

namespace API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, GetClienteDto>();
            CreateMap<AddClienteDto, Cliente>();

            CreateMap<Cuenta, GetCuentaDto>();
            CreateMap<AddCuentaDto, Cuenta>();

            CreateMap<User, GetUserDto>();

        }
    }
}