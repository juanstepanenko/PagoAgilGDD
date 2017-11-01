using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace PagoAgilFrba.Excepciones
    {
        class EmpresaNoExisteException : Exception
        {
            public EmpresaNoExisteException()
            {
                Console.WriteLine("La empresa no esta cargado en el sistema");
            }
        }
    }
