using BancoSangre.BL.Entidades.DTO.Localidad;
using BancoSangre.BL.Entidades.DTO.Provincia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades.DTO.Institucion
{
    public class InstitucionEditdto
    {
        public int InstitucionID { get; set; }
        public string Denominacion { get; set; }
        public string Direccion { get; set; }
        public LocalidadListDto localidad { get; set; }
        public ProvinciaListDto provincia { get; set; }
        public string telefonoFijo { get; set; }
        public string telefonoMovil { get; set; }
        public string correoElectronico { get; set; }
    }
}
