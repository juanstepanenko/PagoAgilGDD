using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PagoAgilFrba.Excepciones;

namespace PagoAgilFrba.Objetos
{
    class Devolucion : Objeto, Comunicable
    {
        private Decimal id;
        private DateTime fecha_devo;
        private String factura;
        private String motivo;
       

        /************* Getters y Setters **************/
        public void setIdPago(Decimal id)
        {
            this.id = id;
        }

        public Decimal getIdPago()
        {
            return this.id;
        }

        public void setFechaDevo(DateTime fecha_devo)
        {
            if (fecha_devo.Equals(DateTime.MinValue))
                throw new CampoVacioException("Fecha devolucion");

            this.fecha_devo = fecha_devo;
        }

        public DateTime getFechaDevolucion()
        {
            return this.fecha_devo;
        }

        public void setFactura(String factura)
        {
            if (factura.Equals(null))
                throw new CampoVacioException("Factura");

            this.factura = factura;
        }

        public String getFactura()
        {
            return this.factura;
        }

        
        public void setMotivo(String motivo)
        {
            this.motivo = motivo;
        }

        public String getMotivo()
        {
            return this.motivo;
        }

       
        /********** Interfaz Comunicable ***********/

        public string GetQueryCrear()
        {
            return "AMBDA.crear_devolucion";
        }

        string Comunicable.GetQueryModificar()
        {
            return "";
        }

        public string GetQueryObtener()
        {
            return "";
        }

       
        
        public void CargarInformacion(SqlDataReader reader) //el reader lee filas de la DB
        {
            //this.id = Convert.ToDecimal(reader["regi_id"]);
            this.fecha_devo = Convert.ToDateTime(reader["devo_fecha"]);
            this.factura = Convert.ToString(reader["devo_factura"]);
            this.motivo = Convert.ToString(reader["devo_motivo"]);
            }

        public IList<System.Data.SqlClient.SqlParameter> GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Clear();
            //parametros.Add(new SqlParameter("@id", this.id));
            parametros.Add(new SqlParameter("@fecha_devo", this.fecha_devo));
            parametros.Add(new SqlParameter("@factura", this.factura));
            parametros.Add(new SqlParameter("@motivo", this.motivo));
            return parametros;
        }
    }
}
