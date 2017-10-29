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
        private Decimal dni;
        private Decimal cliente;
        private String empresa;
        private Decimal nroFactura;
        private DateTime fechaAlta;
        private DateTime fechaVencimiento;
        private Decimal total;
        private Decimal idFactura;

        /************* Getters y Setters **************/

        //Getters y setters
        public Decimal getDni()
        {
            return dni;
        }

        public void setDni(Decimal dni)
        {
            this.dni = dni;
        }

        public Decimal getCliente()
        {
            return cliente;
        }

        public void setCliente(Decimal cliente)
        {
            this.cliente = cliente;
        }

        public String getEmpresa()
        {
            return empresa;
        }

        public void setEmpresa(String empresa)
        {
            this.empresa = empresa;
        }

        public Decimal getNroFactura()
        {
            return nroFactura;
        }

        public void setNroFactura(Decimal nroFactura)
        {
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

        public Decimal getTotal()
        {
            return total;
        }

        public void setTotal(Decimal total)
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
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM AMBDA.Factura WHERE fact_id = @idFactura";
        }

        public void CargarInformacion(SqlDataReader reader) //el reader lee filas de la DB
        {
            this.nroFactura = Convert.ToDecimal(reader["fact_nro"]);
            this.fechaAlta = Convert.ToDateTime(reader["fact_fecha"]);
            this.fechaVencimiento = Convert.ToDateTime(reader["fact_fecha_venc"]);
            this.total = Convert.ToDecimal(reader["fact_total"]);
            this.cliente = Convert.ToDecimal(reader["fact_cliente"]);
            this.empresa = Convert.ToString(reader["fact_empresa"]);
            this.idFactura = Convert.ToDecimal(reader["fact_id"]);
        }

        public IList<System.Data.SqlClient.SqlParameter> GetParametros()  
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Clear();
            parametros.Add(new SqlParameter("@nroFactura", this.nroFactura));
            parametros.Add(new SqlParameter("@fechaAlta", this.fechaAlta));
            parametros.Add(new SqlParameter("@fechaVencimiento", this.fechaVencimiento));
            parametros.Add(new SqlParameter("@total", this.total));
            parametros.Add(new SqlParameter("@cliente", this.cliente));
            parametros.Add(new SqlParameter("@empresa", this.empresa));
            parametros.Add(new SqlParameter("@idFactura", this.idFactura));
            return parametros;
        }
    }
}
