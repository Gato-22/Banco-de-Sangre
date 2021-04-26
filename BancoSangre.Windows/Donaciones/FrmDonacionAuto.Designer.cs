﻿
namespace BancoSangre.Windows.Donaciones
{
    partial class FrmDonacionAuto
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dgbDatos = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnBorrar = new System.Windows.Forms.ToolStripButton();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripButton();
            this.cmnDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnIntervalo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.btnBorrar,
            this.toolStripSeparator1,
            this.btnBuscar,
            this.btnActualizar,
            this.toolStripSeparator3,
            this.btnCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 86);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 86);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 86);
            // 
            // dgbDatos
            // 
            this.dgbDatos.AllowUserToAddRows = false;
            this.dgbDatos.AllowUserToDeleteRows = false;
            this.dgbDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnDescripcion,
            this.cmnIntervalo});
            this.dgbDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgbDatos.Location = new System.Drawing.Point(0, 86);
            this.dgbDatos.MultiSelect = false;
            this.dgbDatos.Name = "dgbDatos";
            this.dgbDatos.ReadOnly = true;
            this.dgbDatos.RowHeadersVisible = false;
            this.dgbDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgbDatos.Size = new System.Drawing.Size(800, 364);
            this.dgbDatos.TabIndex = 3;
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
            // btnEditar
            // 
            this.btnEditar.Image = global::BancoSangre.Windows.Properties.Resources.pencil_64px;
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(68, 83);
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
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
            // btnBuscar
            // 
            this.btnBuscar.Image = global::BancoSangre.Windows.Properties.Resources.google_web_search_64px;
            this.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(68, 83);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = global::BancoSangre.Windows.Properties.Resources.restart_64px;
            this.btnActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(68, 83);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            // cmnDescripcion
            // 
            this.cmnDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnDescripcion.HeaderText = "Descripción";
            this.cmnDescripcion.Name = "cmnDescripcion";
            this.cmnDescripcion.ReadOnly = true;
            // 
            // cmnIntervalo
            // 
            this.cmnIntervalo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnIntervalo.HeaderText = "Intervalo en Días";
            this.cmnIntervalo.Name = "cmnIntervalo";
            this.cmnIntervalo.ReadOnly = true;
            // 
            // FrmDonacionAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgbDatos);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmDonacionAuto";
            this.Text = "DonacionAutomatizada";
            this.Load += new System.EventHandler(this.FrmDonacionAuto_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnBorrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnCerrar;
        private System.Windows.Forms.DataGridView dgbDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnIntervalo;
    }
}