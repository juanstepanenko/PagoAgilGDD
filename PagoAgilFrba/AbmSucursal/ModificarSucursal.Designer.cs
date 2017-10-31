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
            this.textBoxLoc = new System.Windows.Forms.TextBox();
            this.textBoxCP = new System.Windows.Forms.TextBox();
            this.textBoxDto = new System.Windows.Forms.TextBox();
            this.textBoxPiso = new System.Windows.Forms.TextBox();
            this.textBoxCalleNro = new System.Windows.Forms.TextBox();
            this.labelLoc = new System.Windows.Forms.Label();
            this.labelCodPos = new System.Windows.Forms.Label();
            this.labelDto = new System.Windows.Forms.Label();
            this.labelPiso = new System.Windows.Forms.Label();
            this.labelCalleNro = new System.Windows.Forms.Label();
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
            this.groupBoxIS.Size = new System.Drawing.Size(502, 75);
            this.groupBoxIS.TabIndex = 0;
            this.groupBoxIS.TabStop = false;
            this.groupBoxIS.Text = "Información Sucursal";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(159, 30);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(319, 28);
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
            this.groupBoxDir.Controls.Add(this.textBoxLoc);
            this.groupBoxDir.Controls.Add(this.textBoxCP);
            this.groupBoxDir.Controls.Add(this.textBoxDto);
            this.groupBoxDir.Controls.Add(this.textBoxPiso);
            this.groupBoxDir.Controls.Add(this.textBoxCalleNro);
            this.groupBoxDir.Controls.Add(this.labelLoc);
            this.groupBoxDir.Controls.Add(this.labelCodPos);
            this.groupBoxDir.Controls.Add(this.labelDto);
            this.groupBoxDir.Controls.Add(this.labelPiso);
            this.groupBoxDir.Controls.Add(this.labelCalleNro);
            this.groupBoxDir.Location = new System.Drawing.Point(12, 104);
            this.groupBoxDir.Name = "groupBoxDir";
            this.groupBoxDir.Size = new System.Drawing.Size(502, 208);
            this.groupBoxDir.TabIndex = 1;
            this.groupBoxDir.TabStop = false;
            this.groupBoxDir.Text = "Dirección";
            // 
            // textBoxLoc
            // 
            this.textBoxLoc.Location = new System.Drawing.Point(159, 163);
            this.textBoxLoc.Name = "textBoxLoc";
            this.textBoxLoc.Size = new System.Drawing.Size(115, 28);
            this.textBoxLoc.TabIndex = 5;
            // 
            // textBoxCP
            // 
            this.textBoxCP.Location = new System.Drawing.Point(160, 129);
            this.textBoxCP.Name = "textBoxCP";
            this.textBoxCP.Size = new System.Drawing.Size(115, 28);
            this.textBoxCP.TabIndex = 4;
            // 
            // textBoxDto
            // 
            this.textBoxDto.Location = new System.Drawing.Point(159, 95);
            this.textBoxDto.Name = "textBoxDto";
            this.textBoxDto.Size = new System.Drawing.Size(115, 28);
            this.textBoxDto.TabIndex = 3;
            // 
            // textBoxPiso
            // 
            this.textBoxPiso.Location = new System.Drawing.Point(159, 61);
            this.textBoxPiso.Name = "textBoxPiso";
            this.textBoxPiso.Size = new System.Drawing.Size(115, 28);
            this.textBoxPiso.TabIndex = 2;
            // 
            // textBoxCalleNro
            // 
            this.textBoxCalleNro.Location = new System.Drawing.Point(159, 27);
            this.textBoxCalleNro.Name = "textBoxCalleNro";
            this.textBoxCalleNro.Size = new System.Drawing.Size(319, 28);
            this.textBoxCalleNro.TabIndex = 0;
            // 
            // labelLoc
            // 
            this.labelLoc.AutoSize = true;
            this.labelLoc.Location = new System.Drawing.Point(19, 173);
            this.labelLoc.Name = "labelLoc";
            this.labelLoc.Size = new System.Drawing.Size(89, 18);
            this.labelLoc.TabIndex = 0;
            this.labelLoc.Text = "Localidad";
            this.labelLoc.Click += new System.EventHandler(this.label7_Click);
            // 
            // labelCodPos
            // 
            this.labelCodPos.AutoSize = true;
            this.labelCodPos.Location = new System.Drawing.Point(19, 139);
            this.labelCodPos.Name = "labelCodPos";
            this.labelCodPos.Size = new System.Drawing.Size(125, 18);
            this.labelCodPos.TabIndex = 0;
            this.labelCodPos.Text = "Código Postal";
            // 
            // labelDto
            // 
            this.labelDto.AutoSize = true;
            this.labelDto.Location = new System.Drawing.Point(19, 105);
            this.labelDto.Name = "labelDto";
            this.labelDto.Size = new System.Drawing.Size(116, 18);
            this.labelDto.TabIndex = 0;
            this.labelDto.Text = "Departamento";
            // 
            // labelPiso
            // 
            this.labelPiso.AutoSize = true;
            this.labelPiso.Location = new System.Drawing.Point(19, 71);
            this.labelPiso.Name = "labelPiso";
            this.labelPiso.Size = new System.Drawing.Size(44, 18);
            this.labelPiso.TabIndex = 0;
            this.labelPiso.Text = "Piso";
            // 
            // labelCalleNro
            // 
            this.labelCalleNro.AutoSize = true;
            this.labelCalleNro.Location = new System.Drawing.Point(19, 37);
            this.labelCalleNro.Name = "labelCalleNro";
            this.labelCalleNro.Size = new System.Drawing.Size(134, 18);
            this.labelCalleNro.TabIndex = 0;
            this.labelCalleNro.Text = "Calle y Número";
            // 
            // checkBoxHab
            // 
            this.checkBoxHab.AutoSize = true;
            this.checkBoxHab.Location = new System.Drawing.Point(34, 328);
            this.checkBoxHab.Name = "checkBoxHab";
            this.checkBoxHab.Size = new System.Drawing.Size(133, 22);
            this.checkBoxHab.TabIndex = 1;
            this.checkBoxHab.Text = "Rehabilitar";
            this.checkBoxHab.UseVisualStyleBackColor = true;
            // 
            // buttonVol
            // 
            this.buttonVol.Location = new System.Drawing.Point(12, 365);
            this.buttonVol.Name = "buttonVol";
            this.buttonVol.Size = new System.Drawing.Size(139, 43);
            this.buttonVol.TabIndex = 3;
            this.buttonVol.Text = "Volver";
            this.buttonVol.UseVisualStyleBackColor = true;
            this.buttonVol.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // buttonLimp
            // 
            this.buttonLimp.Location = new System.Drawing.Point(230, 365);
            this.buttonLimp.Name = "buttonLimp";
            this.buttonLimp.Size = new System.Drawing.Size(139, 43);
            this.buttonLimp.TabIndex = 4;
            this.buttonLimp.Text = "Limpiar";
            this.buttonLimp.UseVisualStyleBackColor = true;
            this.buttonLimp.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // buttonGuar
            // 
            this.buttonGuar.Location = new System.Drawing.Point(375, 365);
            this.buttonGuar.Name = "buttonGuar";
            this.buttonGuar.Size = new System.Drawing.Size(139, 43);
            this.buttonGuar.TabIndex = 2;
            this.buttonGuar.Text = "Guardar";
            this.buttonGuar.UseVisualStyleBackColor = true;
            this.buttonGuar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // ModificarSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 421);
            this.Controls.Add(this.buttonGuar);
            this.Controls.Add(this.buttonLimp);
            this.Controls.Add(this.buttonVol);
            this.Controls.Add(this.checkBoxHab);
            this.Controls.Add(this.groupBoxDir);
            this.Controls.Add(this.groupBoxIS);
            this.Name = "ModificarSucursal";
            this.Text = "ModificarSucursal";
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
        private System.Windows.Forms.Label labelLoc;
        private System.Windows.Forms.Label labelCodPos;
        private System.Windows.Forms.Label labelDto;
        private System.Windows.Forms.Label labelPiso;
        private System.Windows.Forms.Label labelCalleNro;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxCalleNro;
        private System.Windows.Forms.TextBox textBoxLoc;
        private System.Windows.Forms.TextBox textBoxCP;
        private System.Windows.Forms.TextBox textBoxDto;
        private System.Windows.Forms.TextBox textBoxPiso;
        private System.Windows.Forms.CheckBox checkBoxHab;
        private System.Windows.Forms.Button buttonVol;
        private System.Windows.Forms.Button buttonLimp;
        private System.Windows.Forms.Button buttonGuar;
    }
}