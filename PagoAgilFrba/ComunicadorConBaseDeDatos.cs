using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PagoAgilFrba.Objetos;
using PagoAgilFrba.Excepciones;

namespace PagoAgilFrba
{
    class ComunicadorConBaseDeDatos
    {
        private String query;
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private SqlParameter parametroOutput;
        private SqlCommand command; // se usa para interactuar con la DB
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();


        //aca van todas funciones que tiran queries --> update, sp, etc

        /****************CREAR***************/

        public Decimal Crear(Comunicable objeto) //el general para todos los objetos
        {
            query = objeto.GetQueryCrear();
            parametros.Clear();
            parametros = objeto.GetParametros(); //agarro todos los campos del objeto
            //--- esto de parametroOutput se hace solo si tiene un id no generado, por ejemplo en cliente no (es el dni) CREO
            parametroOutput = new SqlParameter("@id", SqlDbType.Decimal);
            parametroOutput.Direction = ParameterDirection.Output;
            parametros.Add(parametroOutput);
            command = builderDeComandos.Crear(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery(); // esta query al ejecutarse no devuelve nada, es un sp
            return (Decimal)parametroOutput.Value;
        }

        public void CrearCliente(Cliente cliente)
        {
            if (!pasoControlDeRegistroDni(Convert.ToString(cliente.getDni())))
                throw new ClienteYaExisteException();
            //hay que elimiar direc

            if (!pasoControlDeUnicidad(cliente.getMail(), "clie_mail", "Cliente"))
                throw new MailYaExisteException();
            //hay que elimiar direc
             
            query = cliente.GetQueryCrear();
            parametros.Clear();
            parametros = cliente.GetParametros(); //agarro todos los campos de cliente
            command = builderDeComandos.Crear(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery(); // esta query al ejecutarse no devuelve nada, es un sp

        }

        public Decimal CrearDireccion(Direccion direccion)
        {
            return this.Crear(direccion);
        }

        public Decimal CrearEmpresa(Empresa empresa)
        {
            if (!pasoControlDeRegistroDeCuit(empresa.GetCuit()))
                throw new CuitYaExisteException();
            // ver si falta alguna restriccion mas desde la abm
            return this.Crear(empresa);
        }
        /**************OBTENER***************/

        public Comunicable Obtener(Decimal id, Type clase)
        {
            Comunicable objeto = (Comunicable)Activator.CreateInstance(clase);
            query = objeto.GetQueryObtener();
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            SqlDataReader reader = builderDeComandos.Crear(query, parametros).ExecuteReader();
            if (reader.Read())
            {
                objeto.CargarInformacion(reader);
                return objeto;
            }
            return objeto;
        }

        public Cliente ObtenerCliente(Decimal dniCliente)
        {
            Cliente objeto = new Cliente();
            Type clase = objeto.GetType();
           
            Cliente cliente = (Cliente)Activator.CreateInstance(clase);
            query = cliente.GetQueryObtener();
            parametros.Clear();
            parametros.Add(new SqlParameter("@dni", dniCliente));
            SqlDataReader reader = builderDeComandos.Crear(query, parametros).ExecuteReader();
            if (reader.Read())
            {
                cliente.CargarInformacion(reader);
                return cliente;
            }
            return cliente;
        }

        public Direccion ObtenerDireccion(Decimal idDireccion)
        {
            Direccion objeto = new Direccion();
            Type clase = objeto.GetType();

            Direccion direc = (Direccion)Activator.CreateInstance(clase);
            query = direc.GetQueryObtener();
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", idDireccion));
            SqlDataReader reader = builderDeComandos.Crear(query, parametros).ExecuteReader();
            if (reader.Read())
            {
                direc.CargarInformacion(reader);
                return direc;
            }
            return direc;
        }

        /************MODIFICAR***************/

        public Boolean Modificar(Decimal id, Comunicable objeto)
        {
            query = objeto.GetQueryModificar();
            parametros.Clear();
            parametros = objeto.GetParametros();
            parametros.Add(new SqlParameter("@id", id));
            int filasAfectadas = builderDeComandos.Crear(query, parametros).ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            return false;
        }
        
        /************ELIMINAR*************/
        public Boolean EliminarCliente(Decimal id)
        {
            query = "UPDATE AMBDA.Cliente SET clie_habilitado = 0 WHERE clie_dni = @dni";
            parametros.Clear();
            parametros.Add(new SqlParameter("@dni", id));
            int filasAfectadas = builderDeComandos.Crear(query, parametros).ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            return false;
        }

        /**************CONTROLES**************/

        private bool ControlDeUnicidad(String query, IList<SqlParameter> parametros)
        {
            int cantidad = (int)builderDeComandos.Crear(query, parametros).ExecuteScalar();
            if (cantidad > 0)
            {
                return false;
            }
            return true;
        }

        private bool pasoControlDeUnicidad(String que, String aQue, String enDonde)
        {
            query = "SELECT COUNT(*) FROM AMBDA." + enDonde + " WHERE " + aQue + " = @" + aQue;
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + aQue, que));
            return ControlDeUnicidad(query, parametros);
        }

        private bool pasoControlDeRegistroDeCuit(String cuit)
        {
            query = "SELECT COUNT(*) FROM AMBDA.Empresa WHERE empr_cuit = @cuit";
            parametros.Clear();
            parametros.Add(new SqlParameter("@cuit", cuit));
            return ControlDeUnicidad(query, parametros);
        }

        


        /**********SELECTS VARIOS************/

        public Object SelectFromWhere(String que, String deDonde, String param1, String param2)
        {
            query = "SELECT " + que + " FROM AMBDA." + deDonde + " WHERE " + param1 + " = @" + param1;
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + param1, param2));
            return builderDeComandos.Crear(query, parametros).ExecuteScalar();
        }

        public Object SelectFromWhere(String que, String deDonde, String param1, Decimal param2)
        {
            query = "SELECT " + que + " FROM AMBDA." + deDonde + " WHERE " + param1 + " = @" + Convert.ToString(param2);
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + param2, param2));
            return builderDeComandos.Crear(query, parametros).ExecuteScalar();
        }

        
        private bool pasoControlDeRegistroDni(String nrodni)
        {
            query = "SELECT COUNT(*) FROM AMBDA.Cliente WHERE clie_dni = @" + nrodni;
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + nrodni, Convert.ToDecimal(nrodni)));
            return ControlDeUnicidad(query, parametros);
        }

        public DataTable SelectDataTable(String que, String deDonde)
        {
            parametros.Clear();
            command = builderDeComandos.Crear("SELECT " + que + " FROM " + deDonde, parametros);
            DataSet datos = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(datos);
            return datos.Tables[0];
        }

        public DataTable SelectDataTable(String que, String deDonde, String condiciones)
        {
            return this.SelectDataTableConUsuario(que, deDonde, condiciones);
        }

        public DataTable SelectDataTableConUsuario(String que, String deDonde, String condiciones)
        {
            parametros.Clear();
            command = builderDeComandos.Crear("SELECT " + que + " FROM " + deDonde + " WHERE " + condiciones, parametros);
            command.CommandTimeout = 0;
            DataSet datos = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(datos);
            return datos.Tables[0];
        }

        public DataTable SelectClientesParaFiltroConFiltro(String filtro)
        {
            return this.SelectDataTable("c.clie_dni Dni, c.clie_nombre Nombre, c.clie_apellido Apellido, c.clie_fecha_nacimiento FechaDeNacimiento, c.clie_mail Mail, c.clie_telefono Telefono, d.direc_calleNro Calle, d.direc_piso Piso, d.direc_depto Departamento, d.direc_cod_postal CodigoPostal, d.direc_localidad Localidad"
                , "AMBDA.Cliente c, AMBDA.Direccion d"
                , "c.clie_direc_id = d.direc_id AND c.clie_habilitado = 1" + filtro);
        }

        public DataTable SelectClientesParaFiltro()
        {
            return this.SelectClientesParaFiltroConFiltro("");
        }
   }
}
