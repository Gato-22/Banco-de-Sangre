using BancoSangre.BL.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoSangre.Windows.Documentos
{
    public partial class FrmDocumentosAE : Form
    {
        public FrmDocumentosAE()
        {
            InitializeComponent();
        }
        private Documento documento;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (documento != null)
            {
                txtDocumento.Text = documento.Descripcion;
            }
        }

        private void FrmDocumentosAE_Load(object sender, EventArgs e)
        {
            
        }

        public Documento GetDocumento()
        {
            return documento;
        }             
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (documento == null)
                {
                   documento = new Documento();
                }

                documento.Descripcion = txtDocumento.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtDocumento.Text) || string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDocumento, "El Tipo de documento es requerido");
            }

            return valido;
        }

        public void SetDocumento(Documento documento)
        {
            this.documento = documento;
        }

    }
}
