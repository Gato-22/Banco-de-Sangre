using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades
{
    public class Donante:ICloneable
    {
        public int DonanteID { get; set; }
        public string NombreDonante { get; set; }
        public string ApellidoDonante { get; set; }
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
        public string Nombrecompleto
        {
            get { return NombreDonante + " " + ApellidoDonante; }
            set { Nombrecompleto = value; }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
