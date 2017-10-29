using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmFactura
{
    public partial class FacturaForm : Form
    {
        public FacturaForm()
        {
            InitializeComponent();
        }

        private void botonEditarFactura_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FiltroFactura().ShowDialog();
            this.Close();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void botonAgregarFactura_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AgregarFactura().ShowDialog();
            this.Close();
        }
    }
}
