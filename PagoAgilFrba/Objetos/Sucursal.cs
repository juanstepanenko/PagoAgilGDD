using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagoAgilFrba.Excepciones;
using System.Data.SqlClient;

namespace PagoAgilFrba.Objetos
{
    class Sucursal : Objeto, Comunicable
    {
        private Decimal id;
        private String nombreSucursal;
        private Decimal idDireccion;
        private Boolean habilitada;

        //SETTERS Y GETTERS
        public void SetId(Decimal id)
        {
            this.id = id;
        }

        public Decimal GetId()
        {
            return this.id;
        }

        public void SetNombreSucursal(String nombreSucursal)
        {
            if (nombreSucursal == "")
                throw new CampoVacioException("Nombre de contacto");
            this.nombreSucursal = nombreSucursal;
        }

        public String GetNombreSucursal()
        {
            return this.nombreSucursal;
        }

        public void SetIdDireccion(Decimal idDireccion)
        {
            this.idDireccion = idDireccion;
        }

        public Decimal GetIdDireccion()
        {
            return this.idDireccion;
        }

        public void SetHabilitada(Boolean habilitada)
        {
            this.habilitada = habilitada;
        }

        public Boolean GetHabilitada()
        {
            return this.habilitada;
        }

        //QUERIES-------------------------------------

        #region Miembros de Comunicable

        public string GetQueryCrear()
        {
            return "AMBDA.crear_sucursal";
        }

        string Comunicable.GetQueryModificar()
        {
            return "UPDATE AMBDA.Sucursal SET sucu_nombre = @nombre,  sucu_direc_id = @direccion_id, sucu_habilitada = @habilitada  WHERE sucu_id = @id";
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM AMBDA.Sucursal WHERE sucu_id = @id";
        }


        public void CargarInformacion(SqlDataReader reader)
        {

            this.id = Convert.ToDecimal(reader["sucu_id"]);
            this.nombreSucursal = Convert.ToString(reader["sucu_nombre"]);
            this.idDireccion = Convert.ToDecimal(reader["sucu_direc_id"]);
            this.habilitada = Convert.ToBoolean(reader["sucu_habilitada"]);

        }

        public IList<System.Data.SqlClient.SqlParameter> GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", this.id));
            parametros.Add(new SqlParameter("@nombre", this.nombreSucursal));
            parametros.Add(new SqlParameter("@direccion_id", this.idDireccion));
            parametros.Add(new SqlParameter("@habilitada", this.habilitada));

            return parametros;
        }



        #endregion

    }

}
