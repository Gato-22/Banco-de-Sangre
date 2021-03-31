using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades
{
    public class Genero : ICloneable
    {
        public int GeneroID { get; set; }

        public string GeneroDescripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
