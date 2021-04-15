
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
            this.btnProvincia = new System.Windows.Forms.Button();
            this.btnCerrarTodo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGeneros = new System.Windows.Forms.Button();
            this.btnDocumentos = new System.Windows.Forms.Button();
            this.btnTipoDonaciones = new System.Windows.Forms.Button();
            this.btnTipoSangre = new System.Windows.Forms.Button();
            this.btnLocalidades = new System.Windows.Forms.Button();
            this.btnDonacionAuto = new System.Windows.Forms.Button();
            this.btnDonacion = new System.Windows.Forms.Button();
            this.btnDonantes = new System.Windows.Forms.Button();
            this.btnInstituciones = new System.Windows.Forms.Button();
            this.btnPaciente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProvincia
            // 
            this.btnProvincia.Location = new System.Drawing.Point(12, 85);
            this.btnProvincia.Name = "btnProvincia";
            this.btnProvincia.Size = new System.Drawing.Size(96, 62);
            this.btnProvincia.TabIndex = 0;
            this.btnProvincia.Text = "Provincias";
            this.btnProvincia.UseVisualStyleBackColor = true;
            this.btnProvincia.Click += new System.EventHandler(this.btnProvincia_Click);
            // 
            // btnCerrarTodo
            // 
            this.btnCerrarTodo.Location = new System.Drawing.Point(607, 309);
            this.btnCerrarTodo.Name = "btnCerrarTodo";
            this.btnCerrarTodo.Size = new System.Drawing.Size(124, 50);
            this.btnCerrarTodo.TabIndex = 1;
            this.btnCerrarTodo.Text = "Cerrar Todo";
            this.btnCerrarTodo.UseVisualStyleBackColor = true;
            this.btnCerrarTodo.Click += new System.EventHandler(this.btnCerrarTodo_Click);
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
            // btnGeneros
            // 
            this.btnGeneros.Location = new System.Drawing.Point(114, 85);
            this.btnGeneros.Name = "btnGeneros";
            this.btnGeneros.Size = new System.Drawing.Size(96, 62);
            this.btnGeneros.TabIndex = 3;
            this.btnGeneros.Text = "Generos";
            this.btnGeneros.UseVisualStyleBackColor = true;
            this.btnGeneros.Click += new System.EventHandler(this.btnGeneros_Click);
            // 
            // btnDocumentos
            // 
            this.btnDocumentos.Location = new System.Drawing.Point(216, 85);
            this.btnDocumentos.Name = "btnDocumentos";
            this.btnDocumentos.Size = new System.Drawing.Size(96, 62);
            this.btnDocumentos.TabIndex = 3;
            this.btnDocumentos.Text = "Documentos";
            this.btnDocumentos.UseVisualStyleBackColor = true;
            this.btnDocumentos.Click += new System.EventHandler(this.btnDocumentos_Click);
            // 
            // btnTipoDonaciones
            // 
            this.btnTipoDonaciones.Location = new System.Drawing.Point(318, 85);
            this.btnTipoDonaciones.Name = "btnTipoDonaciones";
            this.btnTipoDonaciones.Size = new System.Drawing.Size(124, 62);
            this.btnTipoDonaciones.TabIndex = 3;
            this.btnTipoDonaciones.Text = "Tipos De Donaciones";
            this.btnTipoDonaciones.UseVisualStyleBackColor = true;
            this.btnTipoDonaciones.Click += new System.EventHandler(this.btnTipoDonaciones_Click);
            // 
            // btnTipoSangre
            // 
            this.btnTipoSangre.Location = new System.Drawing.Point(448, 85);
            this.btnTipoSangre.Name = "btnTipoSangre";
            this.btnTipoSangre.Size = new System.Drawing.Size(124, 62);
            this.btnTipoSangre.TabIndex = 3;
            this.btnTipoSangre.Text = "Tipos De Sangres";
            this.btnTipoSangre.UseVisualStyleBackColor = true;
            this.btnTipoSangre.Click += new System.EventHandler(this.btnTipoSangre_Click);
            // 
            // btnLocalidades
            // 
            this.btnLocalidades.Location = new System.Drawing.Point(12, 169);
            this.btnLocalidades.Name = "btnLocalidades";
            this.btnLocalidades.Size = new System.Drawing.Size(96, 62);
            this.btnLocalidades.TabIndex = 0;
            this.btnLocalidades.Text = "Localidades";
            this.btnLocalidades.UseVisualStyleBackColor = true;
            this.btnLocalidades.Click += new System.EventHandler(this.btnLocalidades_Click);
            // 
            // btnDonacionAuto
            // 
            this.btnDonacionAuto.Location = new System.Drawing.Point(318, 169);
            this.btnDonacionAuto.Name = "btnDonacionAuto";
            this.btnDonacionAuto.Size = new System.Drawing.Size(254, 62);
            this.btnDonacionAuto.TabIndex = 0;
            this.btnDonacionAuto.Text = "Tipo De Donaciones Automatizadas";
            this.btnDonacionAuto.UseVisualStyleBackColor = true;
            this.btnDonacionAuto.Click += new System.EventHandler(this.btnDonacionAuto_Click);
            // 
            // btnDonacion
            // 
            this.btnDonacion.Location = new System.Drawing.Point(578, 169);
            this.btnDonacion.Name = "btnDonacion";
            this.btnDonacion.Size = new System.Drawing.Size(96, 62);
            this.btnDonacion.TabIndex = 3;
            this.btnDonacion.Text = "Donaciones";
            this.btnDonacion.UseVisualStyleBackColor = true;
            this.btnDonacion.Click += new System.EventHandler(this.btnDonacion_Click);
            // 
            // btnDonantes
            // 
            this.btnDonantes.Location = new System.Drawing.Point(86, 319);
            this.btnDonantes.Name = "btnDonantes";
            this.btnDonantes.Size = new System.Drawing.Size(124, 62);
            this.btnDonantes.TabIndex = 3;
            this.btnDonantes.Text = "Donantes";
            this.btnDonantes.UseVisualStyleBackColor = true;
            this.btnDonantes.Click += new System.EventHandler(this.btnDonantes_Click);
            // 
            // btnInstituciones
            // 
            this.btnInstituciones.Location = new System.Drawing.Point(239, 259);
            this.btnInstituciones.Name = "btnInstituciones";
            this.btnInstituciones.Size = new System.Drawing.Size(124, 62);
            this.btnInstituciones.TabIndex = 3;
            this.btnInstituciones.Text = "Instituciones";
            this.btnInstituciones.UseVisualStyleBackColor = true;
            this.btnInstituciones.Click += new System.EventHandler(this.btnInstituciones_Click);
            // 
            // btnPaciente
            // 
            this.btnPaciente.Location = new System.Drawing.Point(388, 335);
            this.btnPaciente.Name = "btnPaciente";
            this.btnPaciente.Size = new System.Drawing.Size(124, 62);
            this.btnPaciente.TabIndex = 3;
            this.btnPaciente.Text = "Pacientes";
            this.btnPaciente.UseVisualStyleBackColor = true;
            this.btnPaciente.Click += new System.EventHandler(this.btnPaciente_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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

