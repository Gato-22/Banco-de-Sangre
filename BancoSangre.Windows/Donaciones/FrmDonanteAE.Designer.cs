
namespace BancoSangre.Windows.Donaciones
{
    partial class FrmDonanteAE
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.DocumentoComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.GeneroComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FechadateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.GrupoSanguineoComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TelefonoMoviltxt = new System.Windows.Forms.TextBox();
            this.CorreoElectronicoTxt = new System.Windows.Forms.TextBox();
            this.TelefonoFijoTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LocalidadComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.provinciasComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.direcciontxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Apellidotxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NroDocumentoTxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.NombreTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::BancoSangre.Windows.Properties.Resources.cancel_64px;
            this.btnCancelar.Location = new System.Drawing.Point(410, 487);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 94);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::BancoSangre.Windows.Properties.Resources.in_progress_64px;
            this.btnAceptar.Location = new System.Drawing.Point(250, 487);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(101, 94);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // DocumentoComboBox
            // 
            this.DocumentoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DocumentoComboBox.FormattingEnabled = true;
            this.DocumentoComboBox.Location = new System.Drawing.Point(201, 79);
            this.DocumentoComboBox.Name = "DocumentoComboBox";
            this.DocumentoComboBox.Size = new System.Drawing.Size(125, 21);
            this.DocumentoComboBox.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(94, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 143;
            this.label10.Text = "Tipo de Documento";
            // 
            // GeneroComboBox
            // 
            this.GeneroComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GeneroComboBox.FormattingEnabled = true;
            this.GeneroComboBox.Location = new System.Drawing.Point(510, 18);
            this.GeneroComboBox.Name = "GeneroComboBox";
            this.GeneroComboBox.Size = new System.Drawing.Size(125, 21);
            this.GeneroComboBox.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(462, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 144;
            this.label9.Text = "Genero";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FechadateTimePicker1);
            this.groupBox3.Controls.Add(this.GrupoSanguineoComboBox);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(66, 377);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(706, 104);
            this.groupBox3.TabIndex = 154;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Sanitario";
            // 
            // FechadateTimePicker1
            // 
            this.FechadateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechadateTimePicker1.Location = new System.Drawing.Point(455, 44);
            this.FechadateTimePicker1.Name = "FechadateTimePicker1";
            this.FechadateTimePicker1.Size = new System.Drawing.Size(114, 20);
            this.FechadateTimePicker1.TabIndex = 1;
            // 
            // GrupoSanguineoComboBox
            // 
            this.GrupoSanguineoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GrupoSanguineoComboBox.FormattingEnabled = true;
            this.GrupoSanguineoComboBox.Location = new System.Drawing.Point(122, 42);
            this.GrupoSanguineoComboBox.Name = "GrupoSanguineoComboBox";
            this.GrupoSanguineoComboBox.Size = new System.Drawing.Size(203, 21);
            this.GrupoSanguineoComboBox.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(341, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 13);
            this.label12.TabIndex = 127;
            this.label12.Text = "Fecha de Nacimiento";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 13);
            this.label14.TabIndex = 127;
            this.label14.Text = "Grupo Sanguíneo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TelefonoMoviltxt);
            this.groupBox2.Controls.Add(this.CorreoElectronicoTxt);
            this.groupBox2.Controls.Add(this.TelefonoFijoTxt);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(66, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(706, 104);
            this.groupBox2.TabIndex = 155;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contacto";
            // 
            // TelefonoMoviltxt
            // 
            this.TelefonoMoviltxt.Location = new System.Drawing.Point(101, 63);
            this.TelefonoMoviltxt.MaxLength = 20;
            this.TelefonoMoviltxt.Name = "TelefonoMoviltxt";
            this.TelefonoMoviltxt.Size = new System.Drawing.Size(234, 20);
            this.TelefonoMoviltxt.TabIndex = 1;
            // 
            // CorreoElectronicoTxt
            // 
            this.CorreoElectronicoTxt.Location = new System.Drawing.Point(444, 47);
            this.CorreoElectronicoTxt.MaxLength = 150;
            this.CorreoElectronicoTxt.Name = "CorreoElectronicoTxt";
            this.CorreoElectronicoTxt.Size = new System.Drawing.Size(222, 20);
            this.CorreoElectronicoTxt.TabIndex = 2;
            // 
            // TelefonoFijoTxt
            // 
            this.TelefonoFijoTxt.Location = new System.Drawing.Point(101, 29);
            this.TelefonoFijoTxt.MaxLength = 20;
            this.TelefonoFijoTxt.Name = "TelefonoFijoTxt";
            this.TelefonoFijoTxt.Size = new System.Drawing.Size(234, 20);
            this.TelefonoFijoTxt.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 127;
            this.label5.Text = "Correo Electrónico:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 128;
            this.label3.Text = "Teléfono Móvil:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 127;
            this.label4.Text = "Teléfono Fijo:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LocalidadComboBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.provinciasComboBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.direcciontxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(66, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 155);
            this.groupBox1.TabIndex = 153;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Localización";
            // 
            // LocalidadComboBox
            // 
            this.LocalidadComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocalidadComboBox.FormattingEnabled = true;
            this.LocalidadComboBox.Location = new System.Drawing.Point(101, 106);
            this.LocalidadComboBox.Name = "LocalidadComboBox";
            this.LocalidadComboBox.Size = new System.Drawing.Size(259, 21);
            this.LocalidadComboBox.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 128;
            this.label7.Text = "Localidad:";
            // 
            // provinciasComboBox
            // 
            this.provinciasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.provinciasComboBox.FormattingEnabled = true;
            this.provinciasComboBox.Location = new System.Drawing.Point(101, 64);
            this.provinciasComboBox.Name = "provinciasComboBox";
            this.provinciasComboBox.Size = new System.Drawing.Size(259, 21);
            this.provinciasComboBox.TabIndex = 1;
            this.provinciasComboBox.SelectedValueChanged += new System.EventHandler(this.provinciasComboBox_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 126;
            this.label6.Text = "Provincia:";
            // 
            // direcciontxt
            // 
            this.direcciontxt.Location = new System.Drawing.Point(101, 27);
            this.direcciontxt.MaxLength = 100;
            this.direcciontxt.Name = "direcciontxt";
            this.direcciontxt.Size = new System.Drawing.Size(565, 20);
            this.direcciontxt.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 125;
            this.label2.Text = "Dirección:";
            // 
            // Apellidotxt
            // 
            this.Apellidotxt.Location = new System.Drawing.Point(310, 18);
            this.Apellidotxt.MaxLength = 100;
            this.Apellidotxt.Name = "Apellidotxt";
            this.Apellidotxt.Size = new System.Drawing.Size(116, 20);
            this.Apellidotxt.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(264, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 150;
            this.label8.Text = "Apellido";
            // 
            // NroDocumentoTxt
            // 
            this.NroDocumentoTxt.Location = new System.Drawing.Point(397, 79);
            this.NroDocumentoTxt.MaxLength = 10;
            this.NroDocumentoTxt.Name = "NroDocumentoTxt";
            this.NroDocumentoTxt.Size = new System.Drawing.Size(116, 20);
            this.NroDocumentoTxt.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(347, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 151;
            this.label11.Text = "Numero";
            // 
            // NombreTxt
            // 
            this.NombreTxt.Location = new System.Drawing.Point(109, 18);
            this.NombreTxt.MaxLength = 100;
            this.NombreTxt.Name = "NombreTxt";
            this.NombreTxt.Size = new System.Drawing.Size(116, 20);
            this.NombreTxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 152;
            this.label1.Text = "Nombre";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmDonanteAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 593);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.DocumentoComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.GeneroComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Apellidotxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.NroDocumentoTxt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.NombreTxt);
            this.Controls.Add(this.label1);
            this.Name = "FrmDonanteAE";
            this.Text = "FrmDonanteAE";
            this.Load += new System.EventHandler(this.FrmDonanteAE_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox DocumentoComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox GeneroComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker FechadateTimePicker1;
        private System.Windows.Forms.ComboBox GrupoSanguineoComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TelefonoMoviltxt;
        private System.Windows.Forms.TextBox CorreoElectronicoTxt;
        private System.Windows.Forms.TextBox TelefonoFijoTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox LocalidadComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox provinciasComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox direcciontxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Apellidotxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NroDocumentoTxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox NombreTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}