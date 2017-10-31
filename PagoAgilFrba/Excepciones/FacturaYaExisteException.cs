using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Excepciones
{
    class FacturaYaExisteException : Exception
    {
         public FacturaYaExisteException()
        {
            Console.WriteLine("La factura con ese nro y empresa ya existe");
        }
    }
}
