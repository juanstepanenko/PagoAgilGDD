using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace PagoAgilFrba.Excepciones
    {
        class ClienteNoExisteException : Exception
        {
            public ClienteNoExisteException()
            {
                Console.WriteLine("El cliente no esta cargado en el sistema");
            }
        }
    }
