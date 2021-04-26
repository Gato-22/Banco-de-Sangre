using BancoSangre.BL.Entidades.DTO.Documentos;
using BancoSangre.BL.Entidades.DTO.Generos;
using BancoSangre.BL.Entidades.DTO.Localidad;
using BancoSangre.BL.Entidades.DTO.Provincia;
using BancoSangre.BL.Entidades.DTO.TiposSangres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades.DTO
{
    public class DonanteEditDto
    {
        public int DonanteID { get; set; }
        public string NombreDonante { get; set; }
        public string ApellidoDonante { get; set; }
        public GeneroListDto genero { get; set; }
        public DocumentoListDto documento { get; set; }
        public string NroDocumento { get; set; }
        public string Direccion { get; set; }
        public LocalidadListDto localidad { get; set; }
        public ProvinciaListDto provincia { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string Email { get; set; }
        public DateTime FechaNac { get; set; }
        public TipoSangreListDto tipoSangre { get; set; }
    }
}
