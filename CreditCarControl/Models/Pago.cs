using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CreditCarControl.Models
{
    public partial class Pago
    {
        public long Id { get; set; }
        public decimal? PagoMinimo { get; set; }
        public decimal? PagoTotal { get; set; }
    }
}
