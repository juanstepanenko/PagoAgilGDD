using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmFactura
{
    public partial class FiltroFactura : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();

        public FiltroFactura()
        {
            InitializeComponent();
        }

        private void FiltroFactura_Load(object sender, EventArgs e)
        {
            CargarFacturas();
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
            if (textBox_dni.Text != "") filtro += "AND " + "c.fact_cliente LIKE '" + textBox_dni.Text + "%'";
            //if (textBox_Apellido.Text != "") filtro += "AND " + "c.clie_apellido LIKE '" + textBox_Apellido.Text + "%'";
            if (textBox_nrofact.Text != "") filtro += "AND " + "c.fact_nro LIKE '" + textBox_nrofact.Text + "%'";
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
                String nroFacturaAEliminar = dataGridView_Factura.Rows[e.RowIndex].Cells["nro factura"].Value.ToString(); //ojo ver
                Boolean resultado = comunicador.EliminarFactura(Convert.ToDecimal(nroFacturaAEliminar));
                if (resultado) MessageBox.Show("Se elimino correctamente");
                CargarFacturas();
                return;
            }
        }

        private void button_Limpiar_Click_1(object sender, EventArgs e)
        {
            textBox_dni.Text = "";
            //textBox_Apellido.Text = "";
            textBox_nrofact.Text = "";
            CargarFacturas();
        }

        private void button_Cancelar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new FacturaForm().ShowDialog();
            this.Close();
        }
    }
}
