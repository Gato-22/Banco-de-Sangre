using BancoSangre.BL.Entidades.DTO.Institucion;
using BancoSangre.BL.Entidades.DTO.Localidad;
using BancoSangre.BL.Entidades.DTO.Provincia;
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

namespace BancoSangre.Windows.Instituciones
{
    public partial class FrmInstitucionAE : Form
    {
        public FrmInstitucionAE()
        {
            InitializeComponent();
        }
        private InstitucionEditdto institucionEditdto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboProvincias(ref provinciasComboBox);
            if (institucionEditdto != null)
            {
                DenominacionTxt.Text = institucionEditdto.Denominacion;
                direcciontxt.Text = institucionEditdto.Direccion;
                TelefonoFijoTxt.Text = institucionEditdto.telefonoFijo;
                TelefonoMoviltxt.Text = institucionEditdto.telefonoMovil;
                CorreoElectronicoTxt.Text = institucionEditdto.correoElectronico;
                provinciasComboBox.SelectedValue = institucionEditdto.provincia.Provinciaid;
                Helper.CargarDatosComboLocalidades(ref LocalidadComboBox, institucionEditdto.provincia);
                LocalidadComboBox.SelectedValue = institucionEditdto.localidad.LocalidadID;
            }
            
        }
        public InstitucionEditdto getInstitucion()
        {
            return institucionEditdto;
        }
        public void setInstitucion(InstitucionEditdto institucionEditdto)
        {
            this.institucionEditdto = institucionEditdto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmInstitucionAE_Load(object sender, EventArgs e)
        {

        }

        private void provinciasComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (provinciasComboBox.SelectedIndex!=0)
            {
                ProvinciaListDto provinciaListDto = (ProvinciaListDto)provinciasComboBox.SelectedItem;
                Helper.CargarDatosComboLocalidades(ref LocalidadComboBox, provinciaListDto);
            }
            else
            {
                LocalidadComboBox.DataSource = null;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (institucionEditdto==null)
                {
                    institucionEditdto = new InstitucionEditdto();
                }
                institucionEditdto.Denominacion = DenominacionTxt.Text;
                institucionEditdto.Direccion = direcciontxt.Text;
                institucionEditdto.provincia = (ProvinciaListDto)provinciasComboBox.SelectedItem;
                institucionEditdto.localidad = (LocalidadListDto)LocalidadComboBox.SelectedItem;
                institucionEditdto.telefonoFijo = TelefonoFijoTxt.Text;
                institucionEditdto.telefonoMovil = TelefonoMoviltxt.Text;
                institucionEditdto.correoElectronico = CorreoElectronicoTxt.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(DenominacionTxt.Text)|| string.IsNullOrWhiteSpace(DenominacionTxt.Text))
            {
                valido = false;
                errorProvider1.SetError(DenominacionTxt, "el nombre de al institucion es requerido");
            }
            if (string.IsNullOrEmpty(direcciontxt.Text) || string.IsNullOrWhiteSpace(direcciontxt.Text))
            {
                valido = false;
                errorProvider1.SetError(direcciontxt, "Direccion de la institucion es requerida");
            }
            if (provinciasComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(provinciasComboBox, "Debe seleccionar una Provincia");

            }
            if (LocalidadComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(LocalidadComboBox, "Debe seleccionar una Localidad");

            }
            return valido;
        }
    }
}
