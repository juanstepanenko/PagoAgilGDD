using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Excepciones
{
    class CantidadNulaException : Exception
    {
         public CantidadNulaException(String mensaje)
            : base(mensaje)
        {
            Console.WriteLine("Se ejecuto la excepcion");
        }
    }
}
