using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoAgilFrba.Excepciones;
using System.Data.SqlClient;

namespace PagoAgilFrba.Objetos
{
    class Empresa : Objeto, Comunicable
    {
        private Decimal id;
        private String nombre;
        private String cuit;
        private Decimal direc_id;
        private Decimal rubro;
        private Boolean habilitada;

        /************* Getters y Setters **************/
        public Decimal GetId()
        {
            return id;
        }

        public void SetId(Decimal id)
        {
            this.id = id;
        }

        public void SetNombre(String nombre)
        {
            if (nombre == "")
                throw new CampoVacioException("Nombre");
            this.nombre = nombre;
        }

        public String GetNombre()
        {
            return this.nombre;
        }

        public void SetCuit(String cuit)
        {
            if (cuit == "")
                throw new CampoVacioException("Cuit");

            if (!esCuit(cuit))
                throw new FormatoInvalidoException("Cuit. Usar el siguiente formato: XX-XXXXXXXX-XX donde X es numero");
           
            //agregar
            this.cuit = cuit;
        }

        public String GetCuit()
        {
            return this.cuit;
        }


        public Decimal GetDireccionID()
        {
            return direc_id;
        }

        public void SetDireccionID(Decimal direcID)
        {
           // if (direcID == null)
             //   throw new CampoVacioException("Dirección");
            
            this.direc_id = direcID;
        }

        public void SetRubro(Decimal rubro)
        {
            if (rubro.Equals(null))
                throw new CampoVacioException("Rubro");
            
            this.rubro = rubro;
        }

        public Decimal GetRubro()
        {
            return this.rubro;
        }

        public Boolean GetHabilitada()
        {
            return habilitada;
        }

        public void SetHabilitada(Boolean hab)
        {
            this.habilitada = hab;
        }

        /****************************************/

        #region Miembros de Comunicable

        public string GetQueryCrear()
        {
            return "AMBDA.crear_empresa";
        }

         string Comunicable.GetQueryModificar()
        {
            return "UPDATE AMBDA.Empresa SET empr_cuit = @cuit, empr_nombre = @nombre, empr_direc_id = @direccion_id, empr_rubro = @rubro, empr_habilitada = @habilitada  WHERE empr_id = @id"; // preguntar where 
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM AMBDA.Empresa WHERE empr_id = @id";
        }


        public void CargarInformacion(SqlDataReader reader)
        {

            this.cuit = Convert.ToString(reader["empr_cuit"]);
            this.nombre = Convert.ToString(reader["empr_nombre"]);
            this.direc_id = Convert.ToDecimal(reader["empr_direc_id"]);
            this.rubro = Convert.ToDecimal(reader["empr_rubro"]);
            this.habilitada = Convert.ToBoolean(reader["empr_habilitada"]);

        }

        public IList<System.Data.SqlClient.SqlParameter> GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Clear();
            parametros.Add(new SqlParameter("@cuit", this.cuit));
            parametros.Add(new SqlParameter("@nombre", this.nombre));
            parametros.Add(new SqlParameter("@rubro", this.rubro));
            parametros.Add(new SqlParameter("@direccion_id", this.direc_id));          
            parametros.Add(new SqlParameter("@habilitada", this.habilitada));
            
            return parametros;
        }

       

        #endregion
    }
}