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
            if (empresa == "")
                throw new CampoVacioException("empresa");
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
            if (Convert.ToString(fechaAlta) == "")
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
            if (Convert.ToString(fechaVencimiento) == "")
                throw new CampoVacioException("Fecha vencimiento");

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

        //la use
        public string GetQueryCrear()
        {
            return "AMBDA.crear_factura";
        }

        string Comunicable.GetQueryModificar()
        {
            return "UPDATE AMBDA.Factura SET fact_nro = @nroFactura, fact_fecha = @fechaAlta, fact_total = @total, fact_fecha_venc = @fechaVencimiento, fact_cliente = (select clie_id from AMBDA.Cliente where clie_dni = @cliente), fact_empresa = (select empr_cuit from AMBDA.Empresa where empr_nombre = @empresa) WHERE fact_id = @id";
            //ojo aca la empresa, tengo el nombre y yo necesito el cuit TODO
            //mismo con cliente
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM AMBDA.Factura WHERE fact_id = @id";
        }

        public string GetQueryObtenerConNro()
        {
            return "SELECT fact_id, fact_nro, fact_fecha, fact_fecha_venc, fact_total, (select clie_dni from AMBDA.Cliente where clie_id = fact_cliente) as 'cliente', (select empr_nombre from AMBDA.Empresa where empr_cuit = fact_empresa) as 'empresa' FROM AMBDA.Factura WHERE fact_nro = @nroFactura";
            
        }

        public void CargarInformacion(SqlDataReader reader) //el reader lee filas de la DB
        {
            this.nroFactura = Convert.ToString(reader["fact_nro"]);
            this.fechaAlta = Convert.ToDateTime(reader["fact_fecha"]);
            this.fechaVencimiento = Convert.ToDateTime(reader["fact_fecha_venc"]);
            this.total = Convert.ToString(reader["fact_total"]);
            this.dniCliente = Convert.ToString(reader["cliente"]); //que el select pase de clie id a dni
            this.empresa = Convert.ToString(reader["empresa"]); // que el select pase de cuit a nombre
            this.idFactura = Convert.ToDecimal(reader["fact_id"]);
        }

        //la use
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
            //parametros.Add(new SqlParameter("@idFactura", this.idFactura));
            return parametros;
        }
    }
}
