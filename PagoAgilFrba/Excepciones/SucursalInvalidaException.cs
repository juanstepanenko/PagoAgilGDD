using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Excepciones
{
    class SucursalInvalidaException : Exception
    {
        public SucursalInvalidaException()
        {
            Console.WriteLine("La sucursal no es propia de ese usuario cobrador");
        }
    }
}
