using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmSucursal
{
    public partial class SucursalForm : Form
    {
        public SucursalForm()
        {
            InitializeComponent();
        }
        private void botonAgregarSucu_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AgregarSucursal().ShowDialog();
            this.Close();
        }

        private void botonEditarSucu_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FiltrarSucursal().ShowDialog();
            this.Close();
        }

        private void SucursalForm_Load(object sender, EventArgs e)
        {

        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }
    }
}
