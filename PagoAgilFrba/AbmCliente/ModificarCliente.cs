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
        private Decimal idDireccion;
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

            this.idDireccion = cliente.getDireccionID();
            textBox_Dni.Text = Convert.ToString(cliente.getDni());
            textBox_Nombre.Text = cliente.getNombre();
            textBox_Apellido.Text = cliente.getApellido();
            textBox_FechaDeNacimiento.Text = Convert.ToString(cliente.getFechaDeNac());
            textBox_Mail.Text = cliente.getMail();
            textBox_Telefono.Text = cliente.getTelefono();
            CargarDireccion(idDireccion);
            checkBox_Habilitado.Checked = Convert.ToBoolean(comunicador.SelectFromWhere("clie_habilitado", "Cliente", "clie_id", idCliente));
        }

        private void CargarDireccion(Decimal idDireccion)
        {
            Direccion direccion = comunicador.ObtenerDireccion(idDireccion);
            textBox_Calle.Text = direccion.GetCalleNro();
            textBox_Piso.Text = direccion.GetPiso();
            textBox_Departamento.Text = direccion.GetDepartamento();
            textBox_CodigoPostal.Text = direccion.GetCodigoPostal();
            textBox_Localidad.Text = direccion.GetLocalidad();
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
            String calle = textBox_Calle.Text;
            String piso = textBox_Piso.Text;
            String departamento = textBox_Departamento.Text;
            String codigoPostal = textBox_CodigoPostal.Text;
            String localidad = textBox_Localidad.Text;
            Boolean habilitado = checkBox_Habilitado.Checked;

            Boolean pudoModificar;

            // Update direccion
            try
            {
                Direccion direccion = new Direccion();
                direccion.SetCalleNro(calle);
                direccion.SetPiso(piso);
                direccion.SetDepartamento(departamento);
                direccion.SetCodigoPostal(codigoPostal);
                direccion.SetLocalidad(localidad);
                comunicador.Modificar(idDireccion, direccion);
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
                cliente.setDireccionID(idDireccion);
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
