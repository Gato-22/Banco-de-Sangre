using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades
{
    public class Localidad
    {
        public int LocalidadID { get; set; }
        public string NombreLocalidad { get; set; }
        public Provincia provincia { get; set; }
    }
}
