namespace PagoAgilFrba.AbmSucursal
{
    partial class ModificarSucursal
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
            this.groupBoxIS = new System.Windows.Forms.GroupBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.groupBoxDir = new System.Windows.Forms.GroupBox();
            this.textBoxCP = new System.Windows.Forms.TextBox();
            this.textBoxDirec = new System.Windows.Forms.TextBox();
            this.labelCodPos = new System.Windows.Forms.Label();
            this.labelDirec = new System.Windows.Forms.Label();
            this.checkBoxHab = new System.Windows.Forms.CheckBox();
            this.buttonVol = new System.Windows.Forms.Button();
            this.buttonLimp = new System.Windows.Forms.Button();
            this.buttonGuar = new System.Windows.Forms.Button();
            this.groupBoxIS.SuspendLayout();
            this.groupBoxDir.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxIS
            // 
            this.groupBoxIS.Controls.Add(this.textBoxName);
            this.groupBoxIS.Controls.Add(this.labelNombre);
            this.groupBoxIS.Location = new System.Drawing.Point(12, 12);
            this.groupBoxIS.Name = "groupBoxIS";
            this.groupBoxIS.Size = new System.Drawing.Size(577, 75);
            this.groupBoxIS.TabIndex = 0;
            this.groupBoxIS.TabStop = false;
            this.groupBoxIS.Text = "Información Sucursal";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(159, 30);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(412, 28);
            this.textBoxName.TabIndex = 0;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(28, 40);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(62, 18);
            this.labelNombre.TabIndex = 0;
            this.labelNombre.Text = "Nombre";
            // 
            // groupBoxDir
            // 
            this.groupBoxDir.Controls.Add(this.textBoxCP);
            this.groupBoxDir.Controls.Add(this.textBoxDirec);
            this.groupBoxDir.Controls.Add(this.labelCodPos);
            this.groupBoxDir.Controls.Add(this.labelDirec);
            this.groupBoxDir.Location = new System.Drawing.Point(12, 104);
            this.groupBoxDir.Name = "groupBoxDir";
            this.groupBoxDir.Size = new System.Drawing.Size(577, 120);
            this.groupBoxDir.TabIndex = 1;
            this.groupBoxDir.TabStop = false;
            this.groupBoxDir.Text = "Dirección";
            // 
            // textBoxCP
            // 
            this.textBoxCP.Location = new System.Drawing.Point(159, 61);
            this.textBoxCP.Name = "textBoxCP";
            this.textBoxCP.Size = new System.Drawing.Size(115, 28);
            this.textBoxCP.TabIndex = 3;
            // 
            // textBoxDirec
            // 
            this.textBoxDirec.Location = new System.Drawing.Point(159, 27);
            this.textBoxDirec.Name = "textBoxDirec";
            this.textBoxDirec.Size = new System.Drawing.Size(412, 28);
            this.textBoxDirec.TabIndex = 0;
            // 
            // labelCodPos
            // 
            this.labelCodPos.AutoSize = true;
            this.labelCodPos.Location = new System.Drawing.Point(18, 71);
            this.labelCodPos.Name = "labelCodPos";
            this.labelCodPos.Size = new System.Drawing.Size(125, 18);
            this.labelCodPos.TabIndex = 0;
            this.labelCodPos.Text = "Código Postal";
            // 
            // labelDirec
            // 
            this.labelDirec.AutoSize = true;
            this.labelDirec.Location = new System.Drawing.Point(19, 37);
            this.labelDirec.Name = "labelDirec";
            this.labelDirec.Size = new System.Drawing.Size(89, 18);
            this.labelDirec.TabIndex = 0;
            this.labelDirec.Text = "Dirección";
            // 
            // checkBoxHab
            // 
            this.checkBoxHab.AutoSize = true;
            this.checkBoxHab.Location = new System.Drawing.Point(40, 239);
            this.checkBoxHab.Name = "checkBoxHab";
            this.checkBoxHab.Size = new System.Drawing.Size(124, 22);
            this.checkBoxHab.TabIndex = 1;
            this.checkBoxHab.Text = "Habilitado";
            this.checkBoxHab.UseVisualStyleBackColor = true;
            // 
            // buttonVol
            // 
            this.buttonVol.Location = new System.Drawing.Point(18, 276);
            this.buttonVol.Name = "buttonVol";
            this.buttonVol.Size = new System.Drawing.Size(139, 43);
            this.buttonVol.TabIndex = 1;
            this.buttonVol.Text = "Volver";
            this.buttonVol.UseVisualStyleBackColor = true;
            this.buttonVol.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // buttonLimp
            // 
            this.buttonLimp.Location = new System.Drawing.Point(305, 276);
            this.buttonLimp.Name = "buttonLimp";
            this.buttonLimp.Size = new System.Drawing.Size(139, 43);
            this.buttonLimp.TabIndex = 2;
            this.buttonLimp.Text = "Limpiar";
            this.buttonLimp.UseVisualStyleBackColor = true;
            this.buttonLimp.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // buttonGuar
            // 
            this.buttonGuar.Location = new System.Drawing.Point(450, 276);
            this.buttonGuar.Name = "buttonGuar";
            this.buttonGuar.Size = new System.Drawing.Size(139, 43);
            this.buttonGuar.TabIndex = 0;
            this.buttonGuar.Text = "Guardar";
            this.buttonGuar.UseVisualStyleBackColor = true;
            this.buttonGuar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // ModificarSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 344);
            this.Controls.Add(this.buttonGuar);
            this.Controls.Add(this.buttonLimp);
            this.Controls.Add(this.buttonVol);
            this.Controls.Add(this.checkBoxHab);
            this.Controls.Add(this.groupBoxDir);
            this.Controls.Add(this.groupBoxIS);
            this.Name = "ModificarSucursal";
            this.Text = "ModificarSucursal";
            this.Load += new System.EventHandler(this.ModificarSucursal_Load);
            this.groupBoxIS.ResumeLayout(false);
            this.groupBoxIS.PerformLayout();
            this.groupBoxDir.ResumeLayout(false);
            this.groupBoxDir.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxIS;
        private System.Windows.Forms.GroupBox groupBoxDir;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelCodPos;
        private System.Windows.Forms.Label labelDirec;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDirec;
        private System.Windows.Forms.TextBox textBoxCP;
        private System.Windows.Forms.CheckBox checkBoxHab;
        private System.Windows.Forms.Button buttonVol;
        private System.Windows.Forms.Button buttonLimp;
        private System.Windows.Forms.Button buttonGuar;
    }
}