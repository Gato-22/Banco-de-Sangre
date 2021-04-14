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

namespace BancoSangre.Windows.Donaciones
{
    public partial class FrmDonacionAutoAE : Form
    {
        public FrmDonacionAutoAE()
        {
            InitializeComponent();
        }
        private DonacionAutomatizada donacion;
        public void SetTipoSangre(DonacionAutomatizada donacion)
        {
            this.donacion = donacion;
        }

        internal DonacionAutomatizada GetTipoDonacionAuto()
        {
            return donacion;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (donacion != null)
            {
                txtDescripcion.Text = donacion.Descripcion;              
                donacion.Intervalo= int.Parse(txtIntervalo.Text);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (donacion == null)
                {
                    donacion = new DonacionAutomatizada();
                }

                donacion.Descripcion = txtDescripcion.Text;
                donacion.Intervalo = int.Parse(txtIntervalo.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDescripcion, "Ingrese mejor la descripcion");
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtIntervalo.Text) || string.IsNullOrWhiteSpace(txtIntervalo.Text))
            {
                valido = false;
                errorProvider1.SetError(txtIntervalo, "El numero de dias es requerido");
            }

            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
