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
using PagoAgilFrba.AbmCliente;


namespace PagoAgilFrba
{
    public partial class MenuPrincipal : Form
    {
       
        private SqlCommand comando { get; set; }
        private Dictionary<String, Form> funcionalidades = new Dictionary<String, Form>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();
    
        public MenuPrincipal()
        {
            InitializeComponent();
            funcionalidades.Add("Agregar Cliente", new AbmCliente.AgregarCliente());
            //funcionalidades.Add("Comprar / Ofertar", new Comprar_Ofertar.BuscadorPublicaciones());
            // un formato asi pero anda saber que va aca
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            String accionElegida = comboBoxAccion.SelectedValue.ToString();
            
            this.Hide();
            funcionalidades[accionElegida].ShowDialog();
            this.Close();
          
        }

        private void botonCerrarSesion_Click(object sender, EventArgs e)
        {/*
            UsuarioSesion.Usuario.id = 0;
            UsuarioSesion.Usuario.nombre = null;
            UsuarioSesion.Usuario.rol = null;

            this.Hide();
            new Login.LoginForm().ShowDialog();
            this.Close();
            */
        }

        private void comboBoxAccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    
    }
}
