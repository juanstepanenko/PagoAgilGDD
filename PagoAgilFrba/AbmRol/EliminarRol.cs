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

namespace PagoAgilFrba.AbmRol
{
    public partial class EliminarRol : Form
    {
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();

        public Object SelectedItem { get; set; }

        public EliminarRol()
        {
            InitializeComponent();
        }

        private void EliminarRolForm_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            DataSet roles = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            command = builderDeComandos.Crear("SELECT DISTINCT rol_nombre FROM AMBDA.Rol  where rol_habilitado = 1", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(roles);
            comboBoxRol.DataSource = roles.Tables[0].DefaultView;
            comboBoxRol.ValueMember = "rol_nombre";
            comboBoxRol.SelectedIndex = -1;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RolForm().ShowDialog();
            this.Close();
        }

        private void botonDeshabilitar_Click(object sender, EventArgs e)
        {
            String rolElegido = this.comboBoxRol.Text;

            parametros.Clear();
            parametros.Add(new SqlParameter("@rol_nombre", rolElegido));

            String sql = "UPDATE AMBDA.Rol SET rol_habilitado = 0 WHERE rol_nombre = @rol_nombre";

            int filas_afectadas = 0;

            filas_afectadas = builderDeComandos.Crear(sql, parametros).ExecuteNonQuery();
            if (filas_afectadas != -1)
            {
                MessageBox.Show("Deshabilitado rol " + rolElegido);
            }
            else
            {
                MessageBox.Show("Error");
            }
            /*
            parametros.Clear();
            parametros.Add(new SqlParameter("@nombre", rolElegido));

            // Borramos el rol en los usuarios que lo tienen
            String sql2 = "DELETE AMBDA.RolxUsuario WHERE rol_id = (SELECT rol_id FROM AMBDA.Rol WHERE rol_nombre = @nombre and rol_habilitado = 0)";

            filas_afectadas = builderDeComandos.Crear(sql2, parametros).ExecuteNonQuery();
            if (filas_afectadas != -1)
            {
                MessageBox.Show("Se quito el rol " + rolElegido + " a " + filas_afectadas + " usuarios porque fue deshabilitado");
            }
            else
            {
                MessageBox.Show("Error");
            }*/
            CargarRoles();
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelRol_Click(object sender, EventArgs e)
        {

        }

    }
}
