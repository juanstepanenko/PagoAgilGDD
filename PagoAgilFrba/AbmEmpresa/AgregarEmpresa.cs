﻿using System;
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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class Form1 : Form
    {
        private String username;
        private String contrasena;
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private Decimal idDireccion;
        private Decimal idUsuario;
        private Decimal idEmpresa;

        public Form1(String username, String contrasena)
        {
            InitializeComponent();
            this.username = username;
            this.contrasena = contrasena;
            this.idDireccion = 0;
            this.idUsuario = 0;
        }

        private void AgregarEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            // Guarda en variables todos los campos de entrada
            String nombre = textBox_Nombre.Text;
            String cuit = textBox_Cuit.Text;
            String calleNro = textBox_CalleNro.Text;
            String piso = textBox_Piso.Text;
            String departamento = textBox_Departamento.Text;
            String localidad = textBox_Localidad.Text;
            String rubro = textBox_Rubro.Text;

            // Crea una direccion y se guarda su id
            Direccion direccion = new Direccion();
            try
            {
                direccion.SetCalleNro(calleNro);
                direccion.SetPiso(piso);
                direccion.SetDepartamento(departamento);
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

            // Crea empresa
            try
            {
                Empresa empresa = new Empresa();
                empresa.SetNombre(nombre);
                empresa.SetCuit(cuit);
                empresa.SetRubro(rubro);
                idEmpresa = comunicador.CrearEmpresa(empresa);
                if (idEmpresa > 0) MessageBox.Show("Se agrego la empresa correctamente");
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
            catch (CuitYaExisteException exception)
            {
                MessageBox.Show("Cuit ya existe");
                return;
            }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_Nombre.Text = "";
            textBox_Cuit.Text = "";
            textBox_CalleNro.Text = "";
            textBox_Piso.Text = "";
            textBox_Departamento.Text = "";
            textBox_Localidad.Text = "";
            textBox_Rubro.Text = "";
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {            
                VolverAlMenuPrincipal();
        }

        private void VolverAlMenuPrincipal()
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

    }
}