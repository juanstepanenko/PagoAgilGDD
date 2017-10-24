﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration; //hay que entrar a Proyect-Add Reference y buscarla para agregarla y que no tire error
using System.Data.SqlClient;

namespace PagoAgilFrba
{
    class ConexionDB
    {
        private SqlConnection Conexion { get; set; }

        public SqlConnection AbrirConexion()
        {
            //this.Conexion = new SqlConnection();
            //this.Conexion.ConnectionString = ConfigurationManager.ConnectionStrings["PagoAgilFrba.Properties.Settings.GD2C2017ConnectionString"].ConnectionString;
            string configuracion = ConfigurationManager.AppSettings["configuracionSQL"].ToString();
            SqlConnection conexion = new SqlConnection(configuracion);
            conexion.Open();
            SqlCommand comm = new SqlCommand("SET ARITHABORT ON", conexion);
            comm.ExecuteNonQuery();
            return conexion;
        }

        public void CerrarConexion()
        {
            if (this.Conexion != null)
            {
                this.Conexion.Close();
            }
        }
    }
}
