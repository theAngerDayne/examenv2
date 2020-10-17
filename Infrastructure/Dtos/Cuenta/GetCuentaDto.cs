using System;


namespace Infrastructure.Dtos.Cuenta
{
    public class GetCuentaDto
    {
        public int Id { get; set; }
        public TipoCuenta TipoCuenta { get; set; } 
        public DateTime FechaApertura { get; set; }
        public decimal SaldoInicial { get; set; } = 0;
        public decimal Saldo { get; set; } = 0;       
        
        public int IdCliente { get; set; }
        
        
        public Core.Cliente Cliente { get; set; }
        public bool IsActive { get; set; } = true;        

      
    }

    public enum TipoCuenta
    {
        CORRIENTE, AHORRO, VISTA
    }
    
}