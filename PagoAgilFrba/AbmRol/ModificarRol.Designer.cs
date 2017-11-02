namespace PagoAgilFrba.AbmRol
{
    partial class ModificarRol
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
            this.botonVolver = new System.Windows.Forms.Button();
            this.botonGuardar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.checkedListBoxFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.labelFuncionalidades = new System.Windows.Forms.Label();
            this.textBoxRol = new System.Windows.Forms.TextBox();
            this.labelRol = new System.Windows.Forms.Label();
            this.labelNuevoRol = new System.Windows.Forms.Label();
            this.labelRolElegido = new System.Windows.Forms.Label();
            this.checkBoxEstadoRol = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // botonVolver
            // 
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.botonVolver.Location = new System.Drawing.Point(12, 389);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(99, 46);
            this.botonVolver.TabIndex = 0;
            this.botonVolver.Text = "< Volver a menu de rol";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonGuardar
            // 
            this.botonGuardar.Location = new System.Drawing.Point(320, 390);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(88, 35);
            this.botonGuardar.TabIndex = 7;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.UseVisualStyleBackColor = true;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(233, 390);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(81, 35);
            this.botonLimpiar.TabIndex = 6;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // checkedListBoxFuncionalidades
            // 
            this.checkedListBoxFuncionalidades.FormattingEnabled = true;
            this.checkedListBoxFuncionalidades.Location = new System.Drawing.Point(176, 106);
            this.checkedListBoxFuncionalidades.Name = "checkedListBoxFuncionalidades";
            this.checkedListBoxFuncionalidades.Size = new System.Drawing.Size(194, 214);
            this.checkedListBoxFuncionalidades.TabIndex = 5;
            // 
            // labelFuncionalidades
            // 
            this.labelFuncionalidades.AutoSize = true;
            this.labelFuncionalidades.Location = new System.Drawing.Point(59, 106);
            this.labelFuncionalidades.Name = "labelFuncionalidades";
            this.labelFuncionalidades.Size = new System.Drawing.Size(84, 13);
            this.labelFuncionalidades.TabIndex = 2;
            this.labelFuncionalidades.Text = "Funcionalidades";
            // 
            // textBoxRol
            // 
            this.textBoxRol.Location = new System.Drawing.Point(176, 62);
            this.textBoxRol.Name = "textBoxRol";
            this.textBoxRol.Size = new System.Drawing.Size(71, 20);
            this.textBoxRol.TabIndex = 0;
            // 
            // labelRol
            // 
            this.labelRol.AutoSize = true;
            this.labelRol.Location = new System.Drawing.Point(59, 32);
            this.labelRol.Name = "labelRol";
            this.labelRol.Size = new System.Drawing.Size(61, 13);
            this.labelRol.TabIndex = 1;
            this.labelRol.Text = "Rol Elegido";
            // 
            // labelNuevoRol
            // 
            this.labelNuevoRol.AutoSize = true;
            this.labelNuevoRol.Location = new System.Drawing.Point(59, 65);
            this.labelNuevoRol.Name = "labelNuevoRol";
            this.labelNuevoRol.Size = new System.Drawing.Size(79, 13);
            this.labelNuevoRol.TabIndex = 2;
            this.labelNuevoRol.Text = "Nuevo Nombre";
            // 
            // labelRolElegido
            // 
            this.labelRolElegido.AutoSize = true;
            this.labelRolElegido.Location = new System.Drawing.Point(141, 32);
            this.labelRolElegido.Name = "labelRolElegido";
            this.labelRolElegido.Size = new System.Drawing.Size(0, 13);
            this.labelRolElegido.TabIndex = 8;
            // 
            // checkBoxEstadoRol
            // 
            this.checkBoxEstadoRol.AutoSize = true;
            this.checkBoxEstadoRol.Location = new System.Drawing.Point(176, 337);
            this.checkBoxEstadoRol.Name = "checkBoxEstadoRol";
            this.checkBoxEstadoRol.Size = new System.Drawing.Size(73, 17);
            this.checkBoxEstadoRol.TabIndex = 9;
            this.checkBoxEstadoRol.Text = "Habilitado";
            this.checkBoxEstadoRol.UseVisualStyleBackColor = true;
            // 
            // ModificarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 459);
            this.Controls.Add(this.checkBoxEstadoRol);
            this.Controls.Add(this.labelRolElegido);
            this.Controls.Add(this.botonGuardar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.checkedListBoxFuncionalidades);
            this.Controls.Add(this.textBoxRol);
            this.Controls.Add(this.labelNuevoRol);
            this.Controls.Add(this.labelFuncionalidades);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.labelRol);
            this.Name = "ModificarRol";
            this.Text = "EditarRol";
            this.Load += new System.EventHandler(this.ModificarRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.CheckedListBox checkedListBoxFuncionalidades;
        private System.Windows.Forms.Label labelFuncionalidades;
        private System.Windows.Forms.Button botonGuardar;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.TextBox textBoxRol;
        private System.Windows.Forms.Label labelRol;
        private System.Windows.Forms.Label labelNuevoRol;
        private System.Windows.Forms.Label labelRolElegido;
        private System.Windows.Forms.CheckBox checkBoxEstadoRol;
    }
}