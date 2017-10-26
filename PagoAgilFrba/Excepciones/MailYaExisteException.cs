using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Excepciones
{
    class MailYaExisteException : Exception
    {
        public MailYaExisteException()
        {
            Console.WriteLine("El mail ya existe");
        }
    }
}
