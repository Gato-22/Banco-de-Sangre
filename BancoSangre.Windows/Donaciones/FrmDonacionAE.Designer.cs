
namespace BancoSangre.Windows.Donaciones
{
    partial class FrmDonacionAE
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
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtident = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtvenc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcaNT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.FechaDonaciondateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.FechaIngresodateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.DonanteComboBox = new System.Windows.Forms.ComboBox();
            this.PacienteComboBox = new System.Windows.Forms.ComboBox();
            this.TipoDonacionComboBox = new System.Windows.Forms.ComboBox();
            this.TipoDonacionAutomatizadaComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Identificacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Fecha de Donacion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Donacion";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::BancoSangre.Windows.Properties.Resources.cancel_64px;
            this.btnCancelar.Location = new System.Drawing.Point(315, 281);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 82);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::BancoSangre.Windows.Properties.Resources.in_progress_64px;
            this.btnAceptar.Location = new System.Drawing.Point(222, 281);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(84, 82);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtident
            // 
            this.txtident.Location = new System.Drawing.Point(222, 69);
            this.txtident.Name = "txtident";
            this.txtident.Size = new System.Drawing.Size(133, 20);
            this.txtident.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Fecha de Ingreso";
            // 
            // txtvenc
            // 
            this.txtvenc.Location = new System.Drawing.Point(222, 229);
            this.txtvenc.Name = "txtvenc";
            this.txtvenc.Size = new System.Drawing.Size(67, 20);
            this.txtvenc.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Vencimiento";
            // 
            // txtcaNT
            // 
            this.txtcaNT.Location = new System.Drawing.Point(222, 255);
            this.txtcaNT.Name = "txtcaNT";
            this.txtcaNT.Size = new System.Drawing.Size(177, 20);
            this.txtcaNT.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(142, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Cantidad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(401, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "4 letras o numeros";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(401, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "10 Letras o numeros";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(401, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Notas:";
            // 
            // FechaDonaciondateTimePicker1
            // 
            this.FechaDonaciondateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaDonaciondateTimePicker1.Location = new System.Drawing.Point(222, 38);
            this.FechaDonaciondateTimePicker1.Name = "FechaDonaciondateTimePicker1";
            this.FechaDonaciondateTimePicker1.Size = new System.Drawing.Size(133, 20);
            this.FechaDonaciondateTimePicker1.TabIndex = 25;
            // 
            // FechaIngresodateTimePicker2
            // 
            this.FechaIngresodateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaIngresodateTimePicker2.Location = new System.Drawing.Point(222, 203);
            this.FechaIngresodateTimePicker2.Name = "FechaIngresodateTimePicker2";
            this.FechaIngresodateTimePicker2.Size = new System.Drawing.Size(133, 20);
            this.FechaIngresodateTimePicker2.TabIndex = 26;
            // 
            // DonanteComboBox
            // 
            this.DonanteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DonanteComboBox.FormattingEnabled = true;
            this.DonanteComboBox.Location = new System.Drawing.Point(222, 95);
            this.DonanteComboBox.Name = "DonanteComboBox";
            this.DonanteComboBox.Size = new System.Drawing.Size(177, 21);
            this.DonanteComboBox.TabIndex = 1;
            // 
            // PacienteComboBox
            // 
            this.PacienteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PacienteComboBox.FormattingEnabled = true;
            this.PacienteComboBox.Location = new System.Drawing.Point(222, 122);
            this.PacienteComboBox.Name = "PacienteComboBox";
            this.PacienteComboBox.Size = new System.Drawing.Size(177, 21);
            this.PacienteComboBox.TabIndex = 2;
            // 
            // TipoDonacionComboBox
            // 
            this.TipoDonacionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoDonacionComboBox.FormattingEnabled = true;
            this.TipoDonacionComboBox.Location = new System.Drawing.Point(222, 149);
            this.TipoDonacionComboBox.Name = "TipoDonacionComboBox";
            this.TipoDonacionComboBox.Size = new System.Drawing.Size(177, 21);
            this.TipoDonacionComboBox.TabIndex = 3;
            this.TipoDonacionComboBox.SelectedValueChanged += new System.EventHandler(this.TipoDonacionComboBox_SelectedValueChanged);
            // 
            // TipoDonacionAutomatizadaComboBox
            // 
            this.TipoDonacionAutomatizadaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoDonacionAutomatizadaComboBox.FormattingEnabled = true;
            this.TipoDonacionAutomatizadaComboBox.Location = new System.Drawing.Point(222, 176);
            this.TipoDonacionAutomatizadaComboBox.Name = "TipoDonacionAutomatizadaComboBox";
            this.TipoDonacionAutomatizadaComboBox.Size = new System.Drawing.Size(177, 21);
            this.TipoDonacionAutomatizadaComboBox.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(167, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Donante";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(167, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Paciente";
            this.label12.Click += new System.EventHandler(this.label11_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(122, 152);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Tipo De Donacion";
            this.label13.Click += new System.EventHandler(this.label11_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(55, 179);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(161, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Tipo De Donacion Automatizada";
            this.label14.Click += new System.EventHandler(this.label11_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmDonacionAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 375);
            this.Controls.Add(this.TipoDonacionAutomatizadaComboBox);
            this.Controls.Add(this.TipoDonacionComboBox);
            this.Controls.Add(this.PacienteComboBox);
            this.Controls.Add(this.DonanteComboBox);
            this.Controls.Add(this.FechaIngresodateTimePicker2);
            this.Controls.Add(this.FechaDonaciondateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtcaNT);
            this.Controls.Add(this.txtvenc);
            this.Controls.Add(this.txtident);
            this.Name = "FrmDonacionAE";
            this.Text = "FrmDonacionAE";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtident;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtvenc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtcaNT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker FechaDonaciondateTimePicker1;
        private System.Windows.Forms.DateTimePicker FechaIngresodateTimePicker2;
        private System.Windows.Forms.ComboBox DonanteComboBox;
        private System.Windows.Forms.ComboBox PacienteComboBox;
        private System.Windows.Forms.ComboBox TipoDonacionComboBox;
        private System.Windows.Forms.ComboBox TipoDonacionAutomatizadaComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}