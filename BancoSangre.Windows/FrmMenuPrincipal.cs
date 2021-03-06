using BancoSangre.Windows.Documentos;

using BancoSangre.Windows.Donaciones;
using BancoSangre.Windows.Instituciones;
using BancoSangre.Windows.Localidades;
using BancoSangre.Windows.Pacientes;
using BancoSangre.Windows.Sangre;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoSangre.Windows
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnCerrarTodo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProvincia_Click(object sender, EventArgs e)
        {
            FrmProvincias frm = new FrmProvincias();
            frm.ShowDialog(this);
        }

        private void btnGeneros_Click(object sender, EventArgs e)
        {
            FrmGeneros frm = new FrmGeneros();
            frm.ShowDialog(this);
        }

        private void btnDocumentos_Click(object sender, EventArgs e)
        {
            FrmDocumentos frm = new FrmDocumentos();
            frm.ShowDialog(this);
        }

        private void btnTipoDonaciones_Click(object sender, EventArgs e)
        {
            FrmTipoDonaciones frm = new FrmTipoDonaciones();
            frm.ShowDialog(this);
        }

        private void btnTipoSangre_Click(object sender, EventArgs e)
        {
            FrmTipoSangre frm = new FrmTipoSangre();
            frm.ShowDialog(this);
        }

        private void btnLocalidades_Click(object sender, EventArgs e)
        {
            FrmLocalidades frm = new FrmLocalidades();
            frm.ShowDialog(this);
        }

        private void btnDonacionAuto_Click(object sender, EventArgs e)
        {
            FrmDonacionAuto frm = new FrmDonacionAuto();
            frm.ShowDialog(this);
            
        }

        private void btnDonacion_Click(object sender, EventArgs e)
        {
            FrmDonacion frm = new FrmDonacion();
            frm.ShowDialog(this);
        }

        private void btnDonantes_Click(object sender, EventArgs e)
        {
            FrmDonante frm = new FrmDonante();
            frm.ShowDialog(this);
        }

        private void btnInstituciones_Click(object sender, EventArgs e)
        {
            FrmInstitucion frm = new FrmInstitucion();
            frm.ShowDialog(this);
        }

        private void btnPaciente_Click(object sender, EventArgs e)
        {
            FrmPaciente frm = new FrmPaciente();
            frm.ShowDialog(this);
        }
    }
}
