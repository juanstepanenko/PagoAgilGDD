using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Excepciones;

namespace PagoAgilFrba.Devoluciones
{
    public partial class IngresarFactura : Form   
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();

        public IngresarFactura()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
           

            String nroFact = textBox1.Text;

             try
            {
                if (comunicador.pasoControlDeRegistroFactura(nroFact))
                    throw new FacturaNoExisteException();
                if (comunicador.pasoControlDeRendidaFactura(nroFact))
                    throw new FacturaYaFueRendida();
                if(comunicador.pasoControlDeCobradaFactura(nroFact))
                    throw new FacturaNoFueCobrada();
                 // ver que no este devuelta ya
            }

             catch (FacturaNoExisteException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
             catch (FacturaYaFueRendida exception)
             {
                 MessageBox.Show(exception.Message);
                 return;
             }
            

            this.Hide();
            new Devoluciones(nroFact).ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }
    }
}
