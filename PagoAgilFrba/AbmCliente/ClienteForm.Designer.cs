﻿namespace PagoAgilFrba.AbmCliente
{
    partial class ClienteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

       #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelRoles = new System.Windows.Forms.Label();
            this.botonBajaRol = new System.Windows.Forms.Button();
            this.botonEditarRol = new System.Windows.Forms.Button();
            this.botonAgregarRol = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelRoles
            // 
            this.labelRoles.AutoSize = true;
            this.labelRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoles.Location = new System.Drawing.Point(122, 9);
            this.labelRoles.Name = "labelRoles";
            this.labelRoles.Size = new System.Drawing.Size(61, 25);
            this.labelRoles.TabIndex = 7;
            this.labelRoles.Text = "Clientes";
            // 
            // botonEditarRol
            // 
            this.botonEditarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEditarRol.Location = new System.Drawing.Point(83, 148);
            this.botonEditarRol.Name = "botonModificarRol";
            this.botonEditarRol.Size = new System.Drawing.Size(135, 54);
            this.botonEditarRol.TabIndex = 5;
            this.botonEditarRol.Text = "Modificar o Eliminar Cliente";
            this.botonEditarRol.UseVisualStyleBackColor = true;
            this.botonEditarRol.Click += new System.EventHandler(this.botonEditarRol_Click);
            // 
            // botonAgregarRol
            // 
            this.botonAgregarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAgregarRol.Location = new System.Drawing.Point(83, 65);
            this.botonAgregarRol.Name = "botonAgregarCliente";
            this.botonAgregarRol.Size = new System.Drawing.Size(135, 54);
            this.botonAgregarRol.TabIndex = 4;
            this.botonAgregarRol.Text = "Agregar Cliente";
            this.botonAgregarRol.UseVisualStyleBackColor = true;
            this.botonAgregarRol.Click += new System.EventHandler(this.botonAgregarCliente_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(15, 321);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(144, 35);
            this.botonVolver.TabIndex = 8;
            this.botonVolver.Text = "< Volver al Menú Principal";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // RolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 386);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.labelRoles);
            this.Controls.Add(this.botonBajaRol);
            this.Controls.Add(this.botonEditarRol);
            this.Controls.Add(this.botonAgregarRol);
            this.Name = "ClienteForm";
            this.Text = "ClienteForm";
            this.Load += new System.EventHandler(this.ClienteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRoles;
        private System.Windows.Forms.Button botonBajaRol;
        private System.Windows.Forms.Button botonEditarRol;
        private System.Windows.Forms.Button botonAgregarRol;
        private System.Windows.Forms.Button botonVolver;
    }
}
