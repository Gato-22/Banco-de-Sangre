using BancoSangre.BL.Entidades.DTO.Institucion;
using BancoSangre.BL.Entidades.DTO.Localidad;
using BancoSangre.BL.Entidades.DTO.Provincia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades.DTO.Pacientes
{
    public class PacienteEditDto
    {
        public int DonanteID { get; set; }
        public string NombreDonante { get; set; }
        public string ApellidoDonante { get; set; }
        public Genero genero { get; set; }
        public Documento documento { get; set; }
        public string NroDocumento { get; set; }
        public string Direccion { get; set; }
        public LocalidadListDto localidad { get; set; }
        public ProvinciaListDto provincia { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string Email { get; set; }
        public DateTime FechaNac { get; set; }
        public TipoSangre tipoSangre { get; set; }
        public InstitucionListDto institucion { get; set; }
    }
}
