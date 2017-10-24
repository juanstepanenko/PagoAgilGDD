using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PagoAgilFrba.Objetos;

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

        public Decimal Crear(Comunicable objeto) //el general para todos los objetos, por ahora solo cliente
        {
            query = objeto.GetQueryCrear();
            parametros.Clear();
            parametros = objeto.GetParametros(); //agarro todos los campos de cliente menos el dni
            parametroOutput = new SqlParameter("@id", SqlDbType.Decimal); //aca si, pero de donde saco estos @bla?
            parametroOutput.Direction = ParameterDirection.Output;
            parametros.Add(parametroOutput);
            command = builderDeComandos.Crear(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery(); // esta query al ejecutarse no devuelve nada, es un sp
            //--------------> ME DIJO QUE crear_cliente TIENE DEMASIADOS ARGUMENTOS, EN ESTA LINEA
            return (Decimal)parametroOutput.Value; // devuelve el valor de parametroOutput, cual es? clie_dni? no, un sql parameter que es el dni? pero en numero
        }

        public Decimal CrearCliente(Cliente cliente)
        {
            /*if (!pasoControlDeRegistro(cliente.GetIdTipoDeDocumento(), cliente.GetNumeroDeDocumento()))
                throw new ClienteYaExisteException();

            if (!pasoControlDeUnicidad(cliente.GetTelefono(), "telefono", "Cliente"))
                throw new TelefonoYaExisteException();
             
            VER QUE CONTROLES TIENE QUE PASAR 
             
             */

            return this.Crear(cliente);
        }

        public Object SelectFromWhere(String que, String deDonde, String param1, String param2)
        {
            query = "SELECT " + que + " FROM AMBDA." + deDonde + " WHERE " + param1 + " = @" + param1;
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + param1, param2));
            return builderDeComandos.Crear(query, parametros).ExecuteScalar();
        }
    }
}
