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

namespace BancoSangre.Windows.Generos
{
    public partial class FrmGenerosAE : Form
    {
        public FrmGenerosAE()
        {
            InitializeComponent();
        }
        private Genero genero;
        public void SetGenero(Genero genero)
        {
            this.genero = genero;
        }

        public Genero GetGenero()
        {
            return genero;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (genero == null)
                {
                    genero = new Genero();
                }

                genero.GeneroDescripcion = txtGenero.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtGenero.Text) || string.IsNullOrWhiteSpace(txtGenero.Text))
            {
                valido = false;
                errorProvider1.SetError(txtGenero, "El Texto del genero es requerido");
            }

            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
