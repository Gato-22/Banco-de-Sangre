using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades.DTO.Localidad
{
    public class LocalidadEditDto : ICloneable
    {
        public int LocalidadID { get; set; }
        public string NombreLocalidad { get; set; }
        public int Provinciaid { get; set; }
        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
