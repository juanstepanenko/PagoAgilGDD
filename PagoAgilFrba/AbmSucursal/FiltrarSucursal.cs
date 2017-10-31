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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class FiltrarSucursal : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();

        public FiltrarSucursal()
        {
            InitializeComponent();
        }

        private void SeleccionarSucursal_Load(object sender, EventArgs e)
        {
            CargarSucursal();
        }

        private void CargarSucursal()
        {
            dataGridView1.DataSource = comunicador.SelectSucursalParaFiltro();
            CargarColumnaModificacion();
            CargarColumnaEliminar();
        }

        private void CargarColumnaModificacion()
        {
            if (dataGridView1.Columns.Contains("Modificar"))
                dataGridView1.Columns.Remove("Modificar");
            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Modificar";
            botonColumnaModificar.Name = "Modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(botonColumnaModificar);
        }

        private void CargarColumnaEliminar()
        {
            if (dataGridView1.Columns.Contains("Eliminar"))
                dataGridView1.Columns.Remove("Eliminar");
            DataGridViewButtonColumn botonColumnaEliminar = new DataGridViewButtonColumn();
            botonColumnaEliminar.Text = "Eliminar";
            botonColumnaEliminar.Name = "Eliminar";
            botonColumnaEliminar.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(botonColumnaEliminar);
        }

        public Object SelectedItem { get; set; }



        private void AgregarSucursalForm_Load(object sender, EventArgs e)
        {
            
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            String filtro = CalcularFiltro();
            dataGridView1.DataSource = comunicador.SelectSucursalParaFiltroConFiltro(filtro);
        }

        private String CalcularFiltro()
        {
            String filtro = "";
            if (textBoxNombre.Text != "") filtro += "AND " + "s.sucu_nombre LIKE '" + textBoxNombre.Text + "%'";
            if (textBoxCalleNro.Text != "") filtro += "AND " + "d.direc_calleNro LIKE '" + textBoxCalleNro.Text + "%'";
            if (textBoxCodPos.Text != "") filtro += "AND " + "d.direc_cod_postal LIKE '" + textBoxCodPos.Text + "%'";
            //TODO:  DEVOLVER TODO SI NO HAY NINGUN FILTRO APLICADO
            return filtro;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text = "";
            textBoxCalleNro.Text = "";
            textBoxCodPos.Text = "";
            CargarSucursal();
        }

        private void boton_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SucursalForm().ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == dataGridView1.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                Decimal idSucursalAModificar = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToDecimal();
                new ModificarSucursal(idSucursalAModificar).ShowDialog();
                CargarSucursal();
                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                Decimal idSucursalAModificar = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToDecimal();
                Boolean resultado = comunicador.EliminarEmpresa(Convert.ToDecimal(idSucursalAModificar));
                if (resultado) MessageBox.Show("Se elimino correctamente");
                CargarSucursal();
                return;
            }
        }
        
    }
}
