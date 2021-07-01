using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CreditCarControl.Models
{
    public partial class Tarjeta
    {
        public long Id { get; set; }
        public string NumeroTarjeta { get; set; }
        public decimal CupoDisponible { get; set; }
        public decimal CupoAvance { get; set; }
        public DateTime FechaCorte { get; set; }
        public DateTime FechaCobro { get; set; }
        public long IdCompra { get; set; }
        public long IdPago { get; set; }
    }
}
