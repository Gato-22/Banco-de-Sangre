using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO;
using BancoSangre.BL.Entidades.DTO.Documentos;
using BancoSangre.BL.Entidades.DTO.Generos;
using BancoSangre.BL.Entidades.DTO.Institucion;
using BancoSangre.BL.Entidades.DTO.Localidad;

using BancoSangre.BL.Entidades.DTO.Provincia;
using BancoSangre.BL.Entidades.DTO.TiposSangres;
using BancoSangre.Servicios.Servicios;
using BancoSangre.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoSangre.Windows.Ahelper
{
    public class Helper
    {
        public static void CargarDatosComboProvincias(ref ComboBox combo)
        {
            iServiciosProvincia _sericioprovincia = new ServicioProvincias();
            var lista = _sericioprovincia.GetProvincias();
            var defaultprovincia = new ProvinciaListDto
            {
                Provinciaid = 0,
                NombreProvincia = "Seleccione una provincia"
            };
            lista.Insert(0, defaultprovincia);
            combo.DataSource = lista;
            combo.ValueMember = "ProvinciaId";
            combo.DisplayMember = "NombreProvincia";
            combo.SelectedIndex = 0;
        }
        internal static void CargarDatosComboLocalidades(ref ComboBox combo, ProvinciaListDto provinciaListDto)
        {
            IServicioLocalidad serviciosLocalidad = new ServicioLocalidad();
            var lista = serviciosLocalidad.GetLista(provinciaListDto);
            var defaultLocalidad = new LocalidadListDto
            {
                LocalidadID = 0,
                NombreLocalidad = "Seleccione Localidad"
            };
            lista.Insert(0, defaultLocalidad);
            combo.DataSource = lista;
            combo.ValueMember = "LocalidadId";
            combo.DisplayMember = "NombreLocalidad";
            combo.SelectedIndex = 0;

        }
        public static void CargarDatosComboGenero(ref ComboBox combo)
        {
            IServicioGenero servicioGenero = new ServicioGeneros();
            var lista = servicioGenero.GetGeneros();
            var defaultGenero = new GeneroListDto { GeneroID = 0, GeneroDescripcion = "Seleccione genero" };
            lista.Insert(0, defaultGenero);
            combo.DataSource = lista;
            combo.ValueMember = "GeneroId";
            combo.DisplayMember = "GeneroDescripcion";
            combo.SelectedIndex = 0;
        }

        internal static ProvinciaListDto ConvertirProvinciaEnProvinciaListDto(Provincia provincia)
        {
            return new ProvinciaListDto
            {
                NombreProvincia=provincia.NombreProvincia,
                Provinciaid=provincia.ProvinciaID
            };
        }

        public static void CargarDatosComboDocumento(ref ComboBox combo)
        {
            IServicioDocumento servicioDocumento = new ServicioDocumentos();
            var lista = servicioDocumento.GetDocumentos();
            var defaultt = new DocumentoListDto { TipoDocumentoID=0, Descripcion="seleccione Documento" };
            lista.Insert(0, defaultt);
            combo.DataSource = lista;
            combo.ValueMember = "TipoDocumentoID";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;
        }
        public static void CargarDatosComboTipoSangre(ref ComboBox combo)
        {
            IServicioTipoSangre servicioTipoSangre = new ServicioTipoSangre();
            var lista = servicioTipoSangre.GetTipoSangres();
            var defaultt = new TipoSangreListDto { GrupoSanguineoID = 0, Grupo = "Seleccione Grupo" };
            lista.Insert(0, defaultt);
            combo.DataSource = lista;
            combo.ValueMember = "GrupoSanguineoID";
            combo.DisplayMember = "Grupo";

            combo.SelectedIndex = 0;
        }

        internal static Provincia ConvertirProvinciaListDtoEnProvincia(ProvinciaListDto selectedItem)
        {
            return new Provincia
            {
                NombreProvincia = selectedItem.NombreProvincia,
                ProvinciaID = selectedItem.Provinciaid
            };
            throw new NotImplementedException();
        }

        internal static Localidad ConvertirLocalidadListDtoEnLocalidad(LocalidadListDto selectedItem)
        {
            return new Localidad
            {
                LocalidadID = selectedItem.LocalidadID,
                NombreLocalidad = selectedItem.NombreLocalidad,
                //provincia = selectedItem.NombreProvincia
            };
        }

        internal static Documento ConvertirDocumentoListDtoEnDocumento(DocumentoListDto selectedItem)
        {
            return new Documento
            {
                Descripcion = selectedItem.Descripcion,
                TipoDocumentoID = selectedItem.TipoDocumentoID
            };
        }

        internal static Institucion ConvertirInstitucionListDtoEnInstitucion(InstitucionListDto selectedItem)
        {
            return new Institucion
            {
                Denominacion=selectedItem.Denominacion,
                Direccion=selectedItem.Direccion,
                //localidad=selectedItem.localidad
            };
        }

        internal static TipoSangre ConvertirTipoSangreListDtoEnTipoSangre(TipoSangreListDto selectedItem)
        {
            return new TipoSangre
            {
                Factor = selectedItem.Factor,
                Grupo = selectedItem.Grupo,
                GrupoSanguineoID = selectedItem.GrupoSanguineoID
            };
        }

        internal static Genero ConvertirGeneroListDtoEnGenero(GeneroListDto selectedItem)
        {
            return new Genero
            {
                GeneroDescripcion = selectedItem.GeneroDescripcion,
                GeneroID = selectedItem.GeneroID
            };
        }

        public static void CargarDatosComboInstitucion(ref ComboBox combo)
        {
            IServicioIntitucion servicioIntitucion = new ServicioInstitucion();
            var lista = servicioIntitucion.GetLista();
            var defaultt = new InstitucionListDto { InstitucionID = 0, Denominacion = "Seleccione Denominacion" };
            lista.Insert(0, defaultt);
            combo.DataSource = lista;
            combo.ValueMember = "InstitucionID";
            combo.DisplayMember = "Denominacion";
            combo.SelectedIndex = 0;
        }
        public static void CargarDatosComboDonantes(ref ComboBox combo)
        {
            IServicioDonante servicioDonante = new ServicioDonante();
            var lista = servicioDonante.GetLista();
            var defaultt = new Donante { DonanteID = 0, NombreDonante = "Seleccione Donante" };
            lista.Insert(0, defaultt);
            combo.DataSource = lista;
            combo.ValueMember = "DonanteID";
            combo.DisplayMember = "NombreDonante";
            combo.SelectedIndex = 0;
        }
        public static void CargarDatosComboPaciente(ref ComboBox combo)
        {
            IServicioPaciente servicioPaciente = new ServicioPaciente();
            var lista = servicioPaciente.GetLista();
            var defaultt = new Paciente { PacienteID = 0, NombrePaciente = "Seleccione Paciente" };
            lista.Insert(0, defaultt);
            combo.DataSource = lista;
            combo.ValueMember = "PacienteID";
            combo.DisplayMember = "NombrePaciente";
            combo.SelectedIndex = 0;
        }
        public static void CargarDatosComboTipoDonacion(ref ComboBox combo)
        {
            IServicioTipoDonacion servicioTipo = new ServicioTipoDonacion();
            var lista = servicioTipo.GetTipoDonacions();
            var defaultt = new TipoDonacion { TipoDonacionID = 0, Descripcion = "Seleccione Tipo de Donacion" };
            lista.Insert(0, defaultt);
            combo.DataSource = lista;
            combo.ValueMember = "TipoDonacionID";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;
        }
        public static void CargarDatosComboTipoDonacionAutomatizada(ref ComboBox combo)
        {
            IServicioDonacionAutomatizada servicioDonacionAutomatizada = new ServicioDonacionAutomatizada();
            var lista = servicioDonacionAutomatizada.GetDonacions();
            var defaultt = new DonacionAutomatizada { DonacionAutoID = 0, Descripcion = "Seleccione Donacion automatizada" };
            lista.Insert(0, defaultt);
            combo.DataSource = lista;
            combo.ValueMember = "DonacionAutoID";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;
        }
    }
}
