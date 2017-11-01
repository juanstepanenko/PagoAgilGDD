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
    public partial class ModificarEmpresa : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private Decimal idDireccion;
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();
        private Decimal idEmpresa;

        public ModificarEmpresa(Decimal idEmpresa)
        {
            InitializeComponent();
            this.idEmpresa = idEmpresa;
        }

        private void ModificarEmpresa_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        public Object SelectedItem { get; set; }

        private void ModificarEmpresaForm_Load(object sender, EventArgs e)
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
        private void CargarDatos()
        {
            Empresa empresa = comunicador.ObtenerEmpresa(idEmpresa);

            this.idDireccion = empresa.GetDireccionID();
            textBox_Nombre.Text = empresa.GetNombre();
            textBox_Cuit.Text = empresa.GetCuit();
            CargarDireccion(idDireccion);
            checkBox1.Checked = Convert.ToBoolean(comunicador.SelectFromWhere("empr_habilitada", "Empresa", "empr_id", idEmpresa));
        }

        private void CargarDireccion(Decimal idDireccion)
        {
            Direccion direccion = comunicador.ObtenerDireccion(idDireccion);
            textBox_CalleNro.Text = direccion.GetCalleNro();
            textBox_Piso.Text = direccion.GetPiso();
            textBox_Departamento.Text = direccion.GetDepartamento();
            textBox_CodigoPostal.Text = direccion.GetCodigoPostal();
            textBox_Localidad.Text = direccion.GetLocalidad();
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
            Boolean habilitada = checkBox1.Checked;
            Boolean pudoModificar;

            // Update direccion
            try
            {
                Direccion direccion = new Direccion();
                direccion.SetCalleNro(calleNro);
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


            // Update empresa
            try
            {
                Empresa empresa = new Empresa();
                empresa.SetNombre(nombre);
                empresa.SetCuit(cuit);
                empresa.SetRubro(comunicador.SelectFromWhere("rubr_id", "Rubro", "rubr_descripcion", rubroElegido));
                empresa.SetDireccionID(idDireccion);
                empresa.SetHabilitada(habilitada);
                pudoModificar = comunicador.ModificarEmpresa(idEmpresa, empresa); 
                if (pudoModificar) MessageBox.Show("La empresa se modifico correctamente");
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

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}