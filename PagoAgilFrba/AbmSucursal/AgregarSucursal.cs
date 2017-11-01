﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PagoAgilFrba.Objetos;
using PagoAgilFrba.Excepciones;

namespace PagoAgilFrba.AbmSucursal
{
    public partial class AgregarSucursal : Form
    {
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private Decimal idDireccion;
        //private Decimal idSucursal;

        public AgregarSucursal()
        {
            InitializeComponent();
            this.idDireccion = 0;
        }

        private void AgregarSucursal_Load(object sender, EventArgs e)
        {

        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String nombreSucursal = textBoxNombre.Text;
            String calleNro = textBoxCalleNro.Text;
            String piso = textBoxCP.Text;
            String departamento = textBoxDepartamento.Text;
            String codigoPostal = textBoxCP.Text;
            String localidad = textBoxLocalidad.Text;
            String dir = calleNro + ", " + piso + ", " + departamento + ", " + localidad;

            // Si no se cumple unicidad de codigo postal no se tiene que crear
            //try
            //{
            //if (!comunicador.pasoControlDeUnicidad(codigoPostal, "sucu_cod_postal", "Sucursal"))
            //throw new CodPosYaExisteException();
            //}

            //catch (CampoVacioException exception)
            //{
            //    MessageBox.Show("Falta completar campo: " + exception.Message);
            //    return;
            //}

            //chequeo cod postal con la tabla direccion
            try
            {
                if (!comunicador.pasoControlDeUnicidad(codigoPostal, "direc_cod_postal", "Direccion"))
                    throw new CodPosYaExisteException();
            }
            catch (CodPosYaExisteException exception)
            {
                MessageBox.Show("Ya existe sucursal en éste área");
                return;
            }

            // Crea una direccion y se guarda su id
            Direccion direccion = new Direccion();
            try
            {
                direccion.SetCalleNro(calleNro);
                direccion.SetPiso(piso);
                direccion.SetDepartamento(departamento);
                direccion.SetCodigoPostal(codigoPostal);
                direccion.SetLocalidad(localidad);
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

            //Controla que no se haya creado ya la direccion
            if (this.idDireccion == 0)
            {
                this.idDireccion = comunicador.CrearDireccion(direccion);
            }

            // Crea sucursal
            try
            {
                Sucursal sucursal = new Sucursal();
                sucursal.SetNombreSucursal(nombreSucursal);
                sucursal.SetIdDireccion(idDireccion);
                sucursal.SetDireccion(dir);
                //sucursal.SetHabilitada(true);
                sucursal.SetId(comunicador.CrearSucursal(sucursal));
                MessageBox.Show("Se creó la sucursal correctamente");
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
            catch (CodPosYaExisteException exception)
            {
                MessageBox.Show("Ya existe sucursal con éste código Postal" + exception.Message);
                return;
            }

            VolverAlForm();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text = "";
            textBoxCalleNro.Text = "";
            textBoxPiso.Text = "";
            textBoxCP.Text = "";
            textBoxDepartamento.Text = "";
            textBoxLocalidad.Text = "";
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            VolverAlForm();
        }

        private void VolverAlForm()
        {
            this.Hide();
            new SucursalForm().ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
