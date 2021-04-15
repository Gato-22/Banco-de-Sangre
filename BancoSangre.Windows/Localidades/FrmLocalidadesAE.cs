using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Localidad;
using BancoSangre.BL.Entidades.DTO.Provincia;
using BancoSangre.Servicios.Servicios;
using BancoSangre.Servicios.Servicios.Facades;
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

namespace BancoSangre.Windows.Localidades
{
    public partial class FrmLocalidadesAE : Form
    {
        public FrmLocalidadesAE()
        {
            InitializeComponent();
        }
        private LocalidadEditDto localidad;
        

        protected override void OnLoad(EventArgs e)
        {
            base.OnActivated(e);
            Helper.CargarDatosComboProvincias(ref comboBoxProvincia);
            if (localidad != null)
            {
                txtLocalidad.Text = localidad.NombreLocalidad;
                comboBoxProvincia.SelectedValue = localidad.ProvinciaID.NombreProvincia;
            }
        }

        

        public LocalidadEditDto GetLocalidad()
        {
            return localidad;
        }
        public void SetLocalidad(LocalidadEditDto localidad)
        {
            this.localidad = localidad;
        }
        

        private void FrmLocalidadesAE_Load(object sender, EventArgs e)
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
                if (localidad==null)
                {
                    localidad = new LocalidadEditDto();
                }
                localidad.NombreLocalidad = txtLocalidad.Text;
                localidad.ProvinciaID = (ProvinciaListDto)comboBoxProvincia.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtLocalidad.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtLocalidad, "La Localidad es requerida");
            }

            if (comboBoxProvincia.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(comboBoxProvincia, "Debe seleccionar una Provincia");
            }

            return valido;
        }

    }
}
