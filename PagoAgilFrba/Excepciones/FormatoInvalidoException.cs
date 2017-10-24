using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Excepciones
{
    class FormatoInvalidoException : Exception
    {
        public FormatoInvalidoException(String mensaje)
            : base(mensaje)
        {

        }
    }
}
