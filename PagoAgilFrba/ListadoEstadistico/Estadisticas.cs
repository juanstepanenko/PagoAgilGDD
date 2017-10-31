using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PagoAgilFrba;


namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class Estadisticas : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private BuilderDeComandos builderDeComandos = new BuilderDeComandos();
        private SqlCommand command;

        public Estadisticas()
        {
            InitializeComponent();
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {
            CargarTrimestres();
            CargarTiposDeListados();
            progressBar.Visible = false;
        }

        private void CargarTrimestres()
        {
            DataTable trimestres = new DataTable();
            trimestres.Columns.Add("trimestres");
            trimestres.Rows.Add("1er trimestre (Enero - Marzo)");
            trimestres.Rows.Add("2do trimestre (Abril - Junio)");
            trimestres.Rows.Add("3er trimestre (Julio - Septiembre)");
            trimestres.Rows.Add("4to trimestre (Octubre - Diciembre)");
            comboBox_Trimestre.DataSource = trimestres;
            comboBox_Trimestre.ValueMember = "trimestres";
            comboBox_Trimestre.SelectedIndex = -1;
        }

        private void CargarTiposDeListados()
        {
            DataTable tiposDeListados = new DataTable();
            tiposDeListados.Columns.Add("tiposDeListados");
            tiposDeListados.Rows.Add("Porcentaje de facturas cobradas por empresa");
            tiposDeListados.Rows.Add("Empresas con mayor monto rendido");
            tiposDeListados.Rows.Add("Clientes con mas pagos");
            tiposDeListados.Rows.Add("Clientes con mayor porcentaje de facturas pagadas ");
            comboBox_TipoDeListado.DataSource = tiposDeListados;
            comboBox_TipoDeListado.ValueMember = "tiposDeListados";
            comboBox_TipoDeListado.SelectedIndex = -1;
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            progressBar.Maximum = 1000;

            String anio = textBox_Anio.Text;
            String trimestre = comboBox_Trimestre.Text;
            String tipoDeListado = comboBox_TipoDeListado.Text;

            String fechaDeInicio = ObtenerFechaDeInicio(anio, trimestre);
            String fechaDeFin = ObtenerFechaDeFin(anio, trimestre);
            String fechaMedia = ObtenerFechaMedia(anio, trimestre);

            try
            {
                this.validarFiltros();

                switch (comboBox_TipoDeListado.SelectedIndex)
                {
                    case 0:
                        //this.llenarDataGridConConsulta(this.vendedoresConMayorCantidadDeProductosNoVendidos()); estas son funciones (feli)
                        break;

                    case 1:
                        //this.llenarDataGridConConsulta(this.clientesMasCompradoresEnUnRubro());
                        break;

                    case 2:
                        //this.llenarDataGridConConsulta(this.vendedoresConMasFacturas());
                        break;

                    case 3:
                        //this.llenarDataGridConConsulta(this.vendedoresConMayorFacturacion());
                        if (!dataGridView_Estadistica.Columns[1].HeaderText.Contains("(ARS)"))
                            dataGridView_Estadistica.Columns[1].HeaderText = dataGridView_Estadistica.Columns[1].HeaderText + " (ARS)";
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void llenarDataGridConConsulta(SqlDataReader reader)
        {
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView_Estadistica.AutoGenerateColumns = true;
            dataGridView_Estadistica.DataSource = dt;
            dataGridView_Estadistica.Refresh();
        }

        

        private void validarFiltros()
        {
            if (comboBox_Trimestre.SelectedItem.Equals(null))
                throw new Exception("Debe seleccionar un trimestre");
            /*else
                if ((!Validacion.esTrimestreMenorAlActual(Fecha.getNroTrimestreDesdeTrimestre(comboBox_Trimestre.SelectedItem.ToString()))) &&
                    (Fecha.esAnioActual(Convert.ToInt32(numericUpDown1.Value))))
                    throw new Exception("Debe seleccionar un trimestre anterior al trimestre en curso");*/


            if (comboBox_TipoDeListado.SelectedItem.Equals(null))
                throw new Exception("Debe seleccionar una estadística");

           /* if (comboBox_TipoDeListado.SelectedItem.Equals("Vendedores con mayor cantidad de productos no vendidos") && (comboBox3.SelectedItem.Equals(null)))
                throw new Exception("Debe seleccionar una visibilidad");

            if (comboBox_TipoDeListado.SelectedItem.Equals("Clientes con mayor cantidad de productos comprados") && textBox1.Text.Equals(""))
                throw new Exception("Debe seleccionar un rubro");*/ 

            // cuando hay mas de una cosa para selecionar
        }

        private String ObtenerFechaMedia(string anio, string trimestre)
        {
            String dia = "01";
            String mes = ObtenerMesMedio(trimestre);
            return dia + "/" + mes + "/" + anio;
        }

        private string ObtenerMesMedio(string trimestre)
        {
            switch (trimestre[0])
            {
                case '1':
                    return "02";
                case '2':
                    return "05";
                case '3':
                    return "08";
                case '4':
                    return "11";
            }
            throw new Exception("No pudo obtener mes");
        }

        private String ObtenerFechaDeInicio(string anio, string trimestre)
        {
            String dia = "01";
            String mes = ObtenerMesInicio(trimestre);
            return dia + "/" + mes + "/" + anio;
        }

        private string ObtenerMesInicio(string trimestre)
        {
            switch (trimestre[0])
            {
                case '1':
                    return "01";
                case '2':
                    return "04";
                case '3':
                    return "07";
                case '4':
                    return "10";
            }
            throw new Exception("No pudo obtener mes");
        }

        private String ObtenerFechaDeFin(string anio, string trimestre)
        {
            String dia = "01";
            String mes = ObtenerMesFin(trimestre);
            return dia + "/" + mes + "/" + anio;
        }

        private string ObtenerMesFin(string trimestre)
        {
            switch (trimestre[0])
            {
                case '1':
                    return "03";
                case '2':
                    return "06";
                case '3':
                    return "09";
                case '4':
                    return "12";
            }
            throw new Exception("No pudo obtener mes");
        }

        private string GetQueryObtenerResultados(String tipoDeListado, String fechaDeInicio, String fechaMedia, String fechaDeFin)
        {
            switch (tipoDeListado)
            {
                //  case "Vendedores con mayor cantidad de productos no vendidos":
                //     return "LOS_SUPER_AMIGOS.vendedores_con_mayor_cantidad_de_publicaciones_sin_vender('" + fechaDeInicio + "', '" + fechaMedia + "' , '" + fechaDeFin + "')";
                case "Vendedores con mayor facturacion":
                    return "LOS_SUPER_AMIGOS.vendedores_con_mayor_facturacion('" + fechaDeInicio + "', '" + fechaDeFin + "')";
                case "Vendedores con mayores calificaciones":
                    return "LOS_SUPER_AMIGOS.vendedores_con_mayor_calificacion('" + fechaDeInicio + "', '" + fechaDeFin + "')";
                case "Clientes con mayor cantidad de publicaciones sin calificar":
                    return "LOS_SUPER_AMIGOS.clientes_con_publicaciones_sin_calificar('" + fechaDeInicio + "', '" + fechaDeFin + "')";
            }
            throw new Exception("No se pudo obtener la funcion");
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_Anio.Text = "";
            comboBox_Trimestre.SelectedIndex = -1;
            comboBox_TipoDeListado.SelectedIndex = -1;
            dataGridView_Estadistica.DataSource = null;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void textBox_Anio_TextChanged(object sender, EventArgs e)
        {
            String anio = textBox_Anio.Text;
            if (esNumero(anio) && tieneCuatroNumeros(anio))
            {
                comboBox_Trimestre.Enabled = true;
                return;
            }
            comboBox_Trimestre.Enabled = false;
            comboBox_Trimestre.SelectedIndex = -1;
        }

        private Boolean esNumero(String anio)
        {
            UInt32 num;
            return UInt32.TryParse(anio, out num);
        }

        private Boolean tieneCuatroNumeros(String anio)
        {
            return anio.Length == 4;
        }

        private void comboBox_Trimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Trimestre.SelectedIndex == -1)
            {
                comboBox_TipoDeListado.Enabled = false;
                comboBox_TipoDeListado.SelectedIndex = -1;
                return;
            }
            comboBox_TipoDeListado.Enabled = true;
        }

        private void comboBox_TipoDeListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_TipoDeListado.SelectedIndex == -1)
            {
                button_Buscar.Enabled = false;
                return;
            }
            button_Buscar.Enabled = true;
        }
    }
}

