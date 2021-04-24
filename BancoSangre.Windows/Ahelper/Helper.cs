using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Localidad;
using BancoSangre.BL.Entidades.DTO.Provincia;
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
    }
}
