namespace PagoAgilFrba.AbmFactura
{
    partial class FacturaForm
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
            this.botonAgregarFactura = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.botonEditarFactura = new System.Windows.Forms.Button();
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
            // botonAgregarFactura
            // 
            this.botonAgregarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAgregarFactura.Location = new System.Drawing.Point(75, 57);
            this.botonAgregarFactura.Name = "botonAgregarFactura";
            this.botonAgregarFactura.Size = new System.Drawing.Size(135, 54);
            this.botonAgregarFactura.TabIndex = 9;
            this.botonAgregarFactura.Text = "Agregar factura";
            this.botonAgregarFactura.UseVisualStyleBackColor = true;
            this.botonAgregarFactura.Click += new System.EventHandler(this.botonAgregarFactura_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(12, 224);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(144, 35);
            this.botonVolver.TabIndex = 12;
            this.botonVolver.Text = "< Volver al Menú Principal";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonEditarFactura
            // 
            this.botonEditarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEditarFactura.Location = new System.Drawing.Point(75, 136);
            this.botonEditarFactura.Name = "botonEditarFactura";
            this.botonEditarFactura.Size = new System.Drawing.Size(135, 54);
            this.botonEditarFactura.TabIndex = 10;
            this.botonEditarFactura.Text = "Modificar/Eliminar factura";
            this.botonEditarFactura.UseVisualStyleBackColor = true;
            this.botonEditarFactura.Click += new System.EventHandler(this.botonEditarFactura_Click);
            // 
            // FacturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 271);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonEditarFactura);
            this.Controls.Add(this.botonAgregarFactura);
            this.Controls.Add(this.labelRoles);
            this.Name = "FacturaForm";
            this.Text = "ABM Facturas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRoles;
        private System.Windows.Forms.Button botonAgregarFactura;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonEditarFactura;
    }
}