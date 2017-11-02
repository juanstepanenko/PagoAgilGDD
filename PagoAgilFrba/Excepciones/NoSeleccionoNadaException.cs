using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Excepciones
{
    class NoSeleccionoNadaException : Exception
    {
        public NoSeleccionoNadaException(String mensaje)
            : base(mensaje)
        {
        }
    }
}
