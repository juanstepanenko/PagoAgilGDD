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
        private String motivo;
        private Factura factura;
        
        public Devoluciones(String nroFact)
        {
            InitializeComponent();
            factura = comunicador.ObtenerFacturaConNumero(nroFact); // aca no es numero, se hace con id
           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ModificarFactura()
        {
            // esperar a Ro           
        }

        private void ModificarPago()
        {
            // obtengo el pago
           // Pago pago = comunicador.ObtenerPagoConFactura(factura.getIdFactura());
            //comunicador.DevolverPago(pago.getIdPago(), pago);
        }

        private void AgregarDevolucion()
        {
            Decimal idDevolucion = 0;
            motivo = richTextBox1.Text;
            String nroFactura = factura.getNroFactura();
            DateTime fecha_devolucion = DateTime.Now;
          

            //Crea Devolucion
            Devolucion devolucion = new Devolucion();
            try
            {
                devolucion.setFactura(nroFactura);
                devolucion.setMotivo(motivo);
                devolucion.setFechaDevo(fecha_devolucion);
                idDevolucion = comunicador.CrearDevolucion(devolucion);
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
            //poner factura cmomo no pagada 

            
           // ModificarPago(); --> falta arreglarlo eh
            AgregarDevolucion();
            // funciona el agregar devolucion falta hacer que cierre la ventana
            //agregar motivo
        }
    }
}
