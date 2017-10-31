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

namespace PagoAgilFrba.AbmFactura
{
    public partial class FiltroFactura : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();

        public Object SelectedItem { get; set; }

        public FiltroFactura()
        {
            InitializeComponent();
        }

        private void Inicializacion_Load(object sender, EventArgs e)
        {
            CargarFacturas();
            CargarEmpresas();
        }

        private void CargarEmpresas()
        {
            DataSet empresas = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            command = builderDeComandos.Crear("SELECT DISTINCT empr_nombre FROM AMBDA.Empresa", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(empresas);
            comboBoxEmpresas.DataSource = empresas.Tables[0].DefaultView;
            comboBoxEmpresas.ValueMember = "empr_nombre";
            comboBoxEmpresas.SelectedIndex = -1;
        }


        private void CargarFacturas()
        {
            dataGridView_Factura.DataSource = comunicador.SelectFacturasParaFiltro();
            CargarColumnaModificacion();
            CargarColumnaEliminar();
        }

        private void CargarColumnaModificacion()
        {
            if (dataGridView_Factura.Columns.Contains("Modificar"))
                dataGridView_Factura.Columns.Remove("Modificar");
            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Modificar";
            botonColumnaModificar.Name = "Modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            dataGridView_Factura.Columns.Add(botonColumnaModificar);
        }

        private void CargarColumnaEliminar()
        {
            if (dataGridView_Factura.Columns.Contains("Eliminar"))
                dataGridView_Factura.Columns.Remove("Eliminar");
            DataGridViewButtonColumn botonColumnaEliminar = new DataGridViewButtonColumn();
            botonColumnaEliminar.Text = "Eliminar";
            botonColumnaEliminar.Name = "Eliminar";
            botonColumnaEliminar.UseColumnTextForButtonValue = true;
            dataGridView_Factura.Columns.Add(botonColumnaEliminar);
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            String filtro = CalcularFiltro();
            dataGridView_Factura.DataSource = comunicador.SelectFacturasParaFiltroConFiltro(filtro);
        }

        private String CalcularFiltro()
        {
            String filtro = "";
            if (textBox_dni.Text != "") filtro += " AND " + "fact_cliente LIKE (select clie_id from AMBDA.Cliente where clie_dni = " + textBox_dni.Text + ")";
            if (this.comboBoxEmpresas.Text != "") filtro += "AND " + "fact_empresa LIKE (select empr_cuit from AMBDA.Empresa where empr_nombre = '" + this.comboBoxEmpresas.Text + "')";
            if (textBox_nrofact.Text != "") filtro += " AND " + "fact_nro LIKE " + textBox_nrofact.Text;
            return filtro;
        }

        private void dataGridView_Factura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == dataGridView_Factura.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                String nroFacturaAModificar = dataGridView_Factura.Rows[e.RowIndex].Cells["nro factura"].Value.ToString();
                new ModificarFactura(nroFacturaAModificar).ShowDialog();
                CargarFacturas();
                return;
            }
            if (e.ColumnIndex == dataGridView_Factura.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                String nroFacturaAEliminar = dataGridView_Factura.Rows[e.RowIndex].Cells["nro factura"].Value.ToString();
                Boolean resultado = comunicador.EliminarFactura(Convert.ToDecimal(nroFacturaAEliminar));
                if (resultado) MessageBox.Show("Se elimino correctamente");
                CargarFacturas();
                return;
            }
        }

        private void button_Limpiar_Click_1(object sender, EventArgs e)
        {
            textBox_dni.Text = "";
            comboBoxEmpresas.Text = "";
            textBox_nrofact.Text = "";
            CargarFacturas();
        }

        private void button_Cancelar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new FacturaForm().ShowDialog();
            this.Close();
        }

        private void comboBoxEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_Volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FacturaForm().ShowDialog();
            this.Close();
        }
    }
}
