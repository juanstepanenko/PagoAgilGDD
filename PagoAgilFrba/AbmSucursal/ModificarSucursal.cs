using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Objetos;
using PagoAgilFrba.Excepciones;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmSucursal
{
    public partial class ModificarSucursal : Form
    {
        private Decimal id;
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private Decimal idDireccion;
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();

        public ModificarSucursal(Decimal unId)
        {
            InitializeComponent();
            this.id = unId;
        }

        private void EditarSucursal_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            Sucursal sucursal = comunicador.ObtenerSucursal(id);

            this.idDireccion = sucursal.GetIdDireccion();
            textBoxName.Text = sucursal.GetNombreSucursal();
            CargarDireccion(idDireccion);
            checkBoxHab.Checked = Convert.ToBoolean(comunicador.SelectFromWhere("sucu_habilitada", "Sucursal", "sucu_id", id));
        }

        private void CargarDireccion(Decimal idDireccion)
        {
            Direccion direccion = comunicador.ObtenerDireccion(idDireccion);
            textBoxCalleNro.Text = direccion.GetCalleNro();
            textBoxPiso.Text = direccion.GetPiso();
            textBoxDto.Text = direccion.GetDepartamento();
            textBoxCP.Text = direccion.GetCodigoPostal();
            textBoxLoc.Text = direccion.GetLocalidad();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String nombre = textBoxName.Text;
            String numero = textBoxCalleNro.Text;
            String piso = textBoxPiso.Text;
            String departamento = textBoxDto.Text;
            String localidad = textBoxLoc.Text;
            String codigoPostal = textBoxCP.Text; ;
            Boolean habilitada = checkBoxHab.Checked;
            Boolean pudoModificar;

            // Update direccion
            try
            {
                Direccion direccion = new Direccion();
                direccion.SetCalleNro(numero);
                direccion.SetPiso(piso);
                direccion.SetDepartamento(departamento);
                direccion.SetLocalidad(localidad);
                direccion.SetCodigoPostal(codigoPostal);
                comunicador.Modificar(idDireccion, direccion);
            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                return;
            }
            catch (FormatoInvalidoException exception)
            {
                MessageBox.Show("Datos mal ingresados en: " + exception.Message);
                return;
            }


            // Update sucursal
            try
            {
                Sucursal sucursal = new Sucursal();
                sucursal.SetNombreSucursal(nombre);
                sucursal.SetId(id);
                sucursal.SetIdDireccion(idDireccion);
                sucursal.SetHabilitada(habilitada);
                pudoModificar = comunicador.ModificarSucursal(id, sucursal);
                if (pudoModificar) MessageBox.Show("La sucursal se modifico correctamente");
            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                return;
            }
            catch (FormatoInvalidoException exception)
            {
                MessageBox.Show("Datos mal ingresados en: " + exception.Message);
                return;
            }
            catch (CuitYaExisteException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
        }

        private void botonLimpiar_ClickM(object sender, EventArgs e)
        {
            CargarDatos();
            /*textBox_Nombre.Text = "";
            textBox_Cuit.Text = "";
            textBox_CalleNro.Text = "";
            textBox_Piso.Text = "";
            textBox_Departamento.Text = "";
            textBox_Localidad.Text = "";
            textBox_CodigoPostal.Text = "";
            combo_Rubro.Text = "";*/
        }

        private void botonCancelarM_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
