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
        public string localidad { get; set; }
        public string provincia { get; set; }
        public string tipoSangre { get; set; }
        public string institucion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
