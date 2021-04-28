
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtcaNT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DonanteComboBox = new System.Windows.Forms.ComboBox();
            this.PacienteComboBox = new System.Windows.Forms.ComboBox();
            this.TipoDonacionComboBox = new System.Windows.Forms.ComboBox();
            this.TipoDonacionAutomatizadaComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.GrupoSanguineotxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CantidadDonantestxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            // txtcaNT
            // 
            this.txtcaNT.Location = new System.Drawing.Point(222, 255);
            this.txtcaNT.MaxLength = 1000;
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
            // DonanteComboBox
            // 
            this.DonanteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DonanteComboBox.FormattingEnabled = true;
            this.DonanteComboBox.Location = new System.Drawing.Point(222, 150);
            this.DonanteComboBox.Name = "DonanteComboBox";
            this.DonanteComboBox.Size = new System.Drawing.Size(177, 21);
            this.DonanteComboBox.TabIndex = 1;
            // 
            // PacienteComboBox
            // 
            this.PacienteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PacienteComboBox.FormattingEnabled = true;
            this.PacienteComboBox.Location = new System.Drawing.Point(222, 73);
            this.PacienteComboBox.Name = "PacienteComboBox";
            this.PacienteComboBox.Size = new System.Drawing.Size(177, 21);
            this.PacienteComboBox.TabIndex = 2;
            this.PacienteComboBox.SelectedIndexChanged += new System.EventHandler(this.PacienteComboBox_SelectedIndexChanged);
            this.PacienteComboBox.SelectedValueChanged += new System.EventHandler(this.PacienteComboBox_SelectedValueChanged);
            // 
            // TipoDonacionComboBox
            // 
            this.TipoDonacionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoDonacionComboBox.FormattingEnabled = true;
            this.TipoDonacionComboBox.Location = new System.Drawing.Point(222, 177);
            this.TipoDonacionComboBox.Name = "TipoDonacionComboBox";
            this.TipoDonacionComboBox.Size = new System.Drawing.Size(177, 21);
            this.TipoDonacionComboBox.TabIndex = 3;
            this.TipoDonacionComboBox.SelectedValueChanged += new System.EventHandler(this.TipoDonacionComboBox_SelectedValueChanged);
            // 
            // TipoDonacionAutomatizadaComboBox
            // 
            this.TipoDonacionAutomatizadaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoDonacionAutomatizadaComboBox.FormattingEnabled = true;
            this.TipoDonacionAutomatizadaComboBox.Location = new System.Drawing.Point(222, 204);
            this.TipoDonacionAutomatizadaComboBox.Name = "TipoDonacionAutomatizadaComboBox";
            this.TipoDonacionAutomatizadaComboBox.Size = new System.Drawing.Size(177, 21);
            this.TipoDonacionAutomatizadaComboBox.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(167, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Donante";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(167, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Paciente";
            this.label12.Click += new System.EventHandler(this.label11_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(122, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Tipo De Donacion";
            this.label13.Click += new System.EventHandler(this.label11_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(55, 207);
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
            // GrupoSanguineotxt
            // 
            this.GrupoSanguineotxt.Enabled = false;
            this.GrupoSanguineotxt.Location = new System.Drawing.Point(222, 96);
            this.GrupoSanguineotxt.Name = "GrupoSanguineotxt";
            this.GrupoSanguineotxt.Size = new System.Drawing.Size(28, 20);
            this.GrupoSanguineotxt.TabIndex = 6;
            this.GrupoSanguineotxt.TextChanged += new System.EventHandler(this.GrupoSanguineotxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Grupo Sanguíneo";
            this.label3.Click += new System.EventHandler(this.label11_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Cantidad de Donantes";
            // 
            // CantidadDonantestxt
            // 
            this.CantidadDonantestxt.Enabled = false;
            this.CantidadDonantestxt.Location = new System.Drawing.Point(222, 124);
            this.CantidadDonantestxt.Name = "CantidadDonantestxt";
            this.CantidadDonantestxt.Size = new System.Drawing.Size(42, 20);
            this.CantidadDonantestxt.TabIndex = 26;
            this.CantidadDonantestxt.TextChanged += new System.EventHandler(this.CantidadDonantestxt_TextChanged);
            // 
            // FrmDonacionAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 375);
            this.ControlBox = false;
            this.Controls.Add(this.CantidadDonantestxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TipoDonacionAutomatizadaComboBox);
            this.Controls.Add(this.TipoDonacionComboBox);
            this.Controls.Add(this.PacienteComboBox);
            this.Controls.Add(this.DonanteComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.GrupoSanguineotxt);
            this.Controls.Add(this.txtcaNT);
            this.Name = "FrmDonacionAE";
            this.Text = "FrmDonacionAE";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtcaNT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox DonanteComboBox;
        private System.Windows.Forms.ComboBox PacienteComboBox;
        private System.Windows.Forms.ComboBox TipoDonacionComboBox;
        private System.Windows.Forms.ComboBox TipoDonacionAutomatizadaComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox GrupoSanguineotxt;
        private System.Windows.Forms.TextBox CantidadDonantestxt;
        private System.Windows.Forms.Label label2;
    }
}