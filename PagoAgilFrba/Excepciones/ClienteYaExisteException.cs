﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Excepciones
{
    class ClienteYaExisteException : Exception
    {
        public ClienteYaExisteException()
        {
            Console.WriteLine("El documento ya existe");
        }
    }
}
