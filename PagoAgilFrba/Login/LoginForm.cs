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

namespace PagoAgilFrba.Login
{
    public partial class LoginForm : Form
    {

        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();

        public LoginForm()
        {
            InitializeComponent();
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void limpiarCampos()
        {
            textBoxUsuario.Clear();
            textBoxContaseña.Clear();
        }

        private void botonIngresar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.textBoxUsuario.Text == "")
                {
                    MessageBox.Show("Debe ingresar un usuario");
                    return;
                }

                if (this.textBoxContaseña.Text == "")
                {
                    MessageBox.Show("Debe ingresar una contraseña");
                    return;
                }

                String usuario = this.textBoxUsuario.Text;
                String contraseña = this.textBoxContaseña.Text;


                String query = "AMBDA.login";
                IList<SqlParameter> parametros = new List<SqlParameter>();
                SqlCommand command;
                parametros.Clear();
                parametros.Add(new SqlParameter("@usuario", usuario));
                parametros.Add(new SqlParameter("@password_ingresada", contraseña));
                command = builderDeComandos.Crear(query, parametros);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
               
                // Busca los roles
                parametros.Clear();
                parametros.Add(new SqlParameter("@username", usuario));

                String consultaRoles = "SELECT COUNT(rol_id) FROM AMBDA.RolxUsuario WHERE (SELECT usua_id FROM AMBDA.Usuario WHERE usua_username = @username) = usua_id";
                int cantidadDeRoles = (int)builderDeComandos.Crear(consultaRoles, parametros).ExecuteScalar();

                if (cantidadDeRoles > 1)
                {
                    this.Hide();
                    new ElegirRol().ShowDialog();
                    this.Close();
                }
                else
                {
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@username", usuario));
                    String rolDeUsuario = "SELECT r.rol_nombre FROM AMBDA.Rol r, AMBDA.RolxUsuario ru, AMBDA.Usuario u WHERE r.rol_id = ru.rol_id AND ru.usua_id = u.usua_id AND u.usua_username = @username";
                    String rolUser = (String)builderDeComandos.Crear(rolDeUsuario, parametros).ExecuteScalar();
                    UsuarioSesion.Usuario.rol = rolUser;
                    if (UsuarioSesion.Usuario.rol == null)
                    {
                        MessageBox.Show("Usted no tiene roles para iniciar sesion");
                        return;
                    }

                    this.Hide();
                    new MenuPrincipal().ShowDialog();
                    this.Close();

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
                this.limpiarCampos();
            }

        }

        private void textBoxContaseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void botonRegistrarse_Click(object sender, EventArgs e)
        {
            this.Hide();
            //new Registro_de_Usuario.RegistrarUsuario().ShowDialog();
            this.Close();
        }
    }
}

