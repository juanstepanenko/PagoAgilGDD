using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagoAgilFrba.Excepciones;
using System.Data.SqlClient;

namespace PagoAgilFrba.Objetos
{
    class Factura : Objeto, Comunicable
    {
        private String dniCliente;
        private String empresa;
        private String nroFactura;
        private DateTime fechaAlta;
        private DateTime fechaVencimiento;
        private String total;
        private Decimal idFactura;

        /************* Getters y Setters **************/

        //Getters y setters
        public String getDniCliente()
        {
            return dniCliente;
        }

        public void setDniCliente(String dniCliente)
        {
            if (dniCliente == "")
                throw new CampoVacioException("dni cliente");
            if (!esNumero(dniCliente))
                throw new FormatoInvalidoException("dni cliente");
            if (Convert.ToDecimal(dniCliente) == 0)
                throw new CantidadNulaException("dni cliente");
            this.dniCliente = dniCliente;
        }

        public String getEmpresa()
        {
            return empresa;
        }

        public void setEmpresa(String empresa)
        {
            this.empresa = empresa;
        }

        public String getNroFactura()
        {
            return nroFactura;
        }

        public void setNroFactura(String nroFactura)
        {
            if (nroFactura == "")
                throw new CampoVacioException("N factura");
            if (!esNumero(nroFactura))
                throw new FormatoInvalidoException("N factura");
            this.nroFactura = nroFactura;
        }

        public DateTime getFechaAlta()
        {
            return fechaAlta;
        }

        public void setFechaAlta(DateTime fechaAlta)
        {
            if (fechaAlta.Equals(DateTime.MinValue))
                throw new CampoVacioException("Fecha alta");

            this.fechaAlta = fechaAlta;
        }

        public DateTime getFechaVencimiento()
        {
            return fechaVencimiento;
        }

        public void setFechaVencimiento(DateTime fechaVencimiento)
        {
            if (fechaVencimiento.Equals(DateTime.MinValue))
                throw new CampoVacioException("Fecha Vencimiento");

            this.fechaVencimiento = fechaVencimiento;
        }

        public String getTotal()
        {
            if (total == "")
                throw new CampoVacioException("Total");
            if (!esDouble(total))
                throw new FormatoInvalidoException("Total");
            if (Convert.ToDouble(total) == 0)
                throw new CantidadNulaException("Total");
            return total;
        }

        public void setTotal(String total)
        {
            this.total = total;
        }

        public Decimal getIdFactura()
        {
            return idFactura;
        }

        public void setidFactura(Decimal idFactura)
        {
            this.idFactura = idFactura;
        }
        
        /********** Interfaz Comunicable ***********/

        public string GetQueryCrear()
        {
            return "AMBDA.crear_factura";
        }

        string Comunicable.GetQueryModificar()
        {
            return "UPDATE AMBDA.Factura SET fact_nro = @nroFactura, fact_fecha = @fechaAlta, fact_total = @total, fact_fecha_venc = @fechaVencimiento, fact_cliente = @cliente, fact_empresa = @empresa WHERE fact_id = @idFactura";
            //ojo aca la empresa, tengo el nombre y yo necesito el id TODO
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM AMBDA.Factura WHERE fact_id = @idFactura";
            //ojo aca la empresa, tengo el nombre y yo necesito el id TODO
        }

        public void CargarInformacion(SqlDataReader reader) //el reader lee filas de la DB
        {
            this.nroFactura = Convert.ToString(reader["fact_nro"]);
            this.fechaAlta = Convert.ToDateTime(reader["fact_fecha"]);
            this.fechaVencimiento = Convert.ToDateTime(reader["fact_fecha_venc"]);
            this.total = Convert.ToString(reader["fact_total"]);
            this.dniCliente = Convert.ToString(reader["fact_cliente"]);
            this.empresa = Convert.ToString(reader["fact_empresa"]); // este es el id, no el nombre!!
            this.idFactura = Convert.ToDecimal(reader["fact_id"]);
        }

        public IList<System.Data.SqlClient.SqlParameter> GetParametros()  
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Clear();
            parametros.Add(new SqlParameter("@nroFactura", Convert.ToDecimal(this.nroFactura)));
            parametros.Add(new SqlParameter("@fechaAlta", this.fechaAlta));
            parametros.Add(new SqlParameter("@fechaVencimiento", this.fechaVencimiento));
            parametros.Add(new SqlParameter("@total", Convert.ToDouble(this.total)));
            parametros.Add(new SqlParameter("@cliente", Convert.ToDecimal(this.dniCliente)));
            parametros.Add(new SqlParameter("@empresa", this.empresa));
            parametros.Add(new SqlParameter("@idFactura", this.idFactura));
            return parametros;
        }
    }
}
