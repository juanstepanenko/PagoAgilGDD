﻿namespace PagoAgilFrba.AbmCliente
{
    partial class ModificarCliente
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
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.checkBox_Habilitado = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.monthCalendar_FechaDeNacimiento = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Telefono = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Mail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_FechaDeNacimiento = new System.Windows.Forms.Button();
            this.textBox_FechaDeNacimiento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Dni = new System.Windows.Forms.TextBox();
            this.textBox_Apellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_CodigoPostal = new System.Windows.Forms.TextBox();
            this.textBox_Direccion = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(409, 333);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(100, 30);
            this.button_Guardar.TabIndex = 2;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(12, 333);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(100, 30);
            this.button_Cancelar.TabIndex = 3;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.Location = new System.Drawing.Point(294, 333);
            this.button_Limpiar.Name = "button_Limpiar";
            this.button_Limpiar.Size = new System.Drawing.Size(100, 30);
            this.button_Limpiar.TabIndex = 4;
            this.button_Limpiar.Text = "Limpiar";
            this.button_Limpiar.UseVisualStyleBackColor = true;
            this.button_Limpiar.Click += new System.EventHandler(this.button_Limpiar_Click);
            // 
            // checkBox_Habilitado
            // 
            this.checkBox_Habilitado.AutoSize = true;
            this.checkBox_Habilitado.Location = new System.Drawing.Point(16, 293);
            this.checkBox_Habilitado.Name = "checkBox_Habilitado";
            this.checkBox_Habilitado.Size = new System.Drawing.Size(73, 17);
            this.checkBox_Habilitado.TabIndex = 5;
            this.checkBox_Habilitado.Text = "Habilitado";
            this.checkBox_Habilitado.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBox_CodigoPostal);
            this.groupBox1.Controls.Add(this.monthCalendar_FechaDeNacimiento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBox_Telefono);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBox_Direccion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_Mail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button_FechaDeNacimiento);
            this.groupBox1.Controls.Add(this.textBox_FechaDeNacimiento);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_Dni);
            this.groupBox1.Controls.Add(this.textBox_Apellido);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_Nombre);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 260);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos personales";
            // 
            // monthCalendar_FechaDeNacimiento
            // 
            this.monthCalendar_FechaDeNacimiento.Location = new System.Drawing.Point(230, 51);
            this.monthCalendar_FechaDeNacimiento.Name = "monthCalendar_FechaDeNacimiento";
            this.monthCalendar_FechaDeNacimiento.TabIndex = 13;
            this.monthCalendar_FechaDeNacimiento.Visible = false;
            this.monthCalendar_FechaDeNacimiento.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_FechaDeNacimiento_DateSelected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Telefono";
            // 
            // textBox_Telefono
            // 
            this.textBox_Telefono.Location = new System.Drawing.Point(112, 152);
            this.textBox_Telefono.Name = "textBox_Telefono";
            this.textBox_Telefono.Size = new System.Drawing.Size(385, 20);
            this.textBox_Telefono.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mail";
            // 
            // textBox_Mail
            // 
            this.textBox_Mail.Location = new System.Drawing.Point(112, 125);
            this.textBox_Mail.Name = "textBox_Mail";
            this.textBox_Mail.Size = new System.Drawing.Size(385, 20);
            this.textBox_Mail.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha de nacimiento";
            // 
            // button_FechaDeNacimiento
            // 
            this.button_FechaDeNacimiento.Location = new System.Drawing.Point(417, 100);
            this.button_FechaDeNacimiento.Name = "button_FechaDeNacimiento";
            this.button_FechaDeNacimiento.Size = new System.Drawing.Size(80, 20);
            this.button_FechaDeNacimiento.TabIndex = 7;
            this.button_FechaDeNacimiento.Text = "Seleccionar";
            this.button_FechaDeNacimiento.UseVisualStyleBackColor = true;
            this.button_FechaDeNacimiento.Click += new System.EventHandler(this.button_FechaDeNacimiento_Click);
            // 
            // textBox_FechaDeNacimiento
            // 
            this.textBox_FechaDeNacimiento.Location = new System.Drawing.Point(112, 100);
            this.textBox_FechaDeNacimiento.Name = "textBox_FechaDeNacimiento";
            this.textBox_FechaDeNacimiento.Size = new System.Drawing.Size(293, 20);
            this.textBox_FechaDeNacimiento.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dni";
            // 
            // textBox_Dni
            // 
            this.textBox_Dni.Location = new System.Drawing.Point(112, 74);
            this.textBox_Dni.Name = "textBox_Dni";
            this.textBox_Dni.Size = new System.Drawing.Size(388, 20);
            this.textBox_Dni.TabIndex = 4;
            // 
            // textBox_Apellido
            // 
            this.textBox_Apellido.Location = new System.Drawing.Point(112, 45);
            this.textBox_Apellido.Name = "textBox_Apellido";
            this.textBox_Apellido.Size = new System.Drawing.Size(388, 20);
            this.textBox_Apellido.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido";
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Location = new System.Drawing.Point(112, 19);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(388, 20);
            this.textBox_Nombre.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Nombre";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Codigo postal";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 189);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Direccion";
            // 
            // textBox_CodigoPostal
            // 
            this.textBox_CodigoPostal.Location = new System.Drawing.Point(112, 214);
            this.textBox_CodigoPostal.Name = "textBox_CodigoPostal";
            this.textBox_CodigoPostal.Size = new System.Drawing.Size(385, 20);
            this.textBox_CodigoPostal.TabIndex = 15;
            // 
            // textBox_Direccion
            // 
            this.textBox_Direccion.Location = new System.Drawing.Point(112, 182);
            this.textBox_Direccion.Name = "textBox_Direccion";
            this.textBox_Direccion.Size = new System.Drawing.Size(385, 20);
            this.textBox_Direccion.TabIndex = 11;
            // 
            // ModificarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 390);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox_Habilitado);
            this.Controls.Add(this.button_Limpiar);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Guardar);
            this.Name = "ModificarCliente";
            this.Text = "Editar Cliente";
            this.Load += new System.EventHandler(this.ModificarCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Limpiar;
        private System.Windows.Forms.CheckBox checkBox_Habilitado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Telefono;
        private System.Windows.Forms.MonthCalendar monthCalendar_FechaDeNacimiento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Mail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_FechaDeNacimiento;
        private System.Windows.Forms.TextBox textBox_FechaDeNacimiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Dni;
        private System.Windows.Forms.TextBox textBox_Apellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_CodigoPostal;
        private System.Windows.Forms.TextBox textBox_Direccion;
    }
 }
