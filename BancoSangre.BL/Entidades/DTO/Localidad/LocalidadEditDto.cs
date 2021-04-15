using BancoSangre.BL.Entidades.DTO.Provincia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades.DTO.Localidad
{
    public class LocalidadEditDto 
    {
        public int LocalidadID { get; set; }
        public string NombreLocalidad { get; set; }
        public ProvinciaListDto ProvinciaID { get; set; }
        
    }
}
