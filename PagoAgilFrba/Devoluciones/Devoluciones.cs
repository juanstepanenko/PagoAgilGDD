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


namespace PagoAgilFrba.Devoluciones
{
    public partial class Devoluciones : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private Factura factura;

        public Devoluciones(String nroFact)
        {
            InitializeComponent();
            factura = comunicador.ObtenerFacturaConNumero(nroFact);

        }
        
        private void AgregarDevolucion()
        {
            String  motivo = richTextBox1.Text;
            String nroFactura = factura.getNroFactura();
            DateTime fecha_devolucion = DateTime.Now;

            // Si esto no pasa no se tiene que crear

            try
            {
                if (motivo == "")
                    throw new CampoVacioException("Motivo");
            }

            catch (CampoVacioException exception)
            {
                MessageBox.Show("Falta completar campo: " + exception.Message);
                return;
            }

            
            //Crea Devolucion
            Devolucion devolucion = new Devolucion();
            try
            {
                devolucion.setFactura(nroFactura);
                devolucion.setMotivo(motivo);
                devolucion.setFechaDevo(fecha_devolucion);
                if (comunicador.CrearDevolucion(devolucion) > 0)
                    MessageBox.Show("Se agrego la devolución correctamente");
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
        }

        private void button2_Click(object sender, EventArgs e)
        {

            AgregarDevolucion();
            volverAlMenuPrincipal();
            // falta verificar que no este devuelta ya 
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            volverAlMenuPrincipal();
        }

        private void volverAlMenuPrincipal()
        {
            this.Hide();
            new IngresarFactura().ShowDialog();
            this.Close();
        }
    }
}
