using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Excepciones
{
    class FacturaNoExisteException : Exception
    {
         public FacturaNoExisteException()
        {
            Console.WriteLine("La factura con ese nro y empresa no esta cargada en el sistema");
        }
    }
}
