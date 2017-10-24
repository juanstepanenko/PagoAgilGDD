using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Excepciones
{
    class CampoVacioException : Exception
    {
        public CampoVacioException(String mensaje)
            : base(mensaje)
        {
            Console.WriteLine("Se ejecuto la excepcion");
        }
    }
}
