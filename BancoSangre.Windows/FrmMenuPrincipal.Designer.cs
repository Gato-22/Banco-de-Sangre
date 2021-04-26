
namespace BancoSangre.Windows
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPrincipal));
            this.label1 = new System.Windows.Forms.Label();
            this.btnTipoSangre = new System.Windows.Forms.Button();
            this.btnPaciente = new System.Windows.Forms.Button();
            this.btnDonantes = new System.Windows.Forms.Button();
            this.btnInstituciones = new System.Windows.Forms.Button();
            this.btnTipoDonaciones = new System.Windows.Forms.Button();
            this.btnDonacion = new System.Windows.Forms.Button();
            this.btnDocumentos = new System.Windows.Forms.Button();
            this.btnGeneros = new System.Windows.Forms.Button();
            this.btnCerrarTodo = new System.Windows.Forms.Button();
            this.btnDonacionAuto = new System.Windows.Forms.Button();
            this.btnLocalidades = new System.Windows.Forms.Button();
            this.btnProvincia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Banco de Sangre";
            // 
            // btnTipoSangre
            // 
            this.btnTipoSangre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTipoSangre.Image = ((System.Drawing.Image)(resources.GetObject("btnTipoSangre.Image")));
            this.btnTipoSangre.Location = new System.Drawing.Point(691, 12);
            this.btnTipoSangre.Name = "btnTipoSangre";
            this.btnTipoSangre.Size = new System.Drawing.Size(124, 81);
            this.btnTipoSangre.TabIndex = 6;
            this.btnTipoSangre.Text = "Tipos De Sangres";
            this.btnTipoSangre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTipoSangre.UseVisualStyleBackColor = true;
            this.btnTipoSangre.Click += new System.EventHandler(this.btnTipoSangre_Click);
            // 
            // btnPaciente
            // 
            this.btnPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPaciente.Image = global::BancoSangre.Windows.Properties.Resources.protection_mask_64px;
            this.btnPaciente.Location = new System.Drawing.Point(193, 249);
            this.btnPaciente.Name = "btnPaciente";
            this.btnPaciente.Size = new System.Drawing.Size(124, 78);
            this.btnPaciente.TabIndex = 9;
            this.btnPaciente.Text = "Pacientes";
            this.btnPaciente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPaciente.UseVisualStyleBackColor = true;
            this.btnPaciente.Click += new System.EventHandler(this.btnPaciente_Click);
            // 
            // btnDonantes
            // 
            this.btnDonantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDonantes.Image = global::BancoSangre.Windows.Properties.Resources.health_64px;
            this.btnDonantes.Location = new System.Drawing.Point(397, 249);
            this.btnDonantes.Name = "btnDonantes";
            this.btnDonantes.Size = new System.Drawing.Size(124, 78);
            this.btnDonantes.TabIndex = 10;
            this.btnDonantes.Text = "Donantes";
            this.btnDonantes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDonantes.UseVisualStyleBackColor = true;
            this.btnDonantes.Click += new System.EventHandler(this.btnDonantes_Click);
            // 
            // btnInstituciones
            // 
            this.btnInstituciones.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInstituciones.Image = ((System.Drawing.Image)(resources.GetObject("btnInstituciones.Image")));
            this.btnInstituciones.Location = new System.Drawing.Point(254, 66);
            this.btnInstituciones.Name = "btnInstituciones";
            this.btnInstituciones.Size = new System.Drawing.Size(134, 81);
            this.btnInstituciones.TabIndex = 8;
            this.btnInstituciones.Text = "Instituciones";
            this.btnInstituciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnInstituciones.UseVisualStyleBackColor = true;
            this.btnInstituciones.Click += new System.EventHandler(this.btnInstituciones_Click);
            // 
            // btnTipoDonaciones
            // 
            this.btnTipoDonaciones.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTipoDonaciones.Image = ((System.Drawing.Image)(resources.GetObject("btnTipoDonaciones.Image")));
            this.btnTipoDonaciones.Location = new System.Drawing.Point(561, 12);
            this.btnTipoDonaciones.Name = "btnTipoDonaciones";
            this.btnTipoDonaciones.Size = new System.Drawing.Size(124, 81);
            this.btnTipoDonaciones.TabIndex = 5;
            this.btnTipoDonaciones.Text = "Tipos De Donaciones";
            this.btnTipoDonaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTipoDonaciones.UseVisualStyleBackColor = true;
            this.btnTipoDonaciones.Click += new System.EventHandler(this.btnTipoDonaciones_Click);
            // 
            // btnDonacion
            // 
            this.btnDonacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDonacion.Image = ((System.Drawing.Image)(resources.GetObject("btnDonacion.Image")));
            this.btnDonacion.Location = new System.Drawing.Point(641, 249);
            this.btnDonacion.Name = "btnDonacion";
            this.btnDonacion.Size = new System.Drawing.Size(96, 78);
            this.btnDonacion.TabIndex = 11;
            this.btnDonacion.Text = "Donaciones";
            this.btnDonacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDonacion.UseVisualStyleBackColor = true;
            this.btnDonacion.Click += new System.EventHandler(this.btnDonacion_Click);
            // 
            // btnDocumentos
            // 
            this.btnDocumentos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDocumentos.Image = ((System.Drawing.Image)(resources.GetObject("btnDocumentos.Image")));
            this.btnDocumentos.Location = new System.Drawing.Point(12, 369);
            this.btnDocumentos.Name = "btnDocumentos";
            this.btnDocumentos.Size = new System.Drawing.Size(96, 81);
            this.btnDocumentos.TabIndex = 4;
            this.btnDocumentos.Text = "Documentos";
            this.btnDocumentos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDocumentos.UseVisualStyleBackColor = true;
            this.btnDocumentos.Click += new System.EventHandler(this.btnDocumentos_Click);
            // 
            // btnGeneros
            // 
            this.btnGeneros.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGeneros.Image = ((System.Drawing.Image)(resources.GetObject("btnGeneros.Image")));
            this.btnGeneros.Location = new System.Drawing.Point(12, 259);
            this.btnGeneros.Name = "btnGeneros";
            this.btnGeneros.Size = new System.Drawing.Size(96, 81);
            this.btnGeneros.TabIndex = 3;
            this.btnGeneros.Text = "Géneros";
            this.btnGeneros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGeneros.UseVisualStyleBackColor = true;
            this.btnGeneros.Click += new System.EventHandler(this.btnGeneros_Click);
            // 
            // btnCerrarTodo
            // 
            this.btnCerrarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrarTodo.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarTodo.Image")));
            this.btnCerrarTodo.Location = new System.Drawing.Point(691, 390);
            this.btnCerrarTodo.Name = "btnCerrarTodo";
            this.btnCerrarTodo.Size = new System.Drawing.Size(124, 89);
            this.btnCerrarTodo.TabIndex = 0;
            this.btnCerrarTodo.Text = "Cerrar Todo";
            this.btnCerrarTodo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCerrarTodo.UseVisualStyleBackColor = true;
            this.btnCerrarTodo.Click += new System.EventHandler(this.btnCerrarTodo_Click);
            // 
            // btnDonacionAuto
            // 
            this.btnDonacionAuto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDonacionAuto.Image = global::BancoSangre.Windows.Properties.Resources.automatic_64px;
            this.btnDonacionAuto.Location = new System.Drawing.Point(561, 120);
            this.btnDonacionAuto.Name = "btnDonacionAuto";
            this.btnDonacionAuto.Size = new System.Drawing.Size(254, 78);
            this.btnDonacionAuto.TabIndex = 7;
            this.btnDonacionAuto.Text = "Tipo De Donaciones Automatizadas";
            this.btnDonacionAuto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDonacionAuto.UseVisualStyleBackColor = true;
            this.btnDonacionAuto.Click += new System.EventHandler(this.btnDonacionAuto_Click);
            // 
            // btnLocalidades
            // 
            this.btnLocalidades.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLocalidades.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalidades.Image")));
            this.btnLocalidades.Location = new System.Drawing.Point(12, 169);
            this.btnLocalidades.Name = "btnLocalidades";
            this.btnLocalidades.Size = new System.Drawing.Size(96, 78);
            this.btnLocalidades.TabIndex = 2;
            this.btnLocalidades.Text = "Localidades";
            this.btnLocalidades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLocalidades.UseVisualStyleBackColor = true;
            this.btnLocalidades.Click += new System.EventHandler(this.btnLocalidades_Click);
            // 
            // btnProvincia
            // 
            this.btnProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProvincia.Image = ((System.Drawing.Image)(resources.GetObject("btnProvincia.Image")));
            this.btnProvincia.Location = new System.Drawing.Point(12, 66);
            this.btnProvincia.Name = "btnProvincia";
            this.btnProvincia.Size = new System.Drawing.Size(96, 81);
            this.btnProvincia.TabIndex = 1;
            this.btnProvincia.Text = "Provincias";
            this.btnProvincia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProvincia.UseVisualStyleBackColor = true;
            this.btnProvincia.Click += new System.EventHandler(this.btnProvincia_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 491);
            this.Controls.Add(this.btnTipoSangre);
            this.Controls.Add(this.btnPaciente);
            this.Controls.Add(this.btnDonantes);
            this.Controls.Add(this.btnInstituciones);
            this.Controls.Add(this.btnTipoDonaciones);
            this.Controls.Add(this.btnDonacion);
            this.Controls.Add(this.btnDocumentos);
            this.Controls.Add(this.btnGeneros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCerrarTodo);
            this.Controls.Add(this.btnDonacionAuto);
            this.Controls.Add(this.btnLocalidades);
            this.Controls.Add(this.btnProvincia);
            this.Name = "FrmMenuPrincipal";
            this.Text = "Menu Principal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProvincia;
        private System.Windows.Forms.Button btnCerrarTodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGeneros;
        private System.Windows.Forms.Button btnDocumentos;
        private System.Windows.Forms.Button btnTipoDonaciones;
        private System.Windows.Forms.Button btnTipoSangre;
        private System.Windows.Forms.Button btnLocalidades;
        private System.Windows.Forms.Button btnDonacionAuto;
        private System.Windows.Forms.Button btnDonacion;
        private System.Windows.Forms.Button btnDonantes;
        private System.Windows.Forms.Button btnInstituciones;
        private System.Windows.Forms.Button btnPaciente;
    }
}

