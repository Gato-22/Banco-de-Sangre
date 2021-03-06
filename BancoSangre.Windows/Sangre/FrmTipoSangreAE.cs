using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.TiposSangres;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoSangre.Windows.Sangre
{
    public partial class FrmTipoSangreAE : Form
    {
        public FrmTipoSangreAE()
        {
            InitializeComponent();
        }
        private TipoSangreEditDto tipoSangre;
        public void SetTipoSangre(TipoSangreEditDto tipoSangre)
        {
            this.tipoSangre = tipoSangre;
        }


        public TipoSangreEditDto GetTipoSangre()
        {
            return tipoSangre;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoSangre != null)
            {
                txtGrupo.Text = tipoSangre.Grupo;
                txtFactor.Text = tipoSangre.Factor;
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
                if (tipoSangre == null)
                {
                    tipoSangre = new TipoSangreEditDto();
                }

                tipoSangre.Grupo = txtGrupo.Text;
                tipoSangre.Factor = txtFactor.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtGrupo.Text) || string.IsNullOrWhiteSpace(txtGrupo.Text))
            {
                valido = false;
                errorProvider1.SetError(txtGrupo, "El nombre de la Provincia es requerido");
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtFactor.Text) || string.IsNullOrWhiteSpace(txtFactor.Text))
            {
                valido = false;
                errorProvider1.SetError(txtFactor, "El nombre de la Provincia es requerido");
            }

            return valido;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtFactor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGrupo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmTipoSangreAE_Load(object sender, EventArgs e)
        {

        }
    }
}
