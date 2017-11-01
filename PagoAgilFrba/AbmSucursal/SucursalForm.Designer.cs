namespace PagoAgilFrba.AbmSucursal
{
    partial class SucursalForm
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
            this.labelSucu = new System.Windows.Forms.Label();
            this.botonEditarSucu = new System.Windows.Forms.Button();
            this.botonAgregarSucu = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSucu
            // 
            this.labelSucu.AutoSize = true;
            this.labelSucu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSucu.Location = new System.Drawing.Point(149, 30);
            this.labelSucu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSucu.Name = "labelSucu";
            this.labelSucu.Size = new System.Drawing.Size(163, 36);
            this.labelSucu.TabIndex = 7;
            this.labelSucu.Text = "Sucursales";
            // 
            // botonEditarSucu
            // 
            this.botonEditarSucu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEditarSucu.Location = new System.Drawing.Point(124, 205);
            this.botonEditarSucu.Margin = new System.Windows.Forms.Padding(4);
            this.botonEditarSucu.Name = "botonEditarSucu";
            this.botonEditarSucu.Size = new System.Drawing.Size(202, 75);
            this.botonEditarSucu.TabIndex = 1;
            this.botonEditarSucu.Text = "Modificar o Eliminar Sucursal";
            this.botonEditarSucu.UseVisualStyleBackColor = true;
            this.botonEditarSucu.Click += new System.EventHandler(this.botonEditarSucu_Click);
            // 
            // botonAgregarSucu
            // 
            this.botonAgregarSucu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAgregarSucu.Location = new System.Drawing.Point(124, 90);
            this.botonAgregarSucu.Margin = new System.Windows.Forms.Padding(4);
            this.botonAgregarSucu.Name = "botonAgregarSucu";
            this.botonAgregarSucu.Size = new System.Drawing.Size(202, 75);
            this.botonAgregarSucu.TabIndex = 0;
            this.botonAgregarSucu.Text = "Agregar Sucursal";
            this.botonAgregarSucu.UseVisualStyleBackColor = true;
            this.botonAgregarSucu.Click += new System.EventHandler(this.botonAgregarSucu_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(22, 444);
            this.botonVolver.Margin = new System.Windows.Forms.Padding(4);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(216, 48);
            this.botonVolver.TabIndex = 2;
            this.botonVolver.Text = "< Volver al Menú Principal";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // SucursalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 534);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.labelSucu);
            this.Controls.Add(this.botonEditarSucu);
            this.Controls.Add(this.botonAgregarSucu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SucursalForm";
            this.Text = "ClienteForm";
            this.Load += new System.EventHandler(this.SucursalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSucu;
        private System.Windows.Forms.Button botonEditarSucu;
        private System.Windows.Forms.Button botonAgregarSucu;
        private System.Windows.Forms.Button botonVolver;
    }
}