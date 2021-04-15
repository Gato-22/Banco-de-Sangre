using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades.DTO.Provincia
{
    public class ProvinciaCantidadLocalidadListDto
    {
        public int ProvinciaID { get; set; }
        public string NombreProvincia { get; set; }
        public int CantidadLocalidades { get; set; }
    }
}
