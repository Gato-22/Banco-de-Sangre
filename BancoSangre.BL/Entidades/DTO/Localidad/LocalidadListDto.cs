using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades.DTO.Localidad
{
    public class LocalidadListDto:ICloneable
    {
        public int LocalidadID { get; set; }
        public string NombreLocalidad { get; set; }
        public string NombreProvincia { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
