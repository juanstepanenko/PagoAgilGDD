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
using System.Data.SqlClient;
using PagoAgilFrba.Excepciones;

namespace PagoAgilFrba.RegistroPago
{
    public partial class AgregarFactura : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private SqlCommand command { get; set; }

        public AgregarFactura()
        {
            InitializeComponent();
        }

        private void AgregarFactura_Load(object sender, EventArgs e)
        {
            CargarEmpresas();
        }

        private void CargarEmpresas()
        {
            DataSet empresas = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros.Clear();
            command = builderDeComandos.Crear("SELECT DISTINCT empr_nombre FROM AMBDA.Empresa WHERE empr_habilitada = 1", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(empresas);
            comboBox_Empresa.DataSource = empresas.Tables[0].DefaultView;
            comboBox_Empresa.ValueMember = "empr_nombre";
            comboBox_Empresa.SelectedIndex = -1;
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String importe = textBox_Importe.Text;
            DateTime fechaDeVencimiento;
            DateTime.TryParse(textBox_FechaDeVencimiento.Text, out fechaDeVencimiento);
            //Decimal empresa = comunicador.SelectFromWhere("empr_cuit", "Empresa", "empr_nombre", comboBox_Empresa.Text);
            Decimal idFactura = comunicador.SelectFromWhere("fact_id", "Factura", "fact_nro", textBox_NroFact.Text);
            Decimal idPago = comunicador.SelectFromWhere("regi_id", "RegistroPago", "regi_usuario", UsuarioSesion.usuario.id);


            //corroborar que ese nro de factura sea de esa empresa
            //corroborar que la fechad e ven sea mayor o = ? a la de cobro

            comunicador.PagarFactura(idPago, idFactura, Convert.ToDecimal(importe));
            MessageBox.Show("Se registro el pago correctamente");
            VolverAlMenuPrincial();
        }

        private void button_AgregarFactura_Click(object sender, EventArgs e)
        {
            String importe = textBox_Importe.Text;
            DateTime fechaDeVencimiento;
            DateTime.TryParse(textBox_FechaDeVencimiento.Text, out fechaDeVencimiento);
            //Decimal empresa = comunicador.SelectFromWhere("empr_cuit", "Empresa", "empr_nombre", comboBox_Empresa.Text);
            Decimal idFactura = comunicador.SelectFromWhere("fact_id", "Factura", "fact_nro", textBox_NroFact.Text);
            Decimal idPago = comunicador.SelectFromWhere("regi_id", "RegistroPago", "regi_usuario", UsuarioSesion.usuario.id);

            //validaciones como arriba

            comunicador.PagarFactura(idPago, idFactura, Convert.ToDecimal(importe));
            MessageBox.Show("Se agrego la factura al pago correctamente");

            this.Hide();
            new AgregarFactura().ShowDialog();
            this.Close();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            VolverAlMenuPrincial();// que pasa con las otras facturas pagadas si cancelo aca?
        }

        private void VolverAlMenuPrincial()
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void button_FechaVencimiento_Click(object sender, EventArgs e)
        {
            monthCalendar_FechaDeVencimiento.Visible = true;
        }

        private void monthCalendar_FechaDeVencimiento_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            textBox_FechaDeVencimiento.Text = e.Start.ToShortDateString();
            monthCalendar_FechaDeVencimiento.Visible = false;
        }
    }
}
