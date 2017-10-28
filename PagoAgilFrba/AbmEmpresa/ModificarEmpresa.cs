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
    public partial class ModificarEmpresa : Form
    {
        private String cuit;
        private ComunicadorConBaseDeDatos comunicador = new ComunicadorConBaseDeDatos();
        private Decimal idDireccion;

        public ModificarEmpresa(String unCuit)
        {
            InitializeComponent();
            this.cuit = unCuit;
        }

        private void ModificarEmpresa_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            Empresa empresa = comunicador.ObtenerEmpresa(cuit);

            this.idDireccion = empresa.GetDireccionID();
            textBox_Nombre.Text = empresa.GetNombre();
            CargarDireccion(idDireccion);
            checkBox1.Checked = Convert.ToBoolean(comunicador.SelectFromWhere("empr_habilitada", "Empresa", "empr_cuit", cuit));
        }

        private void CargarDireccion(Decimal idDireccion)
        {
            Direccion direccion = comunicador.ObtenerDireccion(idDireccion);
            textBox_CalleNro.Text = direccion.GetCalleNro();
            textBox_Piso.Text = direccion.GetPiso();
            textBox_Departamento.Text = direccion.GetDepartamento();
            textBox_Localidad.Text = direccion.GetLocalidad();
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
            String codigoPostal = textBox_CodigoPostal.Text;
            String rubro = textBox_Rubro.Text;
            Boolean habilitada = checkBox1.Checked;
            Boolean pudoModificar;

            // Update direccion
            try
            {
                Direccion direccion = new Direccion();
                direccion.SetCalleNro(calleNro);
                direccion.SetPiso(piso);
                direccion.SetDepartamento(departamento);
                direccion.SetLocalidad(localidad);
                direccion.SetCodigoPostal(codigoPostal);
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


            // Update empresa
            try
            {
                Empresa empresa = new Empresa();
                empresa.SetNombre(nombre);
                empresa.SetCuit(cuit);
                empresa.SetRubro(rubro);
                empresa.SetDireccionID(idDireccion);
                empresa.SetHabilitada(habilitada);
                pudoModificar = comunicador.ModificarEmpresa(cuit, empresa); 
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
            catch (CuitYaExisteException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            textBox_Nombre.Text = "";
            textBox_Cuit.Text = "";
            textBox_CalleNro.Text = "";
            textBox_Piso.Text = "";
            textBox_Departamento.Text = "";
            textBox_Localidad.Text = "";
            textBox_CodigoPostal.Text = "";
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

        private void textBox_Rubro_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}