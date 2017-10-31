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
        private Decimal factura;
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

        public DateTime getFechaDevolucion()
        {
            return this.fecha_devo;
        }

        public void setFactura(Decimal factura)
        {
            if (factura.Equals(null))
                throw new CampoVacioException("Factura");

            this.factura = factura;
        }

        public Decimal getFactura()
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
/*
        string Comunicable.GetQueryModificar()
        {
            return "UPDATE AMBDA.RegistroPago SET clie_nombre = @nombre, clie_apellido = @apellido, clie_direc_id = @direccion_id, clie_fecha_nacimiento = @fecha_nacimiento, clie_mail = @mail, clie_telefono = @telefono, clie_habilitado = @habilitado WHERE clie_dni = @dni";
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM AMBDA.RegistroPago WHERE regi_id = @id";
        }

        public string GetQueryObtenerConFactura()
        {
            return "SELECT * FROM AMBDA.RegistroPago r join AMBDA.FacturaxPago p on (r.regi_id = p.regi_id) WHERE r.regi_id = @idFactura";
        }
        */
        public void CargarInformacion(SqlDataReader reader) //el reader lee filas de la DB
        {
            //this.id = Convert.ToDecimal(reader["regi_id"]);
            this.fecha_devo = Convert.ToDateTime(reader["devo_fecha"]);
            this.factura = Convert.ToDecimal(reader["devo_factura"]);
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
