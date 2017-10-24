using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Objetos
{
    class Objeto
    {
        public Boolean esNumero(String numString)
        {
            long number1 = 0;
            return long.TryParse(numString, out number1); // devuelve true si pudo convertirlo, es decir, es numero
        }

        public Boolean esDouble(String numString)
        {
            Double number1 = 0;
            return Double.TryParse(numString, out number1); // devuelve true si pudo convertirlo, es decir, es numero
        }

        public Object siEsNuloDevolverDBNull(String campo)
        {
            if (campo == "")
            {
                return DBNull.Value;
            }
            else
            {
                return campo;
            }
        }
    }
}
