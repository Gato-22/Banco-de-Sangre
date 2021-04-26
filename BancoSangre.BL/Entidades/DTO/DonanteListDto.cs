using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades.DTO
{
    public class DonanteListDto:ICloneable
    {
        public int DonanteID { get; set; }
        public string NombreDonante { get; set; }
        public string ApellidoDonante { get; set; }
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
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
