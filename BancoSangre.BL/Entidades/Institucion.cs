using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades
{
    public class Institucion : ICloneable
    {
        public int InstitucionID { get; set; }
        public string Denominacion { get; set; }
        public string Direccion { get; set; }
        public Localidad localidad { get; set; }
        public Provincia provincia { get; set; }
        public string telefonoFijo { get; set; }
        public string telefonoMovil { get; set; }
        public string correoElectronico { get; set; }
        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
