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
    public partial class FrmDonacionAE : Form
    {
        public FrmDonacionAE()
        {
            InitializeComponent();
        }
        private Donacion donacion;
        public void SetDonacion(Donacion donacion)
        {
            this.donacion = donacion;
        }

        internal Donacion GetTipoDonacionAuto()
        {
            return donacion;
        }
        protected override void OnLoad(EventArgs e)
        {
            //base.OnLoad(e);
            //if (donacion != null)
            //{
            //    txtfechadon.Text = donacion.FechaDonacion;
            //    donacion.Intervalo = int.Parse(txtident.Text);
            //}
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //if (ValidarDatos())
            //{
            //    if (donacion == null)
            //    {
            //        donacion = new Donacion();
            //    }

            //    donacion.Descripcion = txtDescripcion.Text;
            //    donacion.Intervalo = int.Parse(txtIntervalo.Text);
            //    DialogResult = DialogResult.OK;
            //}
        }

        private bool ValidarDatos()
        {
            throw new NotImplementedException();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
