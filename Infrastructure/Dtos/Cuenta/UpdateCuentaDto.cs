using System;
using Infrastructure.Dtos.Cliente;

namespace Infrastructure.Dtos.Cuenta
{
    public class UpdateCuentaDto
    {
        public int Id { get; set; }
        public TipoCuenta TipoCuenta { get; set; } = TipoCuenta.VISTA;
                
        public decimal SaldoInicial { get; set; } 
        public decimal Saldo { get; set; }         
        public Core.Cliente Cliente { get; set; }
        public bool IsActive { get; set; } 
        
    }
}