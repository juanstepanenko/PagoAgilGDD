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

        public Decimal Crear(Comunicable objeto) //el general para todos los objetos, sirve para los que tienen id como pk (como direccion)
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
            query = cliente.GetQueryCrear();
            parametros.Clear();
            parametros = cliente.GetParametros(); 
            command = builderDeComandos.Crear(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery(); 
        }

        public Decimal CrearDireccion(Direccion direccion)
        {
            return this.Crear(direccion);
        }

        public void CrearPago(Pago pago)
        {
            query = pago.GetQueryCrear();
            parametros.Clear();
            parametros = pago.GetParametros();
            command = builderDeComandos.Crear(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }

        public void CrearEmpresa(Empresa empresa)
        {
            query = empresa.GetQueryCrear();
            parametros.Clear();
            parametros = empresa.GetParametros(); 
            command = builderDeComandos.Crear(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery(); 

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

        public Empresa ObtenerEmpresa(String cuit)
        {
            Empresa objeto = new Empresa();
            Type clase = objeto.GetType();

            Empresa empresa = (Empresa)Activator.CreateInstance(clase);
            query = empresa.GetQueryObtener();
            parametros.Clear();
            parametros.Add(new SqlParameter("@cuit", cuit));
            SqlDataReader reader = builderDeComandos.Crear(query, parametros).ExecuteReader();
            if (reader.Read())
            {
                empresa.CargarInformacion(reader);
                return empresa;
            }
            return empresa;
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

        public Boolean ModificarEmpresa(String cuit, Comunicable objeto)
        {
            query = objeto.GetQueryModificar();
            parametros.Clear();
            parametros = objeto.GetParametros();
           // parametros.Add(new SqlParameter("@cuit", cuit));
            int filasAfectadas = builderDeComandos.Crear(query, parametros).ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            return false;
        }

        
        /************ELIMINAR*************/
        //retorna la cantidad de filas afectadas
        public int eliminarGeneralId(String query, String var, Decimal id)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter(var, id));
            return builderDeComandos.Crear(query, parametros).ExecuteNonQuery();
        }
        public Boolean EliminarDireccion(Decimal id)
        {
            if (eliminarGeneralId("DELETE AMBDA.Direccion WHERE direc_id = (SELECT clie_direc_id FROM AMBDA.Cliente WHERE clie_dni = @dni)", "@dni", id) == 1)
                return true;
            return false;
        }

        public Boolean EliminarCliente(Decimal id)
        {
            if (eliminarGeneralId("UPDATE AMBDA.Cliente SET clie_habilitado = 0 WHERE clie_dni = @dni", "@dni", id) == 1) 
                return true;
            return false;
        }

        public Boolean EliminarEmpresa(Decimal id)
        {
            if (eliminarGeneralId("UPDATE AMBDA.Cliente SET empr_habilitada = 0 WHERE empr_cuit = @cuit", "@cuit", id) == 1)
                return true;
            return false;
        }

        public Boolean EliminarFactura(Decimal id)
        {
            int filasAfectadas1 = eliminarGeneralId("DELETE FROM AMBDA.Renglon WHERE reng_factura = (select fact_id from AMBDA.Factura where fact_nro = @nrofact)", "@nrofact", id);
            int filasAfectadas2 = eliminarGeneralId("DELETE FROM AMBDA.Factura WHERE fact_nro = @nrofact2", "@nrofact2", id);
            if (filasAfectadas1 == 1 || filasAfectadas2 == 1) return true;
            return false;
        }

        /**************CONTROLES**************/

        public bool ControlDeUnicidad(String query, IList<SqlParameter> parametros)
        {
            int cantidad = (int)builderDeComandos.Crear(query, parametros).ExecuteScalar();
            if (cantidad > 0)
            {
                return false;
            }
            return true;
        }

        public bool pasoControlDeUnicidad(String que, String aQue, String enDonde)
        {
            query = "SELECT COUNT(*) FROM AMBDA." + enDonde + " WHERE " + aQue + " = @" + aQue;
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + aQue, que));
            return ControlDeUnicidad(query, parametros);
        }

        public bool pasoControlDeRegistroDni(String nrodni)
        {
            query = "SELECT COUNT(*) FROM AMBDA.Cliente WHERE clie_dni = @" + nrodni;
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + nrodni, Convert.ToDecimal(nrodni)));
            return ControlDeUnicidad(query, parametros);
        }

        public bool pasoControlDeRegistroFactura(Decimal nrofact)
        {
            query = "SELECT COUNT(*) FROM AMBDA.Factura WHERE fact_nro = @nrofact";
            parametros.Clear();
            parametros.Add(new SqlParameter("@nrofact", nrofact));
            return ControlDeUnicidad(query, parametros);
        }

        public bool pasoControlDeRendidaFactura(Decimal nrofact){
        
            query = "SELECT COUNT(*) FROM AMBDA.Factura WHERE fact_nro = @nrofact and fact_rendicion is null";
            parametros.Clear();
            parametros.Add(new SqlParameter("@nrofact", nrofact));
            return ControlDeUnicidad(query, parametros);
        }

        public bool pasoControlDeRegistroDeCuit(String cuit)
        {
            query = "SELECT COUNT(*) FROM AMBDA.Empresa WHERE empr_cuit = @cuit";
            parametros.Clear();
            parametros.Add(new SqlParameter("@cuit", cuit));
            return ControlDeUnicidad(query, parametros);
        }


        /**********SELECTS VARIOS************/

        public Decimal SelectFromWhere(String que, String deDonde, String param1, String param2)
        {
            query = "SELECT " + que + " FROM AMBDA." + deDonde + " WHERE " + param1 + " = @" + param1;
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + param1, param2));
            return Convert.ToDecimal(builderDeComandos.Crear(query, parametros).ExecuteScalar());
        }

        public Decimal SelectFromWhere(String que, String deDonde, String param1, Decimal param2)
        {
            query = "SELECT " + que + " FROM AMBDA." + deDonde + " WHERE " + param1 + " = @" + param1;
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + param1, param2));
            return Convert.ToDecimal(builderDeComandos.Crear(query, parametros).ExecuteScalar());
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

        public DataTable SelectFacturasParaFiltroConFiltro(String filtro)
        {
            return this.SelectDataTable("fact_nro as 'nro factura', fact_cliente as 'dni cliente', fact_empresa as 'empresa', fact_fecha as 'fecha alta', fact_fecha_venc as 'fecha vencimiento', fact_total as 'importe total'"
            , "AMBDA.Factura"
            , "fact_cobrada <> 1 and fact_rendicion is null " + filtro);
        }

        public DataTable SelectFacturasParaFiltro()
        {
            return this.SelectFacturasParaFiltroConFiltro("");
        }

        public DataTable SelectEmpresasParaFiltroConFiltro(String filtro)
        {
            return this.SelectDataTable("e.empr_cuit Cuit, e.empr_nombre Nombre, e.empr_direc_id DireccionId, e.empr_rubro Rubro, d.direc_calleNro Calle, d.direc_piso Piso, d.direc_depto Departamento, d.direc_cod_postal CodigoPostal, d.direc_localidad Localidad"
                , "AMBDA.Empresa e, AMBDA.Direccion d"
                , "e.empr_direc_id = d.direc_id AND e.empr_habilitada = 1" + filtro);
        }

        public DataTable SelectEmpresasParaFiltro()
        {
            return this.SelectEmpresasParaFiltroConFiltro("");
        }

        public void PagarFactura(Decimal idPago, Decimal idFactura, Decimal importe)
        {
            String query = "AMBDA.agregar_pagar_factura";
            parametros.Clear();
            parametros.Add(new SqlParameter("@pago", idPago));
            parametros.Add(new SqlParameter("@factura", idFactura));
            parametros.Add(new SqlParameter("@importe", importe));
            command = builderDeComandos.Crear(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }
   }
}
