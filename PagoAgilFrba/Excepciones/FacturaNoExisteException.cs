﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Excepciones
{
    class FacturaNoExisteException : Exception
    {
        public FacturaNoExisteException(String mensaje)
            : base(mensaje)
        {
            Console.WriteLine("La factura solicitada no existe");
        }
    }
}
