using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmRol
{
    public partial class AgregarRol : Form
    {
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();

        public AgregarRol()
        {
            InitializeComponent();
        }

        private void AgregarRol_Load_1(object sender, EventArgs e)
        {
            CargarFuncionalidades();
        }

        private void CargarFuncionalidades()
        {
            DataSet funcionalidades = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            command = builderDeComandos.Crear("SELECT DISTINCT func_descripcion FROM AMBDA.Funcionalidad", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(funcionalidades);
            checkedListBoxFuncionalidades.DataSource = funcionalidades.Tables[0].DefaultView;
            checkedListBoxFuncionalidades.ValueMember = "func_descripcion";
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RolForm().ShowDialog();
            this.Close();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO AMBDA.Rol(rol_nombre, rol_habilitado) VALUES (@rol, 1)";
            String nombreRol = this.textBoxRol.Text;
            parametros.Clear();
            parametros.Add(new SqlParameter("@rol", nombreRol));
            builderDeComandos.Crear(sql, parametros).ExecuteNonQuery();

            foreach (DataRowView funcionalidad in this.checkedListBoxFuncionalidades.CheckedItems)
            {
                parametros.Clear();
                parametros.Add(new SqlParameter("@rol", nombreRol));

                parametros.Add(new SqlParameter("@funcionalidad", funcionalidad.Row["func_descripcion"] as String));

                String sql2 = "INSERT INTO AMBDA.RolxFunc(func_id, rol_id) VALUES ((SELECT func_id FROM AMBDA.Funcionalidad WHERE func_descripcion = @funcionalidad), (SELECT rol_id FROM AMBDA.Rol WHERE rol_nombre = @rol))";

                builderDeComandos.Crear(sql2, parametros).ExecuteNonQuery();
            }
            MessageBox.Show("Se creo el rol " + nombreRol);
            BorrarDatosIngresados();
        }

        private void checkedListBoxFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            BorrarDatosIngresados();
        }

        private void BorrarDatosIngresados()
        {
            textBoxRol.Clear();
            for (int i = 0; i < checkedListBoxFuncionalidades.Items.Count; i++)
            {
                checkedListBoxFuncionalidades.SetItemChecked(i, false);
            }
        }
    }
}
