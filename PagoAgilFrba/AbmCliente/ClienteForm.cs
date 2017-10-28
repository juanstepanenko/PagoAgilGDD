using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class ClienteForm : Form
    {
        public ClienteForm()
        {
            InitializeComponent();
        }

        private void botonAgregarCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AgregarCliente().ShowDialog();
            this.Close();
        }

        private void botonEditarRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FiltroCliente().ShowDialog();
            this.Close();
        }

        private void ClienteForm_Load(object sender, EventArgs e)
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
