using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PagoAgilFrba.Excepciones;

namespace PagoAgilFrba.Objetos
{
    class Pago : Objeto, Comunicable
    {
        private Decimal id;
        private DateTime fecha_cobro;
        private Decimal cliente;
        private Double importe;
        private Decimal usuario;
        private Decimal sucursal;
        private Decimal medio_pago;

        /************* Getters y Setters **************/
        public void setIdPago(Decimal id)
        {
            this.id = id;
        }

        public Decimal getIdPago()
        {
            return this.id;
        }

        public void setFechaCobro(DateTime fechaDeCobro)
        {
            if (fechaDeCobro.Equals(DateTime.MinValue))
                throw new CampoVacioException("Fecha De Cobro"); 

            this.fecha_cobro = fechaDeCobro;
        }

        public DateTime getFechaCobro()
        {
            return this.fecha_cobro;
        }

        public void setCliente(Decimal cliente)
        {
            if (cliente.Equals(null))
                throw new CampoVacioException("Cliente");

            this.cliente = cliente;
        }

        public Decimal getCliente()
        {
            return this.cliente;
        }

        public void setImporte(Double importe)
        {
            this.importe = importe;
        }

        public Double getImporte()
        {
            return this.importe;
        }

        public void setUsuario(Decimal usuario)
        {
            this.usuario = usuario;
        }

        public Decimal getUsuario()
        {
            return this.usuario;
        }

        public void setSucursal(Decimal sucursal)
        {
            this.sucursal = sucursal;
        }

        public Decimal getSucursal()
        {
            return this.sucursal;
        }

        public void setMedioPago(Decimal medio)
        {
            this.medio_pago = medio;
        }

        public Decimal getMedioPago()
        {
            return this.medio_pago;
        }
        /********** Interfaz Comunicable ***********/

        public string GetQueryCrear()
        {
            return "AMBDA.crear_pago";
        }

        string Comunicable.GetQueryModificar()
        {
            return "UPDATE AMBDA.RegistroPago SET clie_nombre = @nombre, clie_apellido = @apellido, clie_direc_id = @direccion_id, clie_fecha_nacimiento = @fecha_nacimiento, clie_mail = @mail, clie_telefono = @telefono, clie_habilitado = @habilitado WHERE clie_dni = @dni";
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM AMBDA.RegistroPago WHERE regi_id = @id";
        }

        public void CargarInformacion(SqlDataReader reader) //el reader lee filas de la DB
        {
            //this.id = Convert.ToDecimal(reader["regi_id"]);
            this.fecha_cobro = Convert.ToDateTime(reader["regi_fecha_cobro"]);
            this.cliente = Convert.ToDecimal(reader["regi_cliente"]);
            this.importe = Convert.ToDouble(reader["regi_importe"]);
            this.usuario = Convert.ToDecimal(reader["regi_usuario"]);
            this.sucursal = Convert.ToDecimal(reader["regi_sucursal"]);
            this.medio_pago = Convert.ToDecimal(reader["regi_medio_pago"]);
        }

        public IList<System.Data.SqlClient.SqlParameter> GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Clear();
            //parametros.Add(new SqlParameter("@id", this.id));
            parametros.Add(new SqlParameter("@fecha_cobro", this.fecha_cobro));
            parametros.Add(new SqlParameter("@importe", this.importe));
            parametros.Add(new SqlParameter("@cliente", this.cliente));
            parametros.Add(new SqlParameter("@usuario", this.usuario));
            parametros.Add(new SqlParameter("@sucursal", this.sucursal));
            parametros.Add(new SqlParameter("@medio_pago", this.medio_pago));
            return parametros;
        }
    }
}
