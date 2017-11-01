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
using PagoAgilFrba.Objetos;
using PagoAgilFrba.Excepciones;


namespace PagoAgilFrba.AbmFactura
{
    public partial class ModificarFactura : Form
    {
        Decimal nroFactura;
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();
        Double total;
        public Object SelectedItem { get; set; }
        Decimal idFactura;


        public ModificarFactura(String nroFactura)
        {
            InitializeComponent();
            this.nroFactura = Convert.ToDecimal(nroFactura);
        }

        //toDo chequear que vaya comentado
        private void button_Volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            //new FiltroFactura().ShowDialog();
            this.Close();
        }

        //toDo
        private void ModificarFactura_Load(object sender, EventArgs e)
        {
            CargarEmpresas();
            cargarDataGrind();
            //inicializar el total
            Factura factura = comunicador.ObtenerFacturaConNumero(Convert.ToString(nroFactura));
            idFactura = factura.getIdFactura();
            textBox_cliente.Text = factura.getDniCliente();
            comboBoxEmpresas.Text = factura.getEmpresa();
            textBox_nrofact.Text = factura.getNroFactura();
            label10.Text = Convert.ToString(factura.getFechaAlta());
            textBox_venc.Text = Convert.ToString(factura.getFechaVencimiento());
            textBox_TOTAL.Text = factura.getTotal();
            total = Convert.ToDouble(factura.getTotal());
        }

        private void CargarEmpresas()
        {
            DataSet empresas = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            command = builderDeComandos.Crear("SELECT DISTINCT empr_nombre FROM AMBDA.Empresa", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(empresas);
            comboBoxEmpresas.DataSource = empresas.Tables[0].DefaultView;
            comboBoxEmpresas.ValueMember = "empr_nombre";
            comboBoxEmpresas.SelectedIndex = -1;
        }

        private void button_FechaVenc_Click(object sender, EventArgs e)
        {
            monthCalendar_FechaVenc.Visible = true;
        }

        private void monthCalendar_FechaVenc_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            textBox_venc.Text = e.Start.ToShortDateString();
            monthCalendar_FechaVenc.Visible = false;
        }

        private void comboBoxEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cargarDataGrind()
        {
            dataGridView_Item.DataSource = comunicador.SelectItems(Convert.ToString(nroFactura));
            dataGridView_Item.Columns[0].Visible = false;
            CargarColumnaEliminar();
        }

        private void CargarColumnaEliminar()
        {
            if (dataGridView_Item.Columns.Contains("Eliminar"))
                dataGridView_Item.Columns.Remove("Eliminar");
            DataGridViewButtonColumn botonColumnaEliminar = new DataGridViewButtonColumn();
            botonColumnaEliminar.Text = "Eliminar";
            botonColumnaEliminar.Name = "Eliminar";
            botonColumnaEliminar.UseColumnTextForButtonValue = true;
            dataGridView_Item.Columns.Add(botonColumnaEliminar);
        }

        private void dataGridView_Item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView_Item.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                String idItemAEliminar = dataGridView_Item.Rows[e.RowIndex].Cells["id"].Value.ToString();
                Double monto = Convert.ToDouble(dataGridView_Item.Rows[e.RowIndex].Cells["Monto Total"].Value.ToString());
                int indiceItemAEliminar = e.RowIndex;
                Boolean resultado = comunicador.EliminarItem(Convert.ToDecimal(idItemAEliminar));
                total = total - monto;
                dataGridView_Item.Rows.RemoveAt(indiceItemAEliminar);
                textBox_TOTAL.Text = total.ToString();
                return;
            }
            //saca el item de la base de datos y de la grilla
        }

        private void button_agregar_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            try
            {
                item.setMonto(textBox_monto.Text);
                item.setCantidad(textBox_cantidad.Text);
            }
            catch (FormatoInvalidoException exception)
            {
                MessageBox.Show("Datos mal ingresados en: " + exception.Message);
                return;
            }
            catch (CantidadNulaException exception)
            {
                MessageBox.Show("No se puede ingresar una cantidad igual a 0 en: " + exception.Message);
                return;
            }
            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                return;
            }
            total = total + Convert.ToDouble(item.getMonto());
            Factura factura = comunicador.ObtenerFacturaConNumero(Convert.ToString(nroFactura));
            item.setIdFactura(factura.getIdFactura());
            item.setRenglonId(comunicador.CrearItem(item));
            cargarDataGrind();
            textBox_TOTAL.Text = total.ToString();
            textBox_monto.Text = "";
            textBox_cantidad.Text = "";
        }

        //toDo
        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String dni = textBox_cliente.Text;
            String empresa = comboBoxEmpresas.Text;
            String nrofactura = textBox_nrofact.Text;
            DateTime fechaAlta, fechaVencimiento;
            DateTime.TryParse(label10.Text, out fechaAlta);
            DateTime.TryParse(textBox_venc.Text, out fechaVencimiento);

            //Crea Factura
            try
            {
                Factura factura = new Factura();
                factura.setDniCliente(dni);
                factura.setEmpresa(empresa);
                factura.setNroFactura(nrofactura);
                factura.setFechaAlta(fechaAlta);
                factura.setFechaVencimiento(fechaVencimiento);
                factura.setTotal(Convert.ToString(total));
                factura.setidFactura(idFactura);
                Boolean pudoModificar = comunicador.ModificarFactura(idFactura, factura);
                if (pudoModificar)
                    MessageBox.Show("El cliente se modifico correctamente");
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
            catch (CantidadNulaException exception)
            {
                MessageBox.Show("No se puede ingresar una campo igual a 0 en: " + exception.Message);
                return;
            }
            catch (FacturaYaExisteException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            catch (ClienteNoExisteException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            VolverAlMenuPrincipal();

        }

        //toDo chequear si va comentado o no
        private void VolverAlMenuPrincipal()
        {
            this.Hide();
            //new FacturaForm().ShowDialog();
            this.Close();
        }


       
    }
}
