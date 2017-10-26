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

        public Decimal Crear(Comunicable objeto) //el general para todos los objetos, por ahora solo cliente
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

        public Object SelectFromWhere(String que, String deDonde, String param1, String param2)
        {
            query = "SELECT " + que + " FROM AMBDA." + deDonde + " WHERE " + param1 + " = @" + param1;
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + param1, param2));
            return builderDeComandos.Crear(query, parametros).ExecuteScalar();
        }

        public Decimal CrearDireccion(Direccion direccion)
        {
            return this.Crear(direccion);
        }


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

        private bool pasoControlDeRegistroDni(String nrodni)
        {
            query = "SELECT COUNT(*) FROM AMBDA.Cliente WHERE clie_dni = @" + nrodni;
            parametros.Clear();
            parametros.Add(new SqlParameter("@" + nrodni, Convert.ToDecimal(nrodni)));
            return ControlDeUnicidad(query, parametros);
        }
    }
}
