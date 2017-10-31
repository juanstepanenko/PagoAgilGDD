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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            Decimal nroFact = Convert.ToDecimal(textBox1.Text);

             try
            {
                if (comunicador.pasoControlDeRegistroFactura(nroFact))
                    throw new FacturaNoExisteException();
                if (comunicador.pasoControlDeRendidaFactura(nroFact))
                    throw new FacturaYaFueRendida();
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
            new Devolucion().ShowDialog();
            this.Close();
        }
    }
}
