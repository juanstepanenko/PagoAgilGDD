using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagoAgilFrba.Excepciones;
using System.Data.SqlClient;

namespace PagoAgilFrba.Objetos
{
    class Item : Objeto, Comunicable
    {
        private String monto;
        private Decimal cantidad;
        private Decimal id_factura;
        
        /************* Getters y Setters **************/

        public String getMonto()
        {
            return monto;
        }

        public void setMonto(String monto)
        {
            if (monto != "" && !esNumero(monto))
                throw new FormatoInvalidoException("Monto");
            this.monto = monto;
        }

        public Decimal getCantidad()
        {
            return cantidad;
        }

        public void setCantidad(Decimal cantidad)
        {
            if (cantidad == 0)
                throw new CantidadNulaException("Cantidad");
            this.cantidad = cantidad;
        }

        public Decimal getIdFactura()
        {
            return id_factura;
        }

        public void setIdFactura(Decimal id_factura)
        {
            this.id_factura = id_factura;
        }

        /********** Interfaz Comunicable ***********/

        public string GetQueryCrear()
        {
            return "AMBDA.crear_item";
        }

        string Comunicable.GetQueryModificar()
        {
            return "UPDATE AMBDA.Renglon SET reng_monto = @monto, reng_cantidad = @cantidad, reng_factura = @id_factura";
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM AMBDA.Renglon WHERE reng_factura = @id_factura";
        }

        public void CargarInformacion(SqlDataReader reader) //el reader lee filas de la DB
        {
            this.monto = Convert.ToString(reader["reng_monto"]);
            this.cantidad = Convert.ToDecimal(reader["reng_cantidad"]);
            this.id_factura = Convert.ToDecimal(reader["reng_factura"]); 
            
        }

        public IList<System.Data.SqlClient.SqlParameter> GetParametros()  
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Clear();
            parametros.Add(new SqlParameter("@monto", this.monto));
            parametros.Add(new SqlParameter("@cantidad", this.cantidad));
            parametros.Add(new SqlParameter("@id_factura", this.id_factura));
            return parametros;
        }
    }
}
