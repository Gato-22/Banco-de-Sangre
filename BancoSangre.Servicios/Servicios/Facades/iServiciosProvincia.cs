using BancoSangre.BL.Entidades;
using BancoSangre.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface iServiciosProvincia
    {
        List<Provincia> GetProvincias();
        Provincia GetProvinciaPorId(int id);
        void Guardar(Provincia provincia);
        void Borrar(int id);
        bool Existe(Provincia provincia);
        
           
        
    }
}
