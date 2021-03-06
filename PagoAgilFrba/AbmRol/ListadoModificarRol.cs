﻿using System;
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
    public partial class ListadoModificarRol : Form
    {
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();

        public Object SelectedItem { get; set; }

        public ListadoModificarRol()
        {
            InitializeComponent();
        }

        private void ListadoModificarRol_Load(object sender, EventArgs e)
        {
            comboBoxEstadoRoles.Items.Add("Habilitado");
            comboBoxEstadoRoles.Items.Add("Deshabilitado");         
        }

        private void comboBoxEstadoRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CargarRoles(int estadoRol)
        {
            DataSet roles = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();            
            
            parametros.Clear();
            parametros.Add(new SqlParameter("@rol_habilitado", estadoRol));

            command = builderDeComandos.Crear("SELECT DISTINCT * FROM AMBDA.Rol WHERE rol_habilitado = @rol_habilitado", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(roles);
            dataGridViewResultadosBusqueda.DataSource = roles.Tables[0].DefaultView;
            AgregarBotonEditar();
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            if (this.comboBoxEstadoRoles.Text == "")
            {
                MessageBox.Show("No seleccíono un estado de rol para buscar");
            }
            else
            {
                if (this.comboBoxEstadoRoles.Text == "Habilitado")
                {
                    CargarRoles(1);
                }
                else
                { 
                    CargarRoles(0);
                }
            }
            
        }

        private void AgregarBotonEditar()
        {
            if (dataGridViewResultadosBusqueda.Columns.Contains("Editar"))
                dataGridViewResultadosBusqueda.Columns.Remove("Editar");
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.HeaderText = "Editar";
                buttons.Text = "Editar";
                buttons.Name = "Editar";
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Standard;
                buttons.CellTemplate.Style.BackColor = Color.Honeydew;                
            }

            dataGridViewResultadosBusqueda.Columns.Add(buttons);
            dataGridViewResultadosBusqueda.CellClick +=
                new DataGridViewCellEventHandler(dataGridView1_CellClick);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridViewResultadosBusqueda.Columns["Editar"].Index)
            {
                String nombreRolAEditar = dataGridViewResultadosBusqueda.Rows[e.RowIndex].Cells["rol_nombre"].Value.ToString();
                this.Hide();
                new ModificarRol(nombreRolAEditar).ShowDialog();
            }
            
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RolForm().ShowDialog();
            this.Close();
        }
    }
}
