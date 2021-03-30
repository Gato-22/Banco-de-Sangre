using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades
{
    public class Provincia:ICloneable
    {
        public int ProvinciaID { get; set; }
        public string NombreProvincia { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
