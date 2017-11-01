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
        private String direc;
        private Decimal cod_postal;
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


        public String getDireccion()
        {
            return direc;
        }

        public void setDireccion(String direc)
        {
            if (direc == "")
                throw new CampoVacioException("Dirección");
            this.direc = direc;
        }
        //----
        public Decimal getCodPostal()
        {
            return cod_postal;
        }

        public void setCodPostal(Decimal cod)
        {
            this.cod_postal = cod;
        }
        //----
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
            return "UPDATE AMBDA.Empresa SET empr_cuit = @cuit, empr_nombre = @nombre, empr_direc = @direccion, empr_cod_postal = @cod_postal, empr_rubro = @rubro, empr_habilitada = @habilitada  WHERE empr_id = @id"; // preguntar where 
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM AMBDA.Empresa WHERE empr_id = @id";
        }


        public void CargarInformacion(SqlDataReader reader)
        {

            this.cuit = Convert.ToString(reader["empr_cuit"]);
            this.nombre = Convert.ToString(reader["empr_nombre"]);
            this.direc = Convert.ToString(reader["empr_direc"]);
            this.cod_postal = Convert.ToDecimal(reader["empr_cod_postal"]);
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
            parametros.Add(new SqlParameter("@direccion", this.direc));
            parametros.Add(new SqlParameter("@cod_postal", this.cod_postal));         
            parametros.Add(new SqlParameter("@habilitada", this.habilitada));
            
            return parametros;
        }

       

        #endregion
    }
}