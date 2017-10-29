using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class EmpresaForm : Form
    {
        public EmpresaForm()
        {
            InitializeComponent();
        }

        private void botonAgregarCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AgregarEmpresa().ShowDialog();
            this.Close();
        }

        private void botonEditarRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FiltroEmpresa().ShowDialog();
            this.Close();
        }

        private void EmpresaForm_Load(object sender, EventArgs e)
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
