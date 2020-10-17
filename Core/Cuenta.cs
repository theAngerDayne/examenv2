using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Cuenta
    {
        public int Id { get; set; }
        public TipoCuenta TipoCuenta { get; set; } = TipoCuenta.CORRIENTE;
        public DateTime FechaApertura { get; set; } = DateTime.Now;
        public decimal SaldoInicial { get; set; } = 0;
        public decimal Saldo { get; set; } = 0;
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public bool IsActive { get; set; } = true;

        public List<Cuenta> Cuentas { get; set; }
 
    }

    public enum TipoCuenta
    {
        CORRIENTE, AHORRO, VISTA
    }
}