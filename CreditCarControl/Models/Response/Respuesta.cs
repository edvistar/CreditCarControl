﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CreditCarControl.Models.Response
{
    public class Respuesta
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }

        public Respuesta()
        {
            this.Exito = 0;
        }
    }
}
