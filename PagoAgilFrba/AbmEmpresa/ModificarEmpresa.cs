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

            textBox_Nombre.Text = empresa.GetNombre();
            textBox_Cuit.Text = empresa.GetCuit();
            textBox_Direccion.Text = empresa.getDireccion();
            textBox_CodigoPostal.Text = Convert.ToString(empresa.getCodPostal());
            checkBox1.Checked = Convert.ToBoolean(comunicador.SelectFromWhere("empr_habilitada", "Empresa", "empr_id", idEmpresa));
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String nombre = textBox_Nombre.Text;
            String cuit = textBox_Cuit.Text;
            String direccion = textBox_Direccion.Text;
            String codigoPostal = textBox_CodigoPostal.Text;
            String rubroElegido = combo_Rubro.Text;
            Boolean habilitada = checkBox1.Checked;
            Boolean pudoModificar;

            // Update empresa
            try
            {
                Empresa empresa = new Empresa();
                empresa.SetNombre(nombre);
                empresa.SetCuit(cuit);
                empresa.SetRubro(comunicador.SelectFromWhere("rubr_id", "Rubro", "rubr_descripcion", rubroElegido));
                empresa.setDireccion(direccion);
                empresa.setCodPostal(Convert.ToDecimal(codigoPostal));
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
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void combo_Rubro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}