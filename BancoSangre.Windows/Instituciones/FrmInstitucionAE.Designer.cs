
namespace BancoSangre.Windows.Instituciones
{
    partial class FrmInstitucionAE
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
            this.DenominacionTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LocalidadComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.provinciasComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.direcciontxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TelefonoMoviltxt = new System.Windows.Forms.TextBox();
            this.CorreoElectronicoTxt = new System.Windows.Forms.TextBox();
            this.TelefonoFijoTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // DenominacionTxt
            // 
            this.DenominacionTxt.Location = new System.Drawing.Point(223, 41);
            this.DenominacionTxt.MaxLength = 150;
            this.DenominacionTxt.Name = "DenominacionTxt";
            this.DenominacionTxt.Size = new System.Drawing.Size(505, 20);
            this.DenominacionTxt.TabIndex = 132;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 133;
            this.label1.Text = "Denominación de la Entidad Sanitaria:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LocalidadComboBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.provinciasComboBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.direcciontxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(39, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 155);
            this.groupBox1.TabIndex = 134;
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
            this.LocalidadComboBox.TabIndex = 129;
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
            this.provinciasComboBox.TabIndex = 127;
            this.provinciasComboBox.SelectedIndexChanged += new System.EventHandler(this.provinciasComboBox_SelectedIndexChanged);
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
            this.direcciontxt.MaxLength = 150;
            this.direcciontxt.Name = "direcciontxt";
            this.direcciontxt.Size = new System.Drawing.Size(565, 20);
            this.direcciontxt.TabIndex = 124;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TelefonoMoviltxt);
            this.groupBox2.Controls.Add(this.CorreoElectronicoTxt);
            this.groupBox2.Controls.Add(this.TelefonoFijoTxt);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(39, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(706, 104);
            this.groupBox2.TabIndex = 135;
            this.groupBox2.TabStop = false;
            // 
            // TelefonoMoviltxt
            // 
            this.TelefonoMoviltxt.Location = new System.Drawing.Point(101, 63);
            this.TelefonoMoviltxt.Name = "TelefonoMoviltxt";
            this.TelefonoMoviltxt.Size = new System.Drawing.Size(234, 20);
            this.TelefonoMoviltxt.TabIndex = 129;
            // 
            // CorreoElectronicoTxt
            // 
            this.CorreoElectronicoTxt.Location = new System.Drawing.Point(444, 47);
            this.CorreoElectronicoTxt.Name = "CorreoElectronicoTxt";
            this.CorreoElectronicoTxt.Size = new System.Drawing.Size(222, 20);
            this.CorreoElectronicoTxt.TabIndex = 129;
            // 
            // TelefonoFijoTxt
            // 
            this.TelefonoFijoTxt.Location = new System.Drawing.Point(101, 29);
            this.TelefonoFijoTxt.Name = "TelefonoFijoTxt";
            this.TelefonoFijoTxt.Size = new System.Drawing.Size(234, 20);
            this.TelefonoFijoTxt.TabIndex = 129;
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
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(223, 388);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(101, 50);
            this.btnAceptar.TabIndex = 136;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(383, 388);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 50);
            this.btnCancelar.TabIndex = 136;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmInstitucionAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DenominacionTxt);
            this.Controls.Add(this.label1);
            this.Name = "FrmInstitucionAE";
            this.Text = "FrmInstitucionAE";
            this.Load += new System.EventHandler(this.FrmInstitucionAE_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DenominacionTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox LocalidadComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox provinciasComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox direcciontxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TelefonoMoviltxt;
        private System.Windows.Forms.TextBox CorreoElectronicoTxt;
        private System.Windows.Forms.TextBox TelefonoFijoTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}