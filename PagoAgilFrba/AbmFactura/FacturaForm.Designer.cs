namespace PagoAgilFrba.AbmFactura
{
    partial class Form1
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
            this.botonAgregarRol = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.botonBajaRol = new System.Windows.Forms.Button();
            this.botonEditarRol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelRoles
            // 
            this.labelRoles.AutoSize = true;
            this.labelRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoles.Location = new System.Drawing.Point(99, 9);
            this.labelRoles.Name = "labelRoles";
            this.labelRoles.Size = new System.Drawing.Size(88, 25);
            this.labelRoles.TabIndex = 8;
            this.labelRoles.Text = "Facturas";
            // 
            // botonAgregarRol
            // 
            this.botonAgregarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAgregarRol.Location = new System.Drawing.Point(75, 57);
            this.botonAgregarRol.Name = "botonAgregarRol";
            this.botonAgregarRol.Size = new System.Drawing.Size(135, 54);
            this.botonAgregarRol.TabIndex = 9;
            this.botonAgregarRol.Text = "Agregar factura";
            this.botonAgregarRol.UseVisualStyleBackColor = true;
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(7, 309);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(144, 35);
            this.botonVolver.TabIndex = 12;
            this.botonVolver.Text = "< Volver al Menú Principal";
            this.botonVolver.UseVisualStyleBackColor = true;
            // 
            // botonBajaRol
            // 
            this.botonBajaRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBajaRol.Location = new System.Drawing.Point(75, 216);
            this.botonBajaRol.Name = "botonBajaRol";
            this.botonBajaRol.Size = new System.Drawing.Size(135, 54);
            this.botonBajaRol.TabIndex = 11;
            this.botonBajaRol.Text = "Eliminar factura";
            this.botonBajaRol.UseVisualStyleBackColor = true;
            // 
            // botonEditarRol
            // 
            this.botonEditarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEditarRol.Location = new System.Drawing.Point(75, 136);
            this.botonEditarRol.Name = "botonEditarRol";
            this.botonEditarRol.Size = new System.Drawing.Size(135, 54);
            this.botonEditarRol.TabIndex = 10;
            this.botonEditarRol.Text = "Editar factura";
            this.botonEditarRol.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonBajaRol);
            this.Controls.Add(this.botonEditarRol);
            this.Controls.Add(this.botonAgregarRol);
            this.Controls.Add(this.labelRoles);
            this.Name = "Form1";
            this.Text = "ABM Facturas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRoles;
        private System.Windows.Forms.Button botonAgregarRol;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonBajaRol;
        private System.Windows.Forms.Button botonEditarRol;
    }
}