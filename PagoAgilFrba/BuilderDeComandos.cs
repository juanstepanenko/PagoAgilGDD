using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoAgilFrba
{
    class BuilderDeComandos
    {
        public SqlCommand command { get; set; }
        private ConexionDB conexion = new ConexionDB();

        public SqlCommand Crear(string sqlTexto, IList<SqlParameter> parametros)
        {
            this.command = new SqlCommand();
            this.command.CommandText = sqlTexto;
            if (parametros != null)
            {
                foreach (SqlParameter parametro in parametros)
                {
                    this.command.Parameters.Add(parametro);
                }
            }
            if (this.command.Connection == null) this.command.Connection = conexion.AbrirConexion();

            return this.command;
        }

        /* ESTO SE USA ASI POR EJEMPLO: ------> esto iria en la clase ComunicadorConDB.cs
        
        private String query;
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private SqlParameter parametroOutput;
        private SqlCommand command;
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();

        public Decimal CrearUsuario()
        {
            query = "LOS_SUPER_AMIGOS.crear_usuario";
            parametros.Clear();
            parametroOutput = new SqlParameter("@usuario_id", SqlDbType.Decimal);
            parametroOutput.Direction = ParameterDirection.Output;
            parametros.Add(parametroOutput);
            command = builderDeComandos.Crear(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            return (Decimal)parametroOutput.Value;
        }
         
        */
    }
}
