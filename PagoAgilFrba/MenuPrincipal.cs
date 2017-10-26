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
            funcionalidades.Add("Editar cliente", new AbmCliente.FiltroCliente());
            //funcionalidades.Add("Comprar / Ofertar", new Comprar_Ofertar.BuscadorPublicaciones());
            // un formato asi pero anda saber que va aca
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            DataSet acciones = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            /* esto se completa cuando esten los roles y funcionalidades
            String funcionalidadesUsuario = "select f.nombre from LOS_SUPER_AMIGOS.Rol r, LOS_SUPER_AMIGOS.Funcionalidad_x_Rol fr,LOS_SUPER_AMIGOS.Funcionalidad f where r.id = fr.rol_id and f.id = fr.funcionalidad_id and r.nombre = @unRol";
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@unRol", UsuarioSesion.Usuario.rol));
            comando = builderDeComandos.Crear(funcionalidadesUsuario, parametros);

            adapter.SelectCommand = comando;
            adapter.Fill(acciones, "Funcionalidad");
            comboBoxAccion.DataSource = acciones.Tables[0].DefaultView;
            comboBoxAccion.ValueMember = "nombre";
            */
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
