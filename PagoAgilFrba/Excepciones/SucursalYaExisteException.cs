using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Excepciones
{
    class SucursalYaExisteExcepcion : Exception
    {
        public void SucursalYaExisteException()
        {
            Console.WriteLine("El documento ya existe");
        }
    }
}
