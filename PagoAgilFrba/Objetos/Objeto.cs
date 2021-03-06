﻿using System;
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
        public Boolean esCuit(String cuit)
        {
            if (cuit.Length < 14) return false;
            String primerosDosNumeros = cuit.Substring(0, 2);
            String primerGuion = cuit.Substring(2, 1);
            String ochoNumeros = cuit.Substring(3, 8);
            String segundoGuion = cuit.Substring(11, 1);
            String segundosDosNumeros = cuit.Substring(12, 2);

            return this.esNumero(primerosDosNumeros) && primerGuion == "-" && this.esNumero(ochoNumeros) && segundoGuion == "-" && this.esNumero(segundosDosNumeros);
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

        public String crearDireccion(String calleNro, String piso, String depto, String localidad)
        {
            if (piso == "")
            {
                return calleNro + " " + depto + ", " + localidad;
            }
            else
            {
                return calleNro + " " + piso + "º " + depto + ", " + localidad;
            }
        }
        
    }
}
