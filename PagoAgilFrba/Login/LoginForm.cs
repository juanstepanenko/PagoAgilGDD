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

                
                IList<SqlParameter> parametros = new List<SqlParameter>();
                SqlCommand command;

                String query = "AMBDA.login";
                parametros.Clear();
                parametros.Add(new SqlParameter("@usuario", usuario));
                parametros.Add(new SqlParameter("@password_ingresada", contraseña));
                command = builderDeComandos.Crear(query, parametros);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                command.Parameters.Clear();

                MessageBox.Show("Bienvenido " + usuario + "!");

                UsuarioSesion.Usuario.nombre = usuario;

                String query2 = ("SELECT usua_id FROM AMBDA.Usuario WHERE usua_username = @username");
                parametros.Clear();
                parametros.Add(new SqlParameter("@username", usuario));
                Decimal id = (Decimal)builderDeComandos.Crear(query2, parametros).ExecuteScalar();
                UsuarioSesion.Usuario.id = id;

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
                    
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@username", usuario));
                    String consultaSucursales = "SELECT COUNT(sucu_id) FROM AMBDA.SucursalxUsuario WHERE (SELECT usua_id FROM AMBDA.Usuario WHERE usua_username = @username) = usua_id";
                    int cantidadDeSucursales = (int)builderDeComandos.Crear(consultaSucursales, parametros).ExecuteScalar();

                    if (cantidadDeSucursales > 1)
                    {
                        this.Hide();
                        new ElegirSucursal().ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        parametros.Clear();
                        parametros.Add(new SqlParameter("@username", usuario));
                        String sucursalDeUsuario = "SELECT s.sucu_nombre FROM AMBDA.Sucursal s, AMBDA.SucursalxUsuario su, AMBDA.Usuario u WHERE s.sucu_id = su.sucu_id AND su.usua_id = u.usua_id AND u.usua_username = @username";
                        String sucursalUser = (String)builderDeComandos.Crear(sucursalDeUsuario, parametros).ExecuteScalar();
                        UsuarioSesion.Usuario.sucursal = sucursalUser;
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
    }
}

