using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades.DTO.Provincia
{
    public class ProvinciaListDto : ICloneable
    {
        public int Provinciaid { get; set; }
        public string NombreProvincia { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
