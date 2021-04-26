using BancoSangre.BL.Entidades;
using BancoSangre.Windows.Ahelper;
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
        bool esedicion = false;
        internal Donacion GetTipoDonacion()
        {
            return donacion;
        }
        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);
            Helper.CargarDatosComboDonantes(ref DonanteComboBox);
            Helper.CargarDatosComboPaciente(ref PacienteComboBox);
            Helper.CargarDatosComboTipoDonacion(ref TipoDonacionComboBox);
            TipoDonacionAutomatizadaComboBox.Enabled = false;

            //Helper.CargarDatosComboTipoDonacionAutomatizada(ref TipoDonacionAutomatizadaComboBox);
            if (donacion != null)
            {
                esedicion = true;
            }
            if (esedicion)
            {
                FechaDonaciondateTimePicker1.Text = donacion.FechaDonacion.ToString();
                txtident.Text = donacion.Identificacion;
                DonanteComboBox.SelectedValue = donacion.Donante.DonanteID;
                PacienteComboBox.SelectedValue = donacion.Paciente.PacienteID;
                TipoDonacionComboBox.SelectedValue = donacion.TipoDonacion.TipoDonacionID;
                if (donacion.TipoDonacion.TipoDonacionID==2)
                {
                    Helper.CargarDatosComboTipoDonacionAutomatizada(ref TipoDonacionAutomatizadaComboBox);
                    TipoDonacionAutomatizadaComboBox.Enabled = true;
                    TipoDonacionAutomatizadaComboBox.SelectedValue = donacion.DonacionesDonacionesAutomatizadas.donacionAutomatizada.DonacionAutoID;

                }
                //LocalidadComboBox.SelectedValue = donanteEditDto.localidad.LocalidadID;
                FechaIngresodateTimePicker2.Text = donacion.FechaIngreso.ToString();
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
                donacion.FechaDonacion = DateTime.Parse(FechaDonaciondateTimePicker1.Text);
                donacion.Identificacion = txtident.Text;
                donacion.FechaIngreso = DateTime.Parse(FechaIngresodateTimePicker2.Text);
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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void TipoDonacionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (TipoDonacionComboBox.SelectedIndex==1)
            {
                TipoDonacionAutomatizadaComboBox.Enabled = true;
                Helper.CargarDatosComboTipoDonacionAutomatizada(ref TipoDonacionAutomatizadaComboBox);

            }
            else
            {
                TipoDonacionAutomatizadaComboBox.Enabled = false;
            }
        }
    }
}
