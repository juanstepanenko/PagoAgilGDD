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

        private String nombre;
        private String cuit;
        private String calleNro;
        private String piso;
        private String departamento;
        private String localidad;
        private String rubro;


        public void SetNombre(String nombre)
        {
            if (nombre == "")
                throw new CampoVacioException("Nombre");
            this.nombre = nombre;
        }

        public String GetNnombre()
        {
            return this.nombre;
        }



        public void SetCuit(String cuit)
        {
            if (cuit == "")
                throw new CampoVacioException("Cuit");

            /*if (!esCuit(cuit))
                throw new FormatoInvalidoException("Cuit. Usar el siguiente formato: XX-XXXXXXXX-XX donde X es numero");
           */
            //agregar
            this.cuit = cuit;
        }

        public String GetCuit()
        {
            return this.cuit;
        }


        public void SetCalleNro(String calleNro)
        {
            if (calleNro == "")
                throw new CampoVacioException("CalleNro");
            this.calleNro = calleNro;
        }

        public String GetCiudad()
        {
            return this.calleNro;
        }

        public void SetPiso(String piso)
        {
            if (piso == "")
                throw new CampoVacioException("Piso");
            this.piso = piso;
        }

        public String GetPiso()
        {
            return this.piso;
        }

        public void SetDepartamento(String departamento)
        {
            if (departamento == "")
                throw new CampoVacioException("Departamento");

            this.departamento = departamento;
        }

        public String GetDepartamento()
        {
            return this.departamento;
        }

        public void SetLocalidad(String localidad)
        {
            this.localidad = localidad;
        }

        public String GetLocalidad()
        {
            return this.localidad;
        }


        public void SetRubro(String rubro)
        {
            this.rubro = rubro;
        }

        public String GetRubro()
        {
            return this.rubro;
        }

        #region Miembros de Comunicable

        // Poner nombres campos correctos

        string Comunicable.GetQueryCrear()
        {
            return "AMBDA.crear_empresa";
        }

        string Comunicable.GetQueryModificar()
        {
            return "UPDATE AMBDA.Empresa SET razon_social = @razon_social, nombre_de_contacto = @nombre_de_contacto, cuit = @cuit, fecha_creacion = @fecha_creacion, mail = @mail, telefono = @telefono, ciudad = @ciudad, habilitado = @habilitado  WHERE id = @id";
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM AMBDA.Empresa WHERE id = @id";
        }

        IList<System.Data.SqlClient.SqlParameter> Comunicable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", this.nombre));
            parametros.Add(new SqlParameter("@cuit", this.cuit));
            // agregar los que faltan
            return parametros;
        }

        public void CargarInformacion(SqlDataReader reader)
        {

            this.cuit = Convert.ToString(reader["cuit"]);
            // agregar los que faltan
        }

        #endregion
    }
}