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

namespace PagoAgilFrba.AbmCliente
{
    public partial class AgregarCliente : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private Decimal idCliente;


        public AgregarCliente()
        {
            InitializeComponent();
        }

        private void AgregarCliente_Load(object sender, EventArgs e)
        {
            
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String dni = textBox_Dni.Text;
            String mail = textBox_Mail.Text;
            String nombre = textBox_Nombre.Text;
            String apellido = textBox_Apellido.Text;
            String direccion = textBox_Direccion.Text;
            String codigoPostal = textBox_CodigoPostal.Text;
            DateTime fechaDeNacimiento;
            DateTime.TryParse(textBox_FechaDeNacimiento.Text, out fechaDeNacimiento);
            String telefono = textBox_Telefono.Text;

            // Crear cliente
            try
            {
                Cliente cliente = new Cliente();
                cliente.setDni(Convert.ToDecimal(dni));
                cliente.setMail(mail);
                cliente.setNombre(nombre);
                cliente.setApellido(apellido);
                cliente.setDireccion(direccion);
                cliente.setCodPod(codigoPostal);
                cliente.setFechaDeNac(fechaDeNacimiento);
                cliente.setTelefono(telefono);
                idCliente = comunicador.CrearCliente(cliente);
                if (idCliente > 0) MessageBox.Show("Se agrego el cliente correctamente");
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
            catch (ClienteYaExisteException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            VolverAlMenuPrincial();
        }
        
        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_Nombre.Text = "";
            textBox_Apellido.Text = "";
            textBox_FechaDeNacimiento.Text = "";
            textBox_Mail.Text = "";
            textBox_Telefono.Text = "";
            textBox_CodigoPostal.Text = "";
            textBox_Dni.Text = "";
            textBox_Direccion.Text = "";
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            VolverAlMenuPrincial();
        }

        private void VolverAlMenuPrincial()
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void button_FechaDeNacimiento_Click(object sender, EventArgs e)
        {
            monthCalendar_FechaDeNacimiento.Visible = true;
        }

        private void monthCalendar_FechaDeNacimiento_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            textBox_FechaDeNacimiento.Text = e.Start.ToShortDateString();
            monthCalendar_FechaDeNacimiento.Visible = false;
        }
    }
}
