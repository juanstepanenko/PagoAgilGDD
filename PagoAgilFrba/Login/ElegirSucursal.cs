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

namespace PagoAgilFrba.Login
{
    public partial class ElegirSucursal : Form
    {
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();

        public Object SelectedItem { get; set; }

        public ElegirSucursal()
        {
            InitializeComponent();

        }

        private void ElegirSucursal_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            DataSet sucursales = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@username", UsuarioSesion.usuario.nombre));
            command = builderDeComandos.Crear("SELECT s.sucu_nombre from AMBDA.Sucursal s, AMBDA.SucursalxUsuario su WHERE s.sucu_habilitada = 1 AND (SELECT usua_id FROM AMBDA.Usuario WHERE usua_username = @username) = su.usua_id and s.sucu_id = su.sucu_id ", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(sucursales, "Sucursal");
            comboBoxRol.DataSource = sucursales.Tables[0].DefaultView;
            comboBoxRol.ValueMember = "sucu_nombre";
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            String sucursalElegida = comboBoxRol.SelectedValue.ToString();
            UsuarioSesion.Usuario.sucursal = sucursalElegida;

            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

    }
}
