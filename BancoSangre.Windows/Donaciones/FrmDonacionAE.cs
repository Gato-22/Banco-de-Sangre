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

        internal Donacion GetTipoDonacion()
        {
            return donacion;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (donacion != null)
            {
                txtfechadon.Text = donacion.FechaDonacion.ToString();
                txtident.Text = donacion.Identificacion;
                txtfechaingr.Text = donacion.FechaIngreso.ToString();
                txtvenc.Text = donacion.vencimiento;
                txtcaNT.Text = donacion.Cantidad.ToString();
                
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (donacion == null)
                {
                    donacion = new Donacion();
                }
                //donacion.Intervalo = int.Parse(txtIntervalo.Text);
                donacion.FechaDonacion = DateTime.Parse(txtfechadon.Text);
                donacion.Identificacion = txtident.Text;
                donacion.FechaIngreso = DateTime.Parse(txtfechaingr.Text);
                donacion.vencimiento = txtvenc.Text;
                donacion.Cantidad = int.Parse(txtcaNT.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
