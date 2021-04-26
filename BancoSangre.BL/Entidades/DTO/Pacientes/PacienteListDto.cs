using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades.DTO.Pacientes
{
    public class PacienteListDto:ICloneable
    {
        public int PacienteID { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public string Genero { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string provincia { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string Email { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string tipoSangre { get; set; }
        public string institucion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
