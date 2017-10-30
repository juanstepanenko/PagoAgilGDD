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
        private Decimal idSucursal;

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
            String calle = textBoxCalle.Text;
            String numero = textBoxNumero.Text;
            String piso = textBoxPiso.Text;
            String departamento = textBoxDepartamento.Text;
            String codigoPostal = textBoxPiso.Text;
            String localidad = textBoxLocalidad.Text;


            // Crea una direccion y se guarda su id
            Direccion direccion = new Direccion();
            try
            {
                direccion.SetCalle(calle);
                direccion.SetCalleNro(numero);
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
            // Controla que no se haya creado ya la direccion
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
                sucursal.SetHabilitada(true);
                comunicador.CrearSucursal(sucursal);
                //ojo, nunca devuelv el id sucursal
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
                MessageBox.Show("Ya existe sucursal con éste código Postal");
                return;
            }
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text = "";
            textBoxCalle.Text = "";
            textBoxNumero.Text = "";
            textBoxPiso.Text = "";
            textBoxDepartamento.Text = "";
            textBoxCodPos.Text = "";
            textBoxLocalidad.Text = "";
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            VolverAlMenuPrincipal();
        }

        private void VolverAlMenuPrincipal()
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
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
