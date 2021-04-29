using BancoSangre.BL.Entidades;
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

namespace BancoSangre.Windows.Pacientes
{
    public partial class FrmPacienteAE : Form
    {
        public FrmPacienteAE()
        {
            InitializeComponent();
        }
        private Paciente pacienteEditDto;
        

        internal Paciente getPaciente()
        {
            return pacienteEditDto;
        }
        bool esedicion = false;
        public void SetPaciente(Paciente pacienteEditDto)
        {
            this.pacienteEditDto = pacienteEditDto;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            Helper.CargarDatosComboDocumento(ref DocumentoComboBox);
            Helper.CargarDatosComboGenero(ref GeneroComboBox);
            Helper.CargarDatosComboProvincias(ref provinciasComboBox);
            LocalidadComboBox.Enabled = false;
            //Helper.CargarDatosComboLocalidades(ref LocalidadComboBox, pacienteEditDto.provincia);
            //Helper.CargarDatosComboInstitucion(ref InstitucionComboBox);
            Helper.CargarDatosComboTipoSangre(ref GrupoSanguineoComboBox);
            if (pacienteEditDto!=null)
            {
                esedicion = true;
            }
            if (esedicion)
            {
                LocalidadComboBox.Enabled = true;

                NombreTxt.Text = pacienteEditDto.NombrePaciente;
                Apellidotxt.Text = pacienteEditDto.ApellidoPaciente;
                //Helper.CargarDatosComboDocumento(ref DocumentoComboBox);
                NroDocumentoTxt.Text = pacienteEditDto.NroDocumento;
                direcciontxt.Text = pacienteEditDto.Direccion;
                TelefonoFijoTxt.Text = pacienteEditDto.TelefonoFijo;
                TelefonoMoviltxt.Text = pacienteEditDto.TelefonoMovil;
                CorreoElectronicoTxt.Text = pacienteEditDto.Email;
                
                provinciasComboBox.SelectedValue = pacienteEditDto.provincia.ProvinciaID;
                Helper.CargarDatosComboLocalidades(ref LocalidadComboBox,Helper.ConvertirProvinciaEnProvinciaListDto(pacienteEditDto.provincia));
                LocalidadComboBox.SelectedValue = pacienteEditDto.localidad.LocalidadID;
                GeneroComboBox.SelectedValue = pacienteEditDto.genero.GeneroID;
                DocumentoComboBox.SelectedValue = pacienteEditDto.documento.TipoDocumentoID;
                GrupoSanguineoComboBox.SelectedValue = pacienteEditDto.tipoSangre.GrupoSanguineoID;
                //InstitucionComboBox.SelectedValue = pacienteEditDto.institucion.InstitucionID;
                FechadateTimePicker1.Value = pacienteEditDto.FechaNac.Date;
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
                if (pacienteEditDto==null)
                {
                    pacienteEditDto = new Paciente();
                }
                pacienteEditDto.NombrePaciente = NombreTxt.Text;
                pacienteEditDto.ApellidoPaciente = Apellidotxt.Text;
                pacienteEditDto.genero = Helper.ConvertirGeneroListDtoEnGenero((GeneroListDto)GeneroComboBox.SelectedItem);
                pacienteEditDto.documento = Helper.ConvertirDocumentoListDtoEnDocumento((DocumentoListDto)DocumentoComboBox.SelectedItem);
                pacienteEditDto.NroDocumento = NroDocumentoTxt.Text;
                pacienteEditDto.Direccion = direcciontxt.Text;
                pacienteEditDto.localidad = Helper.ConvertirLocalidadListDtoEnLocalidad((LocalidadListDto)LocalidadComboBox.SelectedItem);
                pacienteEditDto.provincia = Helper.ConvertirProvinciaListDtoEnProvincia((ProvinciaListDto)provinciasComboBox.SelectedItem);
                pacienteEditDto.TelefonoFijo = TelefonoFijoTxt.Text;
                pacienteEditDto.TelefonoMovil = TelefonoMoviltxt.Text;
                pacienteEditDto.Email = CorreoElectronicoTxt.Text;
                pacienteEditDto.FechaNac = FechadateTimePicker1.Value;
                pacienteEditDto.tipoSangre = Helper.ConvertirTipoSangreListDtoEnTipoSangre((TipoSangreListDto)GrupoSanguineoComboBox.SelectedItem);
                //pacienteEditDto.institucion = Helper.ConvertirInstitucionListDtoEnInstitucion((InstitucionListDto)InstitucionComboBox.SelectedItem);
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
            if (GeneroComboBox.SelectedIndex == 0)
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
            //if (InstitucionComboBox.SelectedIndex == 0)
            //{
            //    valido = false;
            //    errorProvider1.SetError(InstitucionComboBox, "Debe seleccionar una Institucion");
            //}
            return valido;
        }

        private void provinciasComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (provinciasComboBox.SelectedIndex!=0)
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
    }
}
