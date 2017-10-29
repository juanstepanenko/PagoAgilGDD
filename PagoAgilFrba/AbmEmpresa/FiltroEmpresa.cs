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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class FiltroEmpresa : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();

        public FiltroEmpresa()
        {
            InitializeComponent();
        }

        private void FiltroEmpresa_Load(object sender, EventArgs e)
        {
            CargarEmpresas();
        }

        private void CargarEmpresas()
        {
            dataGridView_Empresa.DataSource = comunicador.SelectEmpresasParaFiltro();
            CargarColumnaModificacion();
            CargarColumnaEliminar();
        }

        private void CargarColumnaModificacion()
        {
            if (dataGridView_Empresa.Columns.Contains("Modificar"))
                dataGridView_Empresa.Columns.Remove("Modificar");
            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Modificar";
            botonColumnaModificar.Name = "Modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            dataGridView_Empresa.Columns.Add(botonColumnaModificar);
        }

        private void CargarColumnaEliminar()
        {
            if (dataGridView_Empresa.Columns.Contains("Eliminar"))
                dataGridView_Empresa.Columns.Remove("Eliminar");
            DataGridViewButtonColumn botonColumnaEliminar = new DataGridViewButtonColumn();
            botonColumnaEliminar.Text = "Eliminar";
            botonColumnaEliminar.Name = "Eliminar";
            botonColumnaEliminar.UseColumnTextForButtonValue = true;
            dataGridView_Empresa.Columns.Add(botonColumnaEliminar);
        }

        public Object SelectedItem { get; set; }



        private void AgregarEmpresaForm_Load(object sender, EventArgs e)
        {
            CargarRubro();
        }


        private void CargarRubro()
        {
            DataSet rubros = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            command = builderDeComandos.Crear("SELECT DISTINCT rubr_id FROM AMBDA.Rubro ", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(rubros);
            combo_Rubro.DataSource = rubros.Tables[0].DefaultView;
            combo_Rubro.ValueMember = "rubr_id";
            combo_Rubro.SelectedIndex = -1;
        }


        private void button_Buscar_Click(object sender, EventArgs e)
        {
            String filtro = CalcularFiltro();
            dataGridView_Empresa.DataSource = comunicador.SelectEmpresasParaFiltroConFiltro(filtro);
        }

        private String CalcularFiltro()
        {
            String filtro = "";
            if (textBox_Nombre.Text != "") filtro += "AND " + "e.empr_nombre LIKE '" + textBox_Nombre.Text + "%'";
            if (textBox_Cuit.Text != "") filtro += "AND " + "e.empr_cuit LIKE '" + textBox_Cuit.Text + "%'";
            if (combo_Rubro.Text != "") filtro += "AND " + "e.empr_rubro LIKE '" + combo_Rubro.Text + "%'";
            return filtro;
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_Nombre.Text = "";
            textBox_Cuit.Text = "";
            combo_Rubro.Text = "";
            CargarEmpresas();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EmpresaForm().ShowDialog();
            this.Close();
        }

        private void dataGridView_Empresa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == dataGridView_Empresa.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                String cuitEmpresaAModificar = dataGridView_Empresa.Rows[e.RowIndex].Cells["Cuit"].Value.ToString();
                new ModificarEmpresa(cuitEmpresaAModificar).ShowDialog();
                CargarEmpresas();
                return;
            }
            if (e.ColumnIndex == dataGridView_Empresa.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                String cuitEmpresaAModificar = dataGridView_Empresa.Rows[e.RowIndex].Cells["Cuit"].Value.ToString();
                Boolean resultado = comunicador.EliminarEmpresa(Convert.ToDecimal(cuitEmpresaAModificar));
                if (resultado) MessageBox.Show("Se elimino correctamente");
                CargarEmpresas();
                return;
            }
        }
        private void combo_Rubro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
