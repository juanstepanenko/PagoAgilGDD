using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagoAgilFrba.Excepciones;
using System.Data.SqlClient;

namespace PagoAgilFrba.Objetos
{
    class Cliente : Objeto, Comunicable
    {
        private Decimal id;
        private Decimal dni;
        private String nombre;
        private String apellido;
        private String direc;
        private Decimal cod_postal;
        private DateTime fechaDeNacimiento;
        private String mail;
        private String telefono;
        private Boolean habilitado;

        /************* Getters y Setters **************/

        public Decimal getId()
        {
            return id;
        }

        public void setId(Decimal id)
        {
            this.id = id;
        }
        //-----
        public Decimal getDni()
        {
            return dni;
        }

        public void setDni(Decimal dni)
        {
            if (dni.Equals(null))
                throw new CampoVacioException("Dni");
            this.dni = dni;
        }
        //----
        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String nombre)
        {
            if (nombre == "")
                throw new CampoVacioException("Nombre");
            this.nombre = nombre;
        }
        //----
        public String getApellido()
        {
            return apellido;
        }

        public void setApellido(String apellido)
        {
            if (apellido == "")
                throw new CampoVacioException("Apellido");
            this.apellido = apellido;
        }
        //----
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
        public DateTime getFechaDeNac()
        {
            return fechaDeNacimiento;
        }

        public void setFechaDeNac(DateTime fechaDeNacimiento)
        {
            if (fechaDeNacimiento.Equals(DateTime.MinValue))
                throw new CampoVacioException("Fecha de nacimiento");

            this.fechaDeNacimiento = fechaDeNacimiento;
        }
        //----
        public String getMail()
        {
            return mail;
        }

        public void setMail(String mail)
        {
            if (mail == "")
                throw new CampoVacioException("Mail");

            this.mail = mail;
        }
        //----
        public String getTelefono()
        {
            return telefono;
        }

        public void setTelefono(String telefono)
        {
            if (telefono == "")
                throw new CampoVacioException("Telefono");

            if (!esNumero(telefono))
                throw new FormatoInvalidoException("Telefono");

            this.telefono = telefono;
        }
        //----
        public Boolean getHabilitado()
        {
            return habilitado;
        }

        public void setHabilitado(Boolean hab)
        {
            this.habilitado = hab;
        }
        
        /********** Interfaz Comunicable ***********/

        public string GetQueryCrear()
        {
            return "AMBDA.crear_cliente";
        }

        string Comunicable.GetQueryModificar()
        {
            return "UPDATE AMBDA.Cliente SET clie_dni = @dni, clie_nombre = @nombre, clie_apellido = @apellido, clie_direc = @direccion, clie_cod_postal = @cod_postal, clie_fecha_nacimiento = @fecha_nacimiento, clie_mail = @mail, clie_telefono = @telefono, clie_habilitado = @habilitado WHERE clie_id = @id";
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM AMBDA.Cliente WHERE clie_id = @id";
        }

        public void CargarInformacion(SqlDataReader reader) //el reader lee filas de la DB
        { 
            this.dni = Convert.ToDecimal(reader["clie_dni"]); 
            this.nombre = Convert.ToString(reader["clie_nombre"]);
            this.apellido = Convert.ToString(reader["clie_apellido"]);
            this.fechaDeNacimiento = Convert.ToDateTime(reader["clie_fecha_nacimiento"]);
            this.mail = Convert.ToString(reader["clie_mail"]);
            this.telefono = Convert.ToString(reader["clie_telefono"]);
            this.direc = Convert.ToString(reader["clie_direc"]);
            this.cod_postal = Convert.ToDecimal(reader["clie_cod_postal"]);
            this.habilitado = Convert.ToBoolean(reader["clie_habilitado"]); 
        }

        public IList<System.Data.SqlClient.SqlParameter> GetParametros()  
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Clear();
            parametros.Add(new SqlParameter("@dni", this.dni));
            parametros.Add(new SqlParameter("@mail", this.mail));
            parametros.Add(new SqlParameter("@nombre", this.nombre));
            parametros.Add(new SqlParameter("@apellido", this.apellido));
            parametros.Add(new SqlParameter("@direccion", this.direc));
            parametros.Add(new SqlParameter("@cod_postal", this.cod_postal));
            parametros.Add(new SqlParameter("@fecha_nacimiento", this.fechaDeNacimiento));
            parametros.Add(new SqlParameter("@telefono", this.telefono));
            parametros.Add(new SqlParameter("@habilitado", this.habilitado));
            return parametros;
        }
    }
}
