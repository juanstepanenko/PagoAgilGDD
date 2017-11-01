using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class Estadisticas : Form
    {
        private String query;
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private SqlParameter parametroOutput;
        private SqlCommand command; // se usa para interactuar con la DB
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();
        List<string> meses = new List<string>();

        public Estadisticas()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
            this.numericUpDown1.Maximum = int.MaxValue;
            this.numericUpDown1.Value = 2017;
        }


        private void button1_Click(object sender, EventArgs e)
        {
           this.Hide();
           new MenuPrincipal().ShowDialog();
           this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            query = "AMBDA.listados";
            parametros.Clear();
            parametros.Add(new SqlParameter("@anio", numericUpDown1.Value));
            parametros.Add(new SqlParameter("@nro_trim", numericUpDown2.Value));
            parametros.Add(new SqlParameter("@tipoListado", comboBox1.SelectedIndex));
            command = builderDeComandos.Crear(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            this.dataGridView1.DataSource = table;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.AllowUserToAddRows = false;
        }

    }
}
