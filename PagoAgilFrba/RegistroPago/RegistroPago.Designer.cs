﻿using System.Windows.Forms;

namespace PagoAgilFrba.RegistroPago
{
    partial class RegistroPago
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.monthCalendar_FechaDeVencimiento = new System.Windows.Forms.MonthCalendar();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_MedioPago = new System.Windows.Forms.ComboBox();
            this.comboBox_Cliente = new System.Windows.Forms.ComboBox();
            this.textBox_Sucursal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_FechaDeVencimiento = new System.Windows.Forms.Button();
            this.textBox_FechaDeVencimiento = new System.Windows.Forms.TextBox();
            this.comboBox_Empresa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Importe = new System.Windows.Forms.TextBox();
            this.textBox_NroFact = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.labelFechaCuadro = new System.Windows.Forms.Label();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_AgregarFactura = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.monthCalendar_FechaDeVencimiento);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox_MedioPago);
            this.groupBox1.Controls.Add(this.comboBox_Cliente);
            this.groupBox1.Controls.Add(this.textBox_Sucursal);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button_FechaDeVencimiento);
            this.groupBox1.Controls.Add(this.textBox_FechaDeVencimiento);
            this.groupBox1.Controls.Add(this.comboBox_Empresa);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox_Importe);
            this.groupBox1.Controls.Add(this.textBox_NroFact);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelFecha);
            this.groupBox1.Controls.Add(this.labelFechaCuadro);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 301);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Pago";
            // 
            // monthCalendar_FechaDeVencimiento
            // 
            this.monthCalendar_FechaDeVencimiento.Location = new System.Drawing.Point(182, 26);
            this.monthCalendar_FechaDeVencimiento.Name = "monthCalendar_FechaDeVencimiento";
            this.monthCalendar_FechaDeVencimiento.TabIndex = 13;
            this.monthCalendar_FechaDeVencimiento.Visible = false;
            this.monthCalendar_FechaDeVencimiento.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_FechaDeVencimiento_DateSelected);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cliente";
            // 
            // comboBox_MedioPago
            // 
            this.comboBox_MedioPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_MedioPago.FormattingEnabled = true;
            this.comboBox_MedioPago.Location = new System.Drawing.Point(124, 250);
            this.comboBox_MedioPago.Name = "comboBox_MedioPago";
            this.comboBox_MedioPago.Size = new System.Drawing.Size(238, 23);
            this.comboBox_MedioPago.TabIndex = 14;
            // 
            // comboBox_Cliente
            // 
            this.comboBox_Cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Cliente.FormattingEnabled = true;
            this.comboBox_Cliente.Location = new System.Drawing.Point(124, 115);
            this.comboBox_Cliente.Name = "comboBox_Cliente";
            this.comboBox_Cliente.Size = new System.Drawing.Size(238, 23);
            this.comboBox_Cliente.TabIndex = 9;
            // 
            // textBox_Sucursal
            // 
            this.textBox_Sucursal.Location = new System.Drawing.Point(124, 218);
            this.textBox_Sucursal.Name = "textBox_Sucursal";
            this.textBox_Sucursal.Size = new System.Drawing.Size(238, 20);
            this.textBox_Sucursal.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Sucursal";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 22;
            this.label7.Text = "Medio De Pago";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha De Vencimiento";
            // 
            // button_FechaDeVencimiento
            // 
            this.button_FechaDeVencimiento.Location = new System.Drawing.Point(288, 150);
            this.button_FechaDeVencimiento.Name = "button_FechaDeVencimiento";
            this.button_FechaDeVencimiento.Size = new System.Drawing.Size(80, 20);
            this.button_FechaDeVencimiento.TabIndex = 7;
            this.button_FechaDeVencimiento.Text = "Seleccionar";
            this.button_FechaDeVencimiento.UseVisualStyleBackColor = true;
            // 
            // textBox_FechaDeVencimiento
            // 
            this.textBox_FechaDeVencimiento.Location = new System.Drawing.Point(124, 150);
            this.textBox_FechaDeVencimiento.Name = "textBox_FechaDeVencimiento";
            this.textBox_FechaDeVencimiento.Size = new System.Drawing.Size(152, 20);
            this.textBox_FechaDeVencimiento.TabIndex = 6;
            // 
            // comboBox_Empresa
            // 
            this.comboBox_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Empresa.FormattingEnabled = true;
            this.comboBox_Empresa.Location = new System.Drawing.Point(124, 82);
            this.comboBox_Empresa.Name = "comboBox_Empresa";
            this.comboBox_Empresa.Size = new System.Drawing.Size(238, 23);
            this.comboBox_Empresa.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Empresa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Importe";
            // 
            // textBox_Importe
            // 
            this.textBox_Importe.Location = new System.Drawing.Point(124, 183);
            this.textBox_Importe.Name = "textBox_Importe";
            this.textBox_Importe.Size = new System.Drawing.Size(238, 20);
            this.textBox_Importe.TabIndex = 15;
            // 
            // textBox_NroFact
            // 
            this.textBox_NroFact.Location = new System.Drawing.Point(124, 19);
            this.textBox_NroFact.Name = "textBox_NroFact";
            this.textBox_NroFact.Size = new System.Drawing.Size(238, 20);
            this.textBox_NroFact.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de Factura";
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Location = new System.Drawing.Point(6, 57);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(85, 13);
            this.labelFecha.TabIndex = 0;
            this.labelFecha.Text = "Fecha De Cobro";
            // 
            // labelFechaCuadro
            // 
            this.labelFechaCuadro.AutoSize = true;
            this.labelFechaCuadro.Location = new System.Drawing.Point(121, 57);
            this.labelFechaCuadro.Name = "labelFechaCuadro";
            this.labelFechaCuadro.Size = new System.Drawing.Size(65, 13);
            this.labelFechaCuadro.TabIndex = 0;
            this.labelFechaCuadro.Text = "29/10/2017";
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(284, 364);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(90, 38);
            this.button_Guardar.TabIndex = 2;
            this.button_Guardar.Text = "Guardar Pago";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(12, 364);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(71, 38);
            this.button_Cancelar.TabIndex = 3;
            this.button_Cancelar.Text = "Volver";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_AgregarFactura
            // 
            this.button_AgregarFactura.Location = new System.Drawing.Point(126, 364);
            this.button_AgregarFactura.Name = "button_AgregarFactura";
            this.button_AgregarFactura.Size = new System.Drawing.Size(152, 38);
            this.button_AgregarFactura.TabIndex = 4;
            this.button_AgregarFactura.Text = "Agregar Otra Factura";
            this.button_AgregarFactura.UseVisualStyleBackColor = true;
            this.button_AgregarFactura.Click += new System.EventHandler(this.button_AgregarFactura_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 333);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(174, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "* Debe completar todos los campos";
            // 
            // RegistroPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 481);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button_AgregarFactura);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegistroPago";
            this.Text = "Cargar Pago";
            this.Load += new System.EventHandler(this.RegistroPago_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_MedioPago;
        private System.Windows.Forms.TextBox textBox_NroFact;
        private System.Windows.Forms.ComboBox comboBox_Empresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_Cliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_FechaDeVencimiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Importe;
        private System.Windows.Forms.TextBox textBox_Sucursal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_AgregarFactura;
        private System.Windows.Forms.MonthCalendar monthCalendar_FechaDeVencimiento;
        private System.Windows.Forms.TextBox textBox_FechaDeVencimiento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelFechaCuadro;
    }
}