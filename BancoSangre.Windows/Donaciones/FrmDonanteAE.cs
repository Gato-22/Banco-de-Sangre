using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO;
using BancoSangre.BL.Entidades.DTO.Documentos;
using BancoSangre.BL.Entidades.DTO.Generos;
using BancoSangre.BL.Entidades.DTO.Institucion;
using BancoSangre.BL.Entidades.DTO.Localidad;
using BancoSangre.BL.Entidades.DTO.Provincia;
using BancoSangre.BL.Entidades.DTO.TiposSangres;
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
    public partial class FrmDonanteAE : Form
    {
        public FrmDonanteAE()
        {
            InitializeComponent();
        }
        private Donante donanteEditDto;

        internal Donante getDonante()
        {
            return donanteEditDto;
        }
        bool esedicion = false;
        public void setDonante(Donante donanteEditDto)
        {
            this.donanteEditDto = donanteEditDto;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboProvincias(ref provinciasComboBox);
            Helper.CargarDatosComboDocumento(ref DocumentoComboBox);
            Helper.CargarDatosComboGenero(ref GeneroComboBox);
            LocalidadComboBox.Enabled = false;
            //Helper.CargarDatosComboLocalidades(ref LocalidadComboBox, pacienteEditDto.provincia);

            Helper.CargarDatosComboTipoSangre(ref GrupoSanguineoComboBox);
            if (donanteEditDto != null)
            {
                esedicion = true;
            }
            if (esedicion)
            {
                LocalidadComboBox.Enabled = true;

                NombreTxt.Text = donanteEditDto.NombreDonante;
                Apellidotxt.Text = donanteEditDto.ApellidoDonante;
                NroDocumentoTxt.Text = donanteEditDto.NroDocumento;
                direcciontxt.Text = donanteEditDto.Direccion;
                TelefonoFijoTxt.Text = donanteEditDto.TelefonoFijo;
                TelefonoMoviltxt.Text = donanteEditDto.TelefonoMovil;
                CorreoElectronicoTxt.Text = donanteEditDto.Email;
                provinciasComboBox.SelectedValue = donanteEditDto.provincia;
                Helper.CargarDatosComboLocalidades(ref LocalidadComboBox,Helper.ConvertirProvinciaEnProvinciaListDto( donanteEditDto.provincia));
                LocalidadComboBox.SelectedValue = donanteEditDto.localidad.LocalidadID;
                GeneroComboBox.SelectedValue = donanteEditDto.genero.GeneroID;
                DocumentoComboBox.SelectedValue = donanteEditDto.documento.TipoDocumentoID;
                GrupoSanguineoComboBox.SelectedValue = donanteEditDto.tipoSangre.GrupoSanguineoID;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (donanteEditDto == null)
                {
                    donanteEditDto = new Donante();
                }
                donanteEditDto.NombreDonante = NombreTxt.Text;
                donanteEditDto.ApellidoDonante = Apellidotxt.Text;
                donanteEditDto.genero = Helper.ConvertirGeneroListDtoEnGenero((GeneroListDto)GeneroComboBox.SelectedItem);
                donanteEditDto.documento = Helper.ConvertirDocumentoListDtoEnDocumento((DocumentoListDto)DocumentoComboBox.SelectedItem);
                donanteEditDto.NroDocumento = NroDocumentoTxt.Text;
                donanteEditDto.Direccion = direcciontxt.Text;
                donanteEditDto.localidad = Helper.ConvertirLocalidadListDtoEnLocalidad((LocalidadListDto)LocalidadComboBox.SelectedItem);
                donanteEditDto.provincia = Helper.ConvertirProvinciaListDtoEnProvincia((ProvinciaListDto)provinciasComboBox.SelectedItem);
                donanteEditDto.TelefonoFijo = TelefonoFijoTxt.Text;
                donanteEditDto.TelefonoMovil = TelefonoMoviltxt.Text;
                donanteEditDto.Email = CorreoElectronicoTxt.Text;
                donanteEditDto.FechaNac = FechadateTimePicker1.Value;
                donanteEditDto.tipoSangre = Helper.ConvertirTipoSangreListDtoEnTipoSangre((TipoSangreListDto)GrupoSanguineoComboBox.SelectedItem);               
                DialogResult = DialogResult.OK;
            }
        }

        private bool validarDatos()
        {
            
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(NombreTxt.Text) || string.IsNullOrWhiteSpace(NombreTxt.Text))
            {
                valido = false;
                errorProvider1.SetError(NombreTxt, "el nombre de la Persona es requerido");
            }
            if (string.IsNullOrEmpty(Apellidotxt.Text) || string.IsNullOrWhiteSpace(Apellidotxt.Text))
            {
                valido = false;
                errorProvider1.SetError(Apellidotxt, "el apellido de la Persona es requerido");
            }
            if (GeneroComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(GeneroComboBox, "Debe seleccionar un Genero");
            }
            if (DocumentoComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(DocumentoComboBox, "Debe seleccionar un tipo de Documento");
            }
            if (string.IsNullOrEmpty(NroDocumentoTxt.Text) || string.IsNullOrWhiteSpace(NroDocumentoTxt.Text))
            {
                valido = false;
                errorProvider1.SetError(NroDocumentoTxt, "el Numero  es requerido");
            }
            if (string.IsNullOrEmpty(direcciontxt.Text) || string.IsNullOrWhiteSpace(direcciontxt.Text))
            {
                valido = false;
                errorProvider1.SetError(direcciontxt, "La Direccion es requerida");
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
            if (GrupoSanguineoComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(GrupoSanguineoComboBox, "Debe seleccionar un Grupo Sanguineo");
            }
            //DateTime Edad = FechadateTimePicker1.Value.Date;
            int EDADD = DateTime.Now.Year-FechadateTimePicker1.Value.Year;
            if (EDADD<18)
            {

                valido = false;
                errorProvider1.SetError(FechadateTimePicker1, "La persona debe ser Mayor de 18 años para donar");
            }
            return valido;
            
        }

        private void provinciasComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (provinciasComboBox.SelectedIndex != 0)
            {
                var provincia = (ProvinciaListDto)provinciasComboBox.SelectedItem;
                Helper.CargarDatosComboLocalidades(ref LocalidadComboBox, provincia);
                LocalidadComboBox.Enabled = true;

            }
            else
            {
                LocalidadComboBox.Enabled = false;
            }
        }

        private void FrmDonanteAE_Load(object sender, EventArgs e)
        {

        }
    }
}
