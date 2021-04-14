using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Localidad;
using BancoSangre.Servicios.Servicios;
using BancoSangre.Servicios.Servicios.Facades;
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
            CargarDatosComboProvincias();
            if (localidad != null)
            {
                txtLocalidad.Text = localidad.NombreLocalidad;
                comboBoxProvincia.SelectedValue = localidad.Provinciaid;
            }
        }

        private void CargarDatosComboProvincias()
        {
            iServiciosProvincia _sericioprovincia = new ServicioProvincias();
            var lista = _sericioprovincia.GetProvincias();
            var defaultprovincia = new Provincia
            {
                ProvinciaID = 0,
                NombreProvincia = "Seleccione una provincia"
            };
            lista.Insert(0, defaultprovincia);
            comboBoxProvincia.DataSource = lista;
            comboBoxProvincia.ValueMember = "ProvinciaId";
            comboBoxProvincia.DisplayMember = "NombreProvincia";
            comboBoxProvincia.SelectedIndex = 0;
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
                localidad.Provinciaid = ((Provincia)comboBoxProvincia.SelectedItem).ProvinciaID;
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
