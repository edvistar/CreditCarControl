using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CreditCarControl.Models
{
    public partial class Compra
    {
        public long Id { get; set; }
        public DateTime? Fecha { get; set; }
        public long? IdDetalle { get; set; }
    }
}
