﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuPrincipal());
            //Application.Run(new AbmCliente.ModificarCliente("40134522"));
            //Application.Run(new AbmCliente.FiltroCliente());
            //Application.Run(new AbmRol.ModificarRol("serKpa"));
            //Application.Run(new AbmRol.RolForm());
        }
    }
}
