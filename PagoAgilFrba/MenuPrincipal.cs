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
            funcionalidades.Add("ABM Roles", new AbmRol.RolForm());
            funcionalidades.Add("ABM Clientes", new AbmCliente.ClienteForm());
            funcionalidades.Add("ABM Empresas", new AbmEmpresa.AgregarEmpresa());
            //funcionalidades.Add("ABM Sucursales", new AbmCliente.ClienteForm());
            //funcionalidades.Add("ABM Facturas", new AbmCliente.ClienteForm());
            //funcionalidades.Add("Registro de Pago de Facturas", new AbmCliente.ClienteForm());
            //funcionalidades.Add("Rendición de facturas cobradas", new AbmCliente.ClienteForm());
            //funcionalidades.Add("Listado estadístico", new AbmCliente.ClienteForm());

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            DataSet acciones = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            // esto se completa cuando esten los roles y funcionalidades
            String funcionalidadesUsuario = "select f.func_descripcion from AMBDA.Rol r, AMBDA.RolxFunc fr, AMBDA.Funcionalidad f where r.rol_id = fr.rol_id and f.func_id = fr.func_id and r.rol_nombre = @unRol";
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@unRol", UsuarioSesion.Usuario.rol));
            comando = builderDeComandos.Crear(funcionalidadesUsuario, parametros);

            adapter.SelectCommand = comando;
            adapter.Fill(acciones, "Funcionalidad");
            comboBoxAccion.DataSource = acciones.Tables[0].DefaultView;
            comboBoxAccion.ValueMember = "func_descripcion";
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            String accionElegida = comboBoxAccion.SelectedValue.ToString();
            
            this.Hide();
            funcionalidades[accionElegida].ShowDialog();
            this.Close();
          
        }

        private void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            UsuarioSesion.Usuario.id = 0;
            UsuarioSesion.Usuario.nombre = null;
            UsuarioSesion.Usuario.rol = null;
            UsuarioSesion.Usuario.sucursal = null;

            this.Hide();
            new Login.LoginForm().ShowDialog();
            this.Close();
        }

        private void comboBoxAccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    
    }
}
