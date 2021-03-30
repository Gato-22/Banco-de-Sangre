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

namespace BancoSangre.Windows.Provincias
{
    public partial class FrmProvinciasAE : Form
    {
        public FrmProvinciasAE()
        {
            InitializeComponent();
        }
        private Provincia provincia;
        public void SetProvincia(Provincia provincia)
        {
            this.provincia = provincia;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (provincia != null)
            {
                txtProvincias.Text = provincia.NombreProvincia;
            }
        }

        public Provincia GetProvincia()
        {
            return provincia;
        }

        private void FrmProvinciasAE_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (provincia == null)
                {
                    provincia = new Provincia();
                }

                provincia.NombreProvincia = txtProvincias.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtProvincias.Text) || string.IsNullOrWhiteSpace(txtProvincias.Text))
            {
                valido = false;
                errorProvider1.SetError(txtProvincias, "El nombre de la Provincia es requerido");
            }

            return valido;
        }
    }
}
