using System;
using Infrastructure.Dtos.Cliente;

namespace Infrastructure.Dtos.Cuenta
{
    public class AddCuentaDto
    {
        public TipoCuenta TipoCuenta { get; set; } = TipoCuenta.VISTA;        
        public decimal SaldoInicial { get; set; } = 0;
        public decimal Saldo { get; set; } = 0;
        public int IdCliente { get; set; }
        public Core.Cliente Cliente { get; set; }
        public bool IsActive { get; set; } = true;
        public string NombreUsuario { get; set; }
    }
}