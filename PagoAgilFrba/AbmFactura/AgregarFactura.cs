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
using PagoAgilFrba.Objetos;
using PagoAgilFrba.Excepciones;

namespace PagoAgilFrba.AbmFactura
{
    public partial class AgregarFactura : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private IList<Objetos.Item> items = new List<Objetos.Item>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();
        Double total = 0;
        public Object SelectedItem { get; set; }

        public AgregarFactura()
        {
            InitializeComponent();
        }

        private void AgregarFactura_Load(object sender, EventArgs e)
        {
            label10.Text = DateTime.Today.ToShortDateString();
            textBox_TOTAL.Text = "0";
            CargarEmpresas();
            InicializarDataGrind();
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

        private void button_FechaVenc_Click(object sender, EventArgs e)
        {
            monthCalendar_FechaVenc.Visible = true;
        }

        private void monthCalendar_FechaVenc_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            textBox_venc.Text = e.Start.ToShortDateString();
            monthCalendar_FechaVenc.Visible = false;
        }

        private void comboBoxEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InicializarDataGrind()
        {
            dataGridView_Item.ColumnCount = 3;
            dataGridView_Item.ColumnHeadersVisible = true;
            dataGridView_Item.Columns[0].Name = "Cantidad";
            dataGridView_Item.Columns[1].Name = "Monto total";
            dataGridView_Item.Columns[2].Name = "Eliminar";
        }

        private void CargarColumnaEliminar()
        {
            if (dataGridView_Item.Columns.Contains("Eliminar"))
                dataGridView_Item.Columns.Remove("Eliminar");
            DataGridViewButtonColumn botonColumnaEliminar = new DataGridViewButtonColumn();
            botonColumnaEliminar.Text = "Eliminar";
            botonColumnaEliminar.Name = "Eliminar";
            botonColumnaEliminar.UseColumnTextForButtonValue = true;
            dataGridView_Item.Columns.Add(botonColumnaEliminar);
        }


        private void dataGridView_Item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView_Item.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                int indiceItemAEliminar = e.RowIndex;
                this.items.Remove(this.items[indiceItemAEliminar]);
                MessageBox.Show("Se elimino correctamente");
                dataGridView_Item.Rows.RemoveAt(indiceItemAEliminar);
                return;
            }
        }

        private void button_agregar_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            try
            {
                item.setMonto(textBox_monto.Text);
                item.setCantidad(textBox_cantidad.Text);
            }
            catch (FormatoInvalidoException exception)
            {
                MessageBox.Show("Datos mal ingresados en: " + exception.Message);
                return;
            }
            catch (CantidadNulaException exception)
            {
                MessageBox.Show("No se puede ingresar una cantidad igual a 0 en "+exception.Message);
                return;
            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta ingresar el campo " + exception.Message);
                return;
            }
            string[] row = new string[] { item.getCantidad(), item.getMonto()};
            dataGridView_Item.Rows.Add(row);
            this.items.Add(item);
            CargarColumnaEliminar();
            total = total + Convert.ToDouble(item.getMonto());
            textBox_TOTAL.Text = total.ToString();
            textBox_monto.Text = "";
            textBox_cantidad.Text = "";
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String dni = textBox_cliente.Text;
            String empresa = comboBoxEmpresas.Text;
            String nrofactura = textBox_nrofact.Text;
            DateTime fechaAlta, fechaVencimiento;
            DateTime.TryParse(label10.Text, out fechaAlta);
            DateTime.TryParse(textBox_venc.Text, out fechaVencimiento);
            //items
            //total
            
            //Crea Factura
        }


    }
}
