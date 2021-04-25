using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades.DTO.TiposSangres
{
    public class TipoSangreListDto: ICloneable
    {
        public int GrupoSanguineoID { get; set; }
        public string Grupo { get; set; }
        public string Factor { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
