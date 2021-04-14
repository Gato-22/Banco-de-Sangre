using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades
{
    public class DonacionAutomatizada: ICloneable
    {
        public int DonacionAutoID { get; set; }
        public string Descripcion { get; set; }
        public int Intervalo { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
