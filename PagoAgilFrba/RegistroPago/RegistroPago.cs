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
        private Double importeTotal = 0;
        private List<Decimal> facturas = new List<Decimal>();

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

        private void InicializarDataGrind()
        {
            dataGridView_Factura.ColumnCount = 3;
            dataGridView_Factura.ColumnHeadersVisible = true;
            dataGridView_Factura.Columns[0].Name = "Nro Factura";
            dataGridView_Factura.Columns[1].Name = "Empresa";
            dataGridView_Factura.Columns[2].Name = "Importe";
            dataGridView_Factura.Columns[3].Name = "Fecha De Vencimiento";
            dataGridView_Factura.Columns[4].Name = "Eliminar";
        }

        private void CargarColumnaEliminar()
        {
            if (dataGridView_Factura.Columns.Contains("Eliminar"))
                dataGridView_Factura.Columns.Remove("Eliminar");
            DataGridViewButtonColumn botonColumnaEliminar = new DataGridViewButtonColumn();
            botonColumnaEliminar.Text = "Eliminar";
            botonColumnaEliminar.Name = "Eliminar";
            botonColumnaEliminar.UseColumnTextForButtonValue = true;
            dataGridView_Factura.Columns.Add(botonColumnaEliminar);
        }


        private void dataGridView_Factura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView_Factura.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                int indiceFacturaAEliminar = e.RowIndex;
                this.facturas.Remove(this.facturas[indiceFacturaAEliminar]);
                MessageBox.Show("Se elimino correctamente");
                dataGridView_Factura.Rows.RemoveAt(indiceFacturaAEliminar);
                return;
            }
        }

        private void button_agregar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            if (textBox_NroFact.Text == "" || textBox_Importe.Text == "" || textBox_FechaDeVencimiento.Text == "" 
                || comboBox_Empresa.Text == "")
            {
                MessageBox.Show("Ingrese todos los datos para agregar una factura");
                return;
            }
            
            try
            {
                String importe = textBox_Importe.Text;
                DateTime fechaDeVencimiento;
                DateTime.TryParse(textBox_FechaDeVencimiento.Text, out fechaDeVencimiento);
                //Decimal empresa = comunicador.SelectFromWhere("empr_cuit", "Empresa", "empr_nombre", comboBox_Empresa.Text);


                //corroborar que ese nro de factura sea de esa empresa
                //corroborar que la fechad e ven sea mayor o = ? a la de cobro

                facturas.Add(Convert.ToDecimal(textBox_NroFact));
                importeTotal += Convert.ToDouble(importe);
                
            }
            catch (FormatoInvalidoException exception)
            {
                MessageBox.Show("Datos mal ingresados en: " + exception.Message);
                return;
            }
            catch (CantidadNulaException)
            {
                MessageBox.Show("No se puede ingresar una cantidad igual a 0");
                return;
            }
            string[] row = new string[] { textBox_NroFact.Text, textBox_Importe.Text,textBox_FechaDeVencimiento.Text, comboBox_Empresa.Text};
            
            dataGridView_Factura.Rows.Add(row);
            
            CargarColumnaEliminar();
            //total = total + Convert.ToDecimal(item.getMonto());
            textBox_Importe.Text = "";
            textBox_NroFact.Text = "";
            textBox_FechaDeVencimiento.Text = "";
            comboBox_Empresa.Text = "";

        }


        private void button_Guardar_Click(object sender, EventArgs e)
        {
            String cliente = comboBox_Cliente.Text;
            String importe = textBox_Importe.Text;
            Decimal medio_pago = comunicador.SelectFromWhere("medi_id", "MedioDePago", "medi_descripcion", comboBox_MedioPago.Text);
            Decimal sucursal = comunicador.SelectFromWhere("sucu_id", "Sucursal", "sucu_nombre", textBox_Sucursal.Text);
            DateTime fechaDeVencimiento;
            DateTime.TryParse(textBox_FechaDeVencimiento.Text, out fechaDeVencimiento);
           
            // Crear pago
            try
            {
                //corroborar que la sucursal sea donde trabaja el cobrador, si es adm meter la que ingresan--- > ver que no se pone bien la sucursal

                Pago pago = new Pago();
                pago.setFechaCobro(DateTime.Today);
                pago.setCliente(Convert.ToDecimal(cliente));
                pago.setUsuario(UsuarioSesion.usuario.id);
                pago.setSucursal(sucursal);
                pago.setMedioPago(medio_pago);
                comunicador.CrearPago(pago);
                
                comunicador.PagarFacturas(facturas); 
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
