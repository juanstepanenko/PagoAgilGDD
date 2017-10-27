using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoAgilFrba.Excepciones
{
    class CuitYaExisteException : Exception
    {
        public CuitYaExisteException()
        {
            Console.WriteLine("El cuit ya existe");
        }
    }
}
