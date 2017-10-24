using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PagoAgilFrba.Objetos
{
    interface Comunicable
    {
        String GetQueryCrear();
        String GetQueryModificar();
        String GetQueryObtener();
        void CargarInformacion(SqlDataReader reader);
        IList<SqlParameter> GetParametros();
    }
}
