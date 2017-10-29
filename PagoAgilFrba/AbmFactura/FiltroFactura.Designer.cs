namespace PagoAgilFrba.AbmFactura
{
    partial class FiltroFactura
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
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxEmpresas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_nrofact = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_dni = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView_Factura = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Factura)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(12, 121);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(100, 30);
            this.button_Cancelar.TabIndex = 7;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click_1);
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.Location = new System.Drawing.Point(118, 121);
            this.button_Limpiar.Name = "button_Limpiar";
            this.button_Limpiar.Size = new System.Drawing.Size(100, 30);
            this.button_Limpiar.TabIndex = 6;
            this.button_Limpiar.Text = "Limpiar";
            this.button_Limpiar.UseVisualStyleBackColor = true;
            this.button_Limpiar.Click += new System.EventHandler(this.button_Limpiar_Click_1);
            // 
            // button_Buscar
            // 
            this.button_Buscar.Location = new System.Drawing.Point(224, 121);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(100, 30);
            this.button_Buscar.TabIndex = 5;
            this.button_Buscar.Text = "Buscar";
            this.button_Buscar.UseVisualStyleBackColor = true;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxEmpresas);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_nrofact);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_dni);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 101);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de busqueda";
            // 
            // comboBoxEmpresas
            // 
            this.comboBoxEmpresas.FormattingEnabled = true;
            this.comboBoxEmpresas.Location = new System.Drawing.Point(75, 45);
            this.comboBoxEmpresas.Name = "comboBoxEmpresas";
            this.comboBoxEmpresas.Size = new System.Drawing.Size(220, 21);
            this.comboBoxEmpresas.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "N° Factura";
            // 
            // textBox_nrofact
            // 
            this.textBox_nrofact.Location = new System.Drawing.Point(75, 72);
            this.textBox_nrofact.Name = "textBox_nrofact";
            this.textBox_nrofact.Size = new System.Drawing.Size(220, 20);
            this.textBox_nrofact.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Empresa";
            // 
            // textBox_dni
            // 
            this.textBox_dni.Location = new System.Drawing.Point(75, 19);
            this.textBox_dni.Name = "textBox_dni";
            this.textBox_dni.Size = new System.Drawing.Size(220, 20);
            this.textBox_dni.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "DNI cliente";
            // 
            // dataGridView_Factura
            // 
            this.dataGridView_Factura.AllowUserToAddRows = false;
            this.dataGridView_Factura.AllowUserToDeleteRows = false;
            this.dataGridView_Factura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Factura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Factura.Location = new System.Drawing.Point(12, 157);
            this.dataGridView_Factura.Name = "dataGridView_Factura";
            this.dataGridView_Factura.RowTemplate.ReadOnly = true;
            this.dataGridView_Factura.Size = new System.Drawing.Size(590, 224);
            this.dataGridView_Factura.TabIndex = 8;
            this.dataGridView_Factura.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Factura_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 39);
            this.label2.TabIndex = 10;
            this.label2.Text = "Si usted no encuentra la factura \r\ndeseada puede deberse a que ha \r\nsido pagada y" +
    "/o rendida anteriormente\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(330, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 137);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Atención";
            // 
            // FiltroFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 390);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView_Factura);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Limpiar);
            this.Controls.Add(this.button_Buscar);
            this.Controls.Add(this.groupBox1);
            this.Name = "FiltroFactura";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Filtro de facturas";
            this.Load += new System.EventHandler(this.FiltroFactura_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Factura)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Limpiar;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_Factura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_nrofact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_dni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxEmpresas;
    }
}