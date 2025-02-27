﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CreditCarControl.Models
{
    public partial class Cliente
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public long IdTarjeta { get; set; }
    }
}
