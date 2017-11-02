using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoAgilFrba.Login
{
    public partial class ElegirRol : Form
    {
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();

        public Object SelectedItem { get; set; }

        public ElegirRol()
        {
            InitializeComponent();

        }

        private void ElegirRol_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            DataSet roles = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@username", UsuarioSesion.usuario.nombre));
            command = builderDeComandos.Crear("SELECT r.rol_nombre from AMBDA.Rol r, AMBDA.RolxUsuario ru WHERE r.rol_habilitado = 1 AND (SELECT usua_id FROM AMBDA.Usuario WHERE usua_username = @username) = ru.usua_id and r.rol_id = ru.rol_id ", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(roles, "Rol");
            comboBoxRol.DataSource = roles.Tables[0].DefaultView;
            comboBoxRol.ValueMember = "rol_nombre";
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            String rolElegido = comboBoxRol.SelectedValue.ToString();
            UsuarioSesion.Usuario.rol = rolElegido;

            this.Close();
        }
    }
}
