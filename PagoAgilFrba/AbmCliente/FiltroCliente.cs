using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class FiltroCliente : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();

        public FiltroCliente()
        {
            InitializeComponent();
        }

        private void FiltroCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            dataGridView_Cliente.DataSource = comunicador.SelectClientesParaFiltro();
            CargarColumnaModificacion();
            CargarColumnaEliminar();
        }

        private void CargarColumnaModificacion()
        {
            if (dataGridView_Cliente.Columns.Contains("Modificar"))
                dataGridView_Cliente.Columns.Remove("Modificar");
            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Modificar";
            botonColumnaModificar.Name = "Modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            dataGridView_Cliente.Columns.Add(botonColumnaModificar);
        }

        private void CargarColumnaEliminar()
        {
            if (dataGridView_Cliente.Columns.Contains("Eliminar"))
                dataGridView_Cliente.Columns.Remove("Eliminar");
            DataGridViewButtonColumn botonColumnaEliminar = new DataGridViewButtonColumn();
            botonColumnaEliminar.Text = "Eliminar";
            botonColumnaEliminar.Name = "Eliminar";
            botonColumnaEliminar.UseColumnTextForButtonValue = true;
            dataGridView_Cliente.Columns.Add(botonColumnaEliminar);
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            String filtro = CalcularFiltro();
            dataGridView_Cliente.DataSource = comunicador.SelectClientesParaFiltroConFiltro(filtro);
        }

        private String CalcularFiltro()
        {
            String filtro = "";
            if (textBox_Nombre.Text != "") filtro += "AND " + "c.clie_nombre LIKE '" + textBox_Nombre.Text + "%'";
            if (textBox_Apellido.Text != "") filtro += "AND " + "c.clie_apellido LIKE '" + textBox_Apellido.Text + "%'";
            if (textBox_NumeroDeDoc.Text != "") filtro += "AND " + "c.clie_dni LIKE '" + textBox_NumeroDeDoc.Text + "%'";
            return filtro;
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_Nombre.Text = "";
            textBox_Apellido.Text = "";
            textBox_NumeroDeDoc.Text = "";
            CargarClientes();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void dataGridView_Cliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == dataGridView_Cliente.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                String idClienteAModificar = dataGridView_Cliente.Rows[e.RowIndex].Cells["Dni"].Value.ToString();
                new ModificarCliente(idClienteAModificar).ShowDialog();
                CargarClientes();
                return;
            }
            if (e.ColumnIndex == dataGridView_Cliente.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                String idClienteAEliminar = dataGridView_Cliente.Rows[e.RowIndex].Cells["Dni"].Value.ToString();
                Boolean resultado = comunicador.EliminarCliente(Convert.ToDecimal(idClienteAEliminar));
                if (resultado) MessageBox.Show("Se elimino correctamente");
                CargarClientes();
                return;
            }
        }

    }
}
