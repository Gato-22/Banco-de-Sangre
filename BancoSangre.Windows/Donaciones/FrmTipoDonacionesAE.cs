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
    public partial class FrmTipoDonacionesAE : Form
    {
        public FrmTipoDonacionesAE()
        {
            InitializeComponent();
        }
        private TipoDonacion TipoDonacion;
        public void SetTipoDonacion(TipoDonacion tipoDonacion)
        {
            this.TipoDonacion=tipoDonacion;
        }

        public TipoDonacion GetTipoDonacion()
        {
            return TipoDonacion;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (TipoDonacion != null)
            {
                txtTipoDonacion.Text = TipoDonacion.Descripcion;
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (TipoDonacion == null)
                {
                    TipoDonacion = new TipoDonacion();
                }

                TipoDonacion.Descripcion = txtTipoDonacion.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTipoDonacion.Text) || string.IsNullOrWhiteSpace(txtTipoDonacion.Text))
            {
                valido = false;
                errorProvider1.SetError(txtTipoDonacion, "La descripcion de la donacion es necesaria");
            }

            return valido;
        }
    }
}
