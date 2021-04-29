
namespace BancoSangre.Windows.Donaciones
{
    partial class FrmDonacion
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCerrar = new System.Windows.Forms.ToolStripButton();
            this.dgbDatos = new System.Windows.Forms.DataGridView();
            this.cmnFechaDonacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnInstitucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnDonante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnTipoDonacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCanti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnBorrar,
            this.toolStripSeparator1,
            this.btnCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(896, 86);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::BancoSangre.Windows.Properties.Resources.new_copy_64px;
            this.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(68, 83);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Image = global::BancoSangre.Windows.Properties.Resources.delete_64px;
            this.btnBorrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(68, 83);
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 86);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::BancoSangre.Windows.Properties.Resources.close_pane_64px;
            this.btnCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(68, 83);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgbDatos
            // 
            this.dgbDatos.AllowUserToAddRows = false;
            this.dgbDatos.AllowUserToDeleteRows = false;
            this.dgbDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnFechaDonacion,
            this.cmnInstitucion,
            this.cmnDonante,
            this.cmnPaciente,
            this.cmnTipoDonacion,
            this.cmnCanti});
            this.dgbDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgbDatos.Location = new System.Drawing.Point(0, 86);
            this.dgbDatos.MultiSelect = false;
            this.dgbDatos.Name = "dgbDatos";
            this.dgbDatos.ReadOnly = true;
            this.dgbDatos.RowHeadersVisible = false;
            this.dgbDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgbDatos.Size = new System.Drawing.Size(896, 364);
            this.dgbDatos.TabIndex = 4;
            this.dgbDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgbDatos_CellContentClick);
            // 
            // cmnFechaDonacion
            // 
            this.cmnFechaDonacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnFechaDonacion.HeaderText = "Fecha de Donacion";
            this.cmnFechaDonacion.Name = "cmnFechaDonacion";
            this.cmnFechaDonacion.ReadOnly = true;
            // 
            // cmnInstitucion
            // 
            this.cmnInstitucion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnInstitucion.HeaderText = "Institucion";
            this.cmnInstitucion.Name = "cmnInstitucion";
            this.cmnInstitucion.ReadOnly = true;
            // 
            // cmnDonante
            // 
            this.cmnDonante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnDonante.HeaderText = "Donante";
            this.cmnDonante.Name = "cmnDonante";
            this.cmnDonante.ReadOnly = true;
            // 
            // cmnPaciente
            // 
            this.cmnPaciente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnPaciente.HeaderText = "Paciente";
            this.cmnPaciente.Name = "cmnPaciente";
            this.cmnPaciente.ReadOnly = true;
            // 
            // cmnTipoDonacion
            // 
            this.cmnTipoDonacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnTipoDonacion.HeaderText = "Tipo De Donacion";
            this.cmnTipoDonacion.Name = "cmnTipoDonacion";
            this.cmnTipoDonacion.ReadOnly = true;
            // 
            // cmnCanti
            // 
            this.cmnCanti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnCanti.HeaderText = "Cantidad Litros";
            this.cmnCanti.Name = "cmnCanti";
            this.cmnCanti.ReadOnly = true;
            // 
            // FrmDonacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 450);
            this.ControlBox = false;
            this.Controls.Add(this.dgbDatos);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmDonacion";
            this.Text = "FrmDonacion";
            this.Load += new System.EventHandler(this.FrmDonacion_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnBorrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCerrar;
        private System.Windows.Forms.DataGridView dgbDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnFechaDonacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnInstitucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnDonante;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnTipoDonacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCanti;
    }
}