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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class AgregarEmpresa : Form
    {

        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private Decimal idDireccion;
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();

        public AgregarEmpresa()
        {
            InitializeComponent();
            //this.idDireccion = 0;
        }

        private void AgregarEmpresa_Load(object sender, EventArgs e)
        {

        }
        public Object SelectedItem { get; set; }

       

        private void AgregarEmpresaForm_Load(object sender, EventArgs e)
        {
            CargarRubro();
        }


        private void CargarRubro()
        {
            DataSet rubros = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            command = builderDeComandos.Crear("SELECT DISTINCT rubr_descripcion FROM AMBDA.Rubro ", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(rubros);
            combo_Rubro.DataSource = rubros.Tables[0].DefaultView;
            combo_Rubro.ValueMember = "rubr_descripcion";
            combo_Rubro.SelectedIndex = -1;
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String nombre = textBox_Nombre.Text;
            String cuit = textBox_Cuit.Text;
            String calleNro = textBox_CalleNro.Text;
            String piso = textBox_Piso.Text;
            String departamento = textBox_Departamento.Text;
            String localidad = textBox_Localidad.Text;
            String codigoPostal = textBox_CodigoPostal.Text;
            String rubroElegido = combo_Rubro.Text;

            // Crea una direccion y se guarda su id
            Direccion direccion = new Direccion();
            try
            {
                direccion.SetCalleNro(calleNro);
                direccion.SetPiso(piso);
                direccion.SetDepartamento(departamento);
                direccion.SetLocalidad(localidad);
                direccion.SetCodigoPostal(codigoPostal);
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

            // Si no se cumplen estas 2 condiciones no se tiene que crear
            try
            {
                if (!comunicador.pasoControlDeRegistroDeCuit(Convert.ToString(cuit)))
                    throw new CuitYaExisteException();

            }

            catch (CuitYaExisteException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            
            //---------
            // Controla que no se haya creado ya la direccion
            if (this.idDireccion == 0)
            {
                this.idDireccion = comunicador.CrearDireccion(direccion);
            }

            // Crea empresa
            try
            {
                Empresa empresa = new Empresa();
                empresa.SetNombre(nombre);
                empresa.SetCuit(cuit);
                empresa.SetRubro(comunicador.SelectFromWhere("rubr_id", "Rubro", "rubr_descripcion", rubroElegido));
                empresa.SetDireccionID(idDireccion);
                if(comunicador.CrearEmpresa(empresa) > 0)
                    MessageBox.Show("Se agrego la empresa correctamente");
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

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_Nombre.Text = "";
            textBox_Cuit.Text = "";
            textBox_CalleNro.Text = "";
            textBox_Piso.Text = "";
            textBox_Departamento.Text = "";
            textBox_Localidad.Text = "";
            textBox_CodigoPostal.Text = "";
            combo_Rubro.Text = "";
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            VolverAlMenuPrincipal();
        }

        private void VolverAlMenuPrincipal()
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void combo_Rubro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

    }
}