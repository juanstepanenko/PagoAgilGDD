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
    public partial class ModificarCliente : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private Decimal idCliente;

        public ModificarCliente(Decimal idCliente)
        {
            InitializeComponent();
            this.idCliente = idCliente;
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            Cliente cliente = comunicador.ObtenerCliente(idCliente);

            textBox_Dni.Text = Convert.ToString(cliente.getDni());
            textBox_Nombre.Text = cliente.getNombre();
            textBox_Apellido.Text = cliente.getApellido();
            textBox_FechaDeNacimiento.Text = Convert.ToString(cliente.getFechaDeNac());
            textBox_Mail.Text = cliente.getMail();
            textBox_Telefono.Text = cliente.getTelefono();
            textBox_Direccion.Text = cliente.getDireccion();
            textBox_CodigoPostal.Text =  Convert.ToString(cliente.getCodPostal());
            checkBox_Habilitado.Checked = Convert.ToBoolean(comunicador.SelectFromWhere("clie_habilitado", "Cliente", "clie_id", idCliente));
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String dni = textBox_Dni.Text;
            String nombre = textBox_Nombre.Text;
            String apellido = textBox_Apellido.Text;
            DateTime fechaDeNacimiento;
            DateTime.TryParse(textBox_FechaDeNacimiento.Text, out fechaDeNacimiento);
            String mail = textBox_Mail.Text;
            String telefono = textBox_Telefono.Text;
            String direccion = textBox_Direccion.Text;
            String codigoPostal = textBox_CodigoPostal.Text;
            Boolean habilitado = checkBox_Habilitado.Checked;

            Boolean pudoModificar;
            // Update cliente
            try
            {
                Cliente cliente = new Cliente();
                cliente.setNombre(nombre);
                cliente.setApellido(apellido);
                cliente.setFechaDeNac(fechaDeNacimiento);
                cliente.setMail(mail);
                cliente.setTelefono(telefono);
                cliente.setDni(Convert.ToDecimal(dni));
                cliente.setDireccion(direccion);
                cliente.setCodPostal(Convert.ToDecimal(codigoPostal));
                cliente.setHabilitado(habilitado);
                pudoModificar = comunicador.Modificar(idCliente, cliente);
                if (pudoModificar) MessageBox.Show("El cliente se modifico correctamente");
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
            catch (MailYaExisteException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            this.Close();
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_FechaDeNacimiento_Click(object sender, EventArgs e)
        {
            this.monthCalendar_FechaDeNacimiento.Visible = true;
        }

        private void monthCalendar_FechaDeNacimiento_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            textBox_FechaDeNacimiento.Text = e.Start.ToShortDateString();
            monthCalendar_FechaDeNacimiento.Visible = false;
        }

    }
}
