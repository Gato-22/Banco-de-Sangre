using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades.DTO.Institucion
{
    public class InstitucionListDto
    {
        public int InstitucionID { get; set; }
        public string Denominacion { get; set; }
        public string Direccion { get; set; }
        public string localidad { get; set; }
        public string provincia { get; set; }
        
    }
}
