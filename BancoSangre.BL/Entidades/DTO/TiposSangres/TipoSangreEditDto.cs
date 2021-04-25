using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades.DTO.TiposSangres
{
    public class TipoSangreEditDto
    {
        public int GrupoSanguineoID { get; set; }
        public string Grupo { get; set; }
        public string Factor { get; set; }
    }
}
