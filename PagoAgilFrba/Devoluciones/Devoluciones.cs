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


namespace PagoAgilFrba.Devoluciones
{
    public partial class Devoluciones : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private String motivo;
        private Factura factura;
        
        public Devoluciones(Decimal nroFact)
        {
            InitializeComponent();
            factura = comunicador.ObtenerFactura(nroFact);
           
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
            Pago pago = comunicador.ObtenerPagoConFactura(factura.getIdFactura());
            comunicador.DevolverPago(pago.getIdPago(), pago);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //poner factura cmomo no pagada 
        
            ModificarPago();
            //agregar motivo
        }
    }
}
