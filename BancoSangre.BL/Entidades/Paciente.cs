using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades
{
    public class Paciente:ICloneable
    {
        public int PacienteID { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public Genero genero { get; set; }
        public Documento documento { get; set; }
        public string NroDocumento { get; set; }
        public string Direccion { get; set; }
        public Localidad localidad { get; set; }
        public Provincia provincia { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string Email { get; set; }
        public DateTime FechaNac { get; set; }
        public TipoSangre tipoSangre { get; set; }
        public Institucion institucion { get; set; }
        public string NombreCompleto
        {
            get { return NombrePaciente + " " + ApellidoPaciente; }
            set { NombreCompleto = value; }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
