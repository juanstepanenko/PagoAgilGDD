using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagoAgilFrba.Excepciones;
using System.Data.SqlClient;

namespace PagoAgilFrba.Objetos
{
    class Direccion : Objeto, Comunicable
    {
        private Decimal id;
        private String calleNro;
        private String piso;
        private String departamento;
        private String codigoPostal;
        private String localidad;

        /************* Getters y Setters **************/

        public void SetCalleNro(String calleNro)
        {
            if (calleNro == "")
                throw new CampoVacioException("CalleNro");
            this.calleNro = calleNro;
        }

        public void SetPiso(String piso)
        {
            if (piso != "" && !esNumero(piso))
                throw new FormatoInvalidoException("Piso");

            this.piso = piso;
        }

        public void SetDepartamento(String departamento)
        {
            this.departamento = departamento;
        }

        public void SetCodigoPostal(String codigoPostal)
        {
            if (codigoPostal == "")
                throw new CampoVacioException("Codigo postal");

            if (!esNumero(codigoPostal))
                throw new FormatoInvalidoException("Codigo postal");

            this.codigoPostal = codigoPostal;
        }

        public void SetLocalidad(String localidad)
        {
            if (localidad == "")
                throw new CampoVacioException("Localidad");
            this.localidad = localidad;
        }

        public void SetId(Decimal id)
        {
            this.id = id;
        }

        public String GetCalleNro()
        {
            return this.calleNro;
        }

        public String GetPiso()
        {
            return this.piso;
        }

        public String GetDepartamento()
        {
            return this.departamento;
        }

        public String GetCodigoPostal()
        {
            return this.codigoPostal;
        }

        public String GetLocalidad()
        {
            return this.localidad;
        }

        public Decimal GetId()
        {
            return this.id;
        }

        /********** Interfaz Comunicable ***********/
        
        #region Miembros de Comunicable
        
        string Comunicable.GetQueryCrear()
        {
            return "AMBDA.crear_direccion";
        }

        string Comunicable.GetQueryModificar()
        {
            return "UPDATE AMBDA.Direccion SET direc_calleNro = @calleNro, direc_piso = @piso, direc_depto = @depto, direc_cod_postal = @cod_postal, direc_localidad = @localidad WHERE direc_id = @id";
        } // falta 

        public string GetQueryObtener()
        {
            return "SELECT * FROM AMBDA.Direccion WHERE direc_id = @id";
        }

        IList<SqlParameter> Comunicable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@calleNro", this.calleNro));
            parametros.Add(new SqlParameter("@piso", this.siEsNuloDevolverDBNull(piso)));
            parametros.Add(new SqlParameter("@depto", this.siEsNuloDevolverDBNull(departamento)));
            parametros.Add(new SqlParameter("@cod_postal", this.codigoPostal));
            parametros.Add(new SqlParameter("@localidad", this.localidad));
            return parametros;
        }

        public void CargarInformacion(SqlDataReader reader)
        {
            this.calleNro = Convert.ToString(reader["direc_calleNro"]);
            this.piso = Convert.ToString(reader["direc_piso"]);
            this.departamento = Convert.ToString(reader["direc_depto"]);
            this.codigoPostal = Convert.ToString(reader["direc_cod_postal"]);
            this.localidad = Convert.ToString(reader["direc_localidad"]);
        }

        #endregion
    }
}
