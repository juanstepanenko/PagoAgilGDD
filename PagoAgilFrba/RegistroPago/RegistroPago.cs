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
    public partial class RegistroPago : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private SqlCommand command { get; set; }
      
        public RegistroPago()
        {
            InitializeComponent();
        }

        private void RegistroPago_Load(object sender, EventArgs e)
        {
            CargarMediosPago();
            CargarEmpresas();
            CargarClientes();
        }

        private void CargarMediosPago()
        {
            DataSet medios = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros.Clear();
            command = builderDeComandos.Crear("SELECT DISTINCT medi_descripcion FROM AMBDA.MedioDePago ", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(medios);
            comboBox_MedioPago.DataSource = medios.Tables[0].DefaultView;
            comboBox_MedioPago.ValueMember = "medi_descripcion";
            comboBox_MedioPago.SelectedIndex = -1;
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

        private void CargarClientes()
        {
            DataSet clientes = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros.Clear();
            command = builderDeComandos.Crear("SELECT DISTINCT clie_dni FROM AMBDA.Cliente ", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(clientes);
            comboBox_Cliente.DataSource = clientes.Tables[0].DefaultView;
            comboBox_Cliente.ValueMember = "clie_dni";
            comboBox_Cliente.SelectedIndex = -1;
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            String cliente = comboBox_Cliente.Text;
            String importe = textBox_Importe.Text;
            Decimal medio_pago = comunicador.SelectFromWhere("medi_id", "MedioDePago", "medi_descripcion", comboBox_MedioPago.Text);
            //Decimal empresa = comunicador.SelectFromWhere("empr_cuit", "Empresa", "empr_nombre", comboBox_Empresa.Text);
            Decimal sucursal = comunicador.SelectFromWhere("sucu_id", "Sucursal", "sucu_nombre", textBox_Sucursal.Text);
            DateTime fechaDeVencimiento;
            DateTime.TryParse(textBox_FechaDeVencimiento.Text, out fechaDeVencimiento);
            Decimal idFactura = comunicador.SelectFromWhere("fact_id", "Factura", "fact_nro", textBox_NroFact.Text);
            Decimal idPago = comunicador.SelectFromWhere("regi_id", "RegistroPago", "regi_usuario", UsuarioSesion.usuario.id);
            
            //corroborar que la sucursal sea donde trabaja el cobrador, si es adm meter la que ingresan--- > ver que no se pone bien la sucursal
            //corroborar que ese nro de factura sea de esa empresa
            //corroborar que la fechad e ven sea mayor o = ? a la de cobro
            
            // Crear pago
            try
            {
                Pago pago = new Pago();
                pago.setFechaCobro(DateTime.Today);
                pago.setCliente(Convert.ToDecimal(cliente));
                pago.setUsuario(UsuarioSesion.usuario.id);
                pago.setSucursal(sucursal);
                pago.setMedioPago(medio_pago);
                comunicador.CrearPago(pago);

                comunicador.PagarFactura(idPago, idFactura, Convert.ToDecimal(importe));
                MessageBox.Show("Se registro el pago correctamente");
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

            VolverAlMenuPrincial();
        }

        private void button_AgregarFactura_Click(object sender, EventArgs e)
        {
            String cliente = comboBox_Cliente.Text;
            String importe = textBox_Importe.Text;
            Decimal medio_pago = comunicador.SelectFromWhere("medi_id", "MedioDePago", "medi_descripcion", comboBox_MedioPago.Text);
            //Decimal empresa = comunicador.SelectFromWhere("empr_cuit", "Empresa", "empr_nombre", comboBox_Empresa.Text);
            Decimal sucursal = comunicador.SelectFromWhere("sucu_id", "Sucursal", "sucu_nombre", textBox_Sucursal.Text);
            DateTime fechaDeVencimiento;
            DateTime.TryParse(textBox_FechaDeVencimiento.Text, out fechaDeVencimiento);
            Decimal idFactura = Convert.ToDecimal(comunicador.SelectFromWhere("fact_id", "Factura", "fact_nro", Convert.ToDecimal(textBox_NroFact.Text)));
            Decimal idPago = comunicador.SelectFromWhere("regi_id", "RegistroPago", "regi_usuario", UsuarioSesion.usuario.id);
            
            //corroborar que la sucursal sea donde trabaja el cobrador, si es adm meter la que ingresan--- > ver que no se pone bien la sucursal
            //corroborar que ese nro de factura sea de esa empresa
            //corroborar que la fechad e ven sea mayor o = ? a la de cobro
            
            // Crear pago
            try
            {

                Pago pago = new Pago();

                pago.setFechaCobro(DateTime.Today);
                pago.setCliente(Convert.ToDecimal(cliente));
                pago.setUsuario(UsuarioSesion.usuario.id);
                pago.setSucursal(sucursal);
                pago.setMedioPago(medio_pago);
                comunicador.CrearPago(pago);
                comunicador.PagarFactura(idPago, idFactura, Convert.ToDecimal(importe));
                MessageBox.Show("Se agrego la factura al pago correctamente");
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

            this.Hide();
            new AgregarFactura().ShowDialog();
            this.Close();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            VolverAlMenuPrincial();
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
