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

namespace PagoAgilFrba.AbmCliente
{
    public partial class AgregarCliente : Form
    {
        private String username;
        private String contrasena;
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private Decimal idDireccion;
        private Decimal idUsuario;
        private Decimal idCliente;


        public AgregarCliente(String username, String contrasena)
        {
            InitializeComponent();
            this.username = username;
            this.contrasena = contrasena;
            this.idDireccion = 0;
            this.idUsuario = 0;
        }
    }
}
