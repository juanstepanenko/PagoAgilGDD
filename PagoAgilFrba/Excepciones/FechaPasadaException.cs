using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Excepciones
{
    class FechaPasadaException : Exception
    {
        public FechaPasadaException()
        {
            Console.WriteLine("La factura esta vencida");
        }
    }
}  
