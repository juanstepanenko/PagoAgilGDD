using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoAgilFrba.Excepciones
{
    class FacturaNoFueCobrada : Exception
    {
        public FacturaNoFueCobrada()
        {
            Console.WriteLine("La factura no fue cobrada, no se puede devolver");
        }
    }
}
