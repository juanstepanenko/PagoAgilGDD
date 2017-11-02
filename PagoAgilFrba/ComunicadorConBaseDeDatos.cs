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
            //--soy ro, creo que te lo da si es autogenerado
            parametroOutput = new SqlParameter("@id", SqlDbType.Decimal);
            parametroOutput.Direction = ParameterDirection.Output;
            parametros.Add(parametroOutput);
            command = builderDeComandos.Crear(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery(); // esta query al ejecutarse no devuelve nada, es un sp
            return (Decimal)parametroOutput.Value;
        }

        public Decimal CrearCliente(Cliente cliente)
        {
            return this.Crear(cliente);
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

        public Decimal CrearEmpresa(Empresa empresa)
        {
            return this.Crear(empresa);
        }

        public Decimal CrearFactura(Factura factura)
        {
            if (pasoControlDeEmpresaConNombre(factura.getEmpresa()))
                throw new EmpresaNoExisteException();
            if (pasoControlDeCliente(factura.getDniCliente()))
                throw new ClienteNoExisteException();
            if(!pasoControlDeFacturaParaFactura(factura.getEmpresa(), factura.getNroFactura()))
                throw new FacturaYaExisteException();
            return this.Crear(factura);
        }

        public Decimal CrearSucursal(Sucursal sucursal)
         {
             //if (!pasoControlSucursal(sucursal.GetId()))
                 //throw new SucursalYaExisteExcepcion();
             if (!pasoControlCodPostalDeSucu(Convert.ToString(sucursal.GetCodPostal()),sucursal.GetId()))
                 throw new SucursalYaExisteExcepcion();
             return this.Crear(sucursal);
         }

        public Decimal CrearItem(Item item)
        {
            return this.Crear(item);
        }

        public Decimal CrearDevolucion(Devolucion devolucion)
        {
             return this.Crear(devolucion);
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

        public Cliente ObtenerCliente(Decimal idCliente)
        {
            Cliente objeto = new Cliente();
            Type clase = objeto.GetType();

            Cliente cliente = (Cliente)Activator.CreateInstance(clase);
            query = cliente.GetQueryObtener();
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", idCliente));
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

        public Empresa ObtenerEmpresa(Decimal id)
        {
            Empresa objeto = new Empresa();
            Type clase = objeto.GetType();

            Empresa empresa = (Empresa)Activator.CreateInstance(clase);
            query = empresa.GetQueryObtener();
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            SqlDataReader reader = builderDeComandos.Crear(query, parametros).ExecuteReader();
            if (reader.Read())
            {
                empresa.CargarInformacion(reader);
                return empresa;
            }
            return empresa;
        }

        public Sucursal ObtenerSucursal(Decimal id)
         {
             Sucursal objeto = new Sucursal();
             Type clase = objeto.GetType();
 
             Sucursal sucursal = (Sucursal)Activator.CreateInstance(clase);
             query = sucursal.GetQueryObtener();
             parametros.Clear();
             parametros.Add(new SqlParameter("@id", id));
             SqlDataReader reader = builderDeComandos.Crear(query, parametros).ExecuteReader();
             if (reader.Read())
             {
                 sucursal.CargarInformacion(reader);
                 return sucursal;
             }
             return sucursal;
         }

        public Factura ObtenerFactura(String idFactura)
        {
            Factura objeto = new Factura();
            Type clase = objeto.GetType();

            Factura factura = (Factura)Activator.CreateInstance(clase);
            query = factura.GetQueryObtener();
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", idFactura));
            SqlDataReader reader = builderDeComandos.Crear(query, parametros).ExecuteReader();
            if (reader.Read())
            {
                factura.CargarInformacion(reader);
                return factura;
            }
            return factura;
        }

         public Factura ObtenerFacturaConNumero(String nroFactura)
        {
            Factura objeto = new Factura();
            Type clase = objeto.GetType();

            Factura factura = (Factura)Activator.CreateInstance(clase);
            query = factura.GetQueryObtenerConNro();
            parametros.Clear();
            parametros.Add(new SqlParameter("@nroFactura", nroFactura));
            SqlDataReader reader = builderDeComandos.Crear(query, parametros).ExecuteReader();
            if (reader.Read())
            {
                factura.CargarInformacion(reader);
                return factura;
            }
            return factura;
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


        public Boolean ModificarFactura(Decimal id, Factura factura)
        {
            Factura facturaOriginal = ObtenerFactura(Convert.ToString(id));
            if (pasoControlDeEmpresaConNombre(factura.getEmpresa()))
                throw new EmpresaNoExisteException();
            if (pasoControlDeCliente(factura.getDniCliente()))
                throw new ClienteNoExisteException();
            if (facturaOriginal.getNroFactura() != factura.getNroFactura() && facturaOriginal.getEmpresa() != factura.getEmpresa())
            {
                if (!pasoControlDeFacturaParaFactura(factura.getEmpresa(), factura.getNroFactura()))
                    throw new FacturaYaExisteException();
            }
            return this.Modificar(id, factura);
        }

        public Boolean ModificarEmpresa(Decimal idEmpresa, Comunicable objeto)
        {
            query = objeto.GetQueryModificar();
            parametros.Clear();
            parametros = objeto.GetParametros();
            parametros.Add(new SqlParameter("@id", idEmpresa));
            int filasAfectadas = builderDeComandos.Crear(query, parametros).ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            return false;
        }


        public Boolean ModificarSucursal(Decimal id, Comunicable objeto)
        {
            query = objeto.GetQueryModificar();
            parametros.Clear();
            parametros = objeto.GetParametros();
            parametros.Add(new SqlParameter("@id", id));
            int filasAfectadas = builderDeComandos.Crear(query, parametros).ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            return false;
        }

        public Boolean DevolverPago(Decimal pago_id, Pago objeto)
        {
            query = "UPDATE AMBDA.RegistroPago SET regi_devuelto = '1' WHERE regi_id = @pago_id";
            parametros.Clear();
            parametros = objeto.GetParametros();
            parametros.Add(new SqlParameter("@pago_id", pago_id));
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
            if (eliminarGeneralId("DELETE AMBDA.Direccion WHERE direc_id = (SELECT clie_direc_id FROM AMBDA.Cliente WHERE clie_id = @id)", "@", id) == 1)
                return true;
            return false;
        }

        public Boolean EliminarCliente(Decimal id)
        {
            if (eliminarGeneralId("UPDATE AMBDA.Cliente SET clie_habilitado = 0 WHERE clie_id = @id", "@id", id) == 1)
                return true;
            return false;
        }

        public Boolean EliminarEmpresa(Decimal id)
        {
            if (eliminarGeneralId("UPDATE AMBDA.Empresa SET empr_habilitada = 0 WHERE empr_id = @id", "@id", id) == 1)
                return true;
            return false;
        }

        public Boolean EliminarFactura(Decimal nroFact)
        {
            int filasAfectadas1 = eliminarGeneralId("DELETE FROM AMBDA.Renglon WHERE reng_factura = (select fact_id from AMBDA.Factura where fact_nro = @nrofact)", "@nrofact", nroFact);
            int filasAfectadas2 = eliminarGeneralId("DELETE FROM AMBDA.Factura WHERE fact_nro = @nrofact2", "@nrofact2", nroFact);
            if (filasAfectadas1 == 1 || filasAfectadas2 == 1) return true;
            return false;
        }

        public Boolean EliminarSucursal(Decimal id)//, Decimal direcc_id)
        {
            if (eliminarGeneralId("UPDATE AMBDA.Sucursal SET sucu_habilitada = 0 WHERE sucu_id = @id", "@id", id) == 1) return true;
            //filasAfectadas2 = eliminarGeneralId("DELETE FROM AMBDA.Direccion WHERE direc_id = @dirID", "@dirID", direcc_id);
            //if (filasAfectadas1 == 1 || filasAfectadas2 == 1) return true;
            return false;
        }

        public Boolean EliminarItem(Decimal id)
        {
            int filasAfectadas = eliminarGeneralId("DELETE FROM AMBDA.Renglon WHERE reng_id = @id", "@id", id);
            if (filasAfectadas == 1) return true;
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

        public bool pasoControlDeRegistroDeCuit(String cuit)
        {
            query = "SELECT COUNT(*) FROM AMBDA.Empresa WHERE empr_cuit = @cuit";
            parametros.Clear();
            parametros.Add(new SqlParameter("@cuit", cuit));
            return ControlDeUnicidad(query, parametros);
        }

        public bool pasoControlDeEmpresaConNombre(String nombre)
        {
            query = "SELECT COUNT(*) FROM AMBDA.Empresa WHERE empr_nombre = @empresa";
            parametros.Clear();
            parametros.Add(new SqlParameter("@empresa", nombre));
            return ControlDeUnicidad(query, parametros);
        }
        public bool pasoControlDeRegistroFactura(String nrofact)
        {
            query = "SELECT COUNT(*) FROM AMBDA.Factura WHERE fact_nro = @nrofact";
            parametros.Clear();
            parametros.Add(new SqlParameter("@nrofact", nrofact));
            return ControlDeUnicidad(query, parametros);
        }

        private bool pasoControlDeFacturaParaFactura(String empresa, String nroFactura)
        {
            query = "SELECT COUNT(*) FROM AMBDA.Factura WHERE fact_empresa = (select empr_id from AMBDA.Empresa where empr_nombre = @empresa) and fact_nro = @nroFactura";
            parametros.Clear();
            parametros.Add(new SqlParameter("@empresa", empresa));
            parametros.Add(new SqlParameter("@nroFactura", Convert.ToDecimal(nroFactura)));
            return ControlDeUnicidad(query, parametros);
        }

        private bool pasoControlDeCliente(String dniCliente)
        {
            query = "SELECT COUNT(*) FROM AMBDA.Cliente WHERE clie_dni = @cliente";
            parametros.Clear();
            parametros.Add(new SqlParameter("@cliente", Convert.ToDecimal(dniCliente)));
			return ControlDeUnicidad(query, parametros);
        }
		
        public bool pasoControlDeRendidaFactura(String nrofact)
        {
           
            query = "SELECT COUNT(*) FROM AMBDA.Factura WHERE fact_nro = @nrofact and fact_rendicion is null";
            parametros.Clear();
            parametros.Add(new SqlParameter("@nrofact", nrofact));
            return ControlDeUnicidad(query, parametros);
        }

        public bool pasoControlDeCobradaFactura(String nrofact)
        {

            query = "SELECT COUNT(*) FROM AMBDA.Factura WHERE fact_nro = @nrofact and  fact_cobrada = 1";
            parametros.Clear();
            parametros.Add(new SqlParameter("@nrofact", nrofact));
            return ControlDeUnicidad(query, parametros);
        }
      /*  public bool pasoControlDeDevueltaFactura(String nrofact)
        {

            query = "SELECT COUNT(*) FROM AMBDA.Factura WHERE fact_nro = @nrofact and fact_rendicion is null";
            parametros.Clear();
            parametros.Add(new SqlParameter("@nrofact", nrofact));
            return ControlDeUnicidad(query, parametros);
        }
        */
        public Boolean pasoControlDeFacturaDeEmpresa(Decimal nroFactura, Decimal empresa)
        {
            String query = "Select count(*) From AMBDA.Factura Where fact_nro = @nroFactura And fact_empresa = @empresa";
            parametros.Clear();
            parametros.Add(new SqlParameter("@nroFactura", nroFactura));
            parametros.Add(new SqlParameter("@empresa", empresa));
            if (Convert.ToDecimal(builderDeComandos.Crear(query, parametros).ExecuteScalar()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*public bool pasoControlSucursal(Decimal sucu_id)
        {
            query = "SELECT COUNT(*) FROM AMBDA.Sucursal WHERE sucu_id = @id";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", sucu_id));//sucu_id
            return ControlDeUnicidad(query, parametros);
        }*/

        public bool pasoControlCodPostalDeSucu(String cp, Decimal sucuID)
        {
            String query = "Select count(*) From AMBDA.Sucursal Where sucu_cod_postal = @codPostal And sucu_id <> @sucu";
            parametros.Clear();
            parametros.Add(new SqlParameter("@codPostal", Convert.ToDecimal(cp)));
            parametros.Add(new SqlParameter("@sucu", sucuID));
            return ControlDeUnicidad(query, parametros);
        }

        public Boolean importeFacturaCorrecto(Decimal nroFactura, Double importe)
        {
            String query = "Select count(*) From AMBDA.Factura Where fact_nro = @nroFactura And fact_total = @importe";
            parametros.Clear();
            parametros.Add(new SqlParameter("@nroFactura", nroFactura));
            parametros.Add(new SqlParameter("@importe", importe));
            if (Convert.ToDecimal(builderDeComandos.Crear(query, parametros).ExecuteScalar()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean fechaFacturaCorrecta(Decimal nroFactura, DateTime fecha)
        {
            String query = "Select count(*) From AMBDA.Factura Where fact_nro = @nroFactura And fact_fecha_venc = @fecha";
            parametros.Clear();
            parametros.Add(new SqlParameter("@nroFactura", nroFactura));
            parametros.Add(new SqlParameter("@fecha", fecha));
            if (Convert.ToDecimal(builderDeComandos.Crear(query, parametros).ExecuteScalar()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            return this.SelectDataTable("c.clie_dni Dni, c.clie_nombre Nombre, c.clie_apellido Apellido, c.clie_fecha_nacimiento FechaDeNacimiento, c.clie_mail Mail, c.clie_telefono Telefono, c.clie_direc Direccion, c.clie_cod_postal CodigoPostal, c.clie_habilitado Habilitado"
                , "AMBDA.Cliente c"
                , "c.clie_dni > 0" + filtro);
        }

        public DataTable SelectClientesParaFiltro()
        {
            return this.SelectClientesParaFiltroConFiltro("");
        }

        public DataTable SelectFacturasParaFiltroConFiltro(String filtro)
        {
            //deberia funcionar con el generico
            parametros.Clear();
            command = builderDeComandos.Crear("SELECT fact_nro as 'nro factura', (select clie_dni from AMBDA.Cliente where clie_id = fact_cliente) as 'dni cliente', (select empr_nombre from AMBDA.Empresa where empr_id = fact_empresa) as 'empresa', fact_fecha as 'fecha alta', fact_fecha_venc as 'fecha vencimiento', fact_total as 'importe total'"
            + " FROM AMBDA.Factura WHERE fact_cobrada <> 1 and fact_rendicion is null " + filtro, parametros);
            command.CommandTimeout = 0;
            DataSet datos = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(datos);
            return datos.Tables[0];
        }

        public DataTable SelectFacturasParaFiltro()
        {
            return this.SelectFacturasParaFiltroConFiltro("");
        }

        public DataTable SelectEmpresasParaFiltroConFiltro(String filtro)
        {
            return this.SelectDataTable("e.empr_cuit Cuit, e.empr_nombre Nombre, e.empr_direc Direccion, e.empr_rubro Rubro, e.empr_cod_postal CodigoPostal, e.empr_habilitada Habilitada"
                , "AMBDA.Empresa e"
                , "e.empr_id > 0" + filtro);
        }

        public DataTable SelectEmpresasParaFiltro()
        {
            return this.SelectEmpresasParaFiltroConFiltro("");
        }

        public DataTable SelectSucursalParaFiltroConFiltro(String filtro)
        {
            return this.SelectDataTable("s.sucu_id ID, s.sucu_nombre Nombre, s.sucu_direc Direccion, s.sucu_cod_postal CodigoPostal, (case s.sucu_habilitada when 1 then 'Sí' else 'No' end) Habilitado"
                , "AMBDA.Sucursal s"
                , "s.sucu_id > 0" + filtro);
        }

        public DataTable SelectSucursalParaFiltro()
        {
            return this.SelectSucursalParaFiltroConFiltro("");
        }

        public DataTable SelectItems(String nroFactura)
        {
            return this.SelectDataTable("reng_id as id, reng_cantidad as Cantidad, reng_monto as 'Monto Total'", "AMBDA.Renglon", "reng_factura = (select fact_id from AMBDA.Factura where fact_nro = " + nroFactura + ")");
        }

        public void PagarFactura(Decimal cliente, Double importe, Decimal sucursal, Decimal medio, Decimal idFactura)
        {
            String query = "AMBDA.pagar_factura";
            parametros.Clear();
            parametros.Add(new SqlParameter("@usuario", UsuarioSesion.usuario.id));
            parametros.Add(new SqlParameter("@factura", idFactura));
            parametros.Add(new SqlParameter("@fecha", System.DateTime.Today));
            parametros.Add(new SqlParameter("@cliente", cliente));
            parametros.Add(new SqlParameter("@importe", importe));
            parametros.Add(new SqlParameter("@sucursal", sucursal));
            parametros.Add(new SqlParameter("@medio", medio));
            command = builderDeComandos.Crear(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }

        public void PagarFacturas(List<Decimal> facturas, Decimal cliente, Double importe, Decimal sucursal, Decimal medio)
        {
            foreach (Decimal factura in facturas)
            {
                PagarFactura(cliente, importe, sucursal, medio, factura);
            }
        }

    }
}