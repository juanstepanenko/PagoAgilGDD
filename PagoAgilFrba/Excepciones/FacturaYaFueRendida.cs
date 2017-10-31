using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Excepciones
{
    class FacturaYaFueRendida : Exception
    {
        public FacturaYaFueRendida()
        {
            Console.WriteLine("La factura solicitada fue rendida");
        }
    }
}
