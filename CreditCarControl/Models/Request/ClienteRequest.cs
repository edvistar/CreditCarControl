using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCarControl.Models.Request
{
    public class ClienteRequest
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public long IdTarjeta { get; set; }
    }
}
