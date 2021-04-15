using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Provincia;
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
        List<ProvinciaListDto> GetProvincias();
        ProvinciaEditDto GetProvinciaPorId(int id);
        void Guardar(ProvinciaEditDto provincia);
        void Borrar(int id);
        bool Existe(ProvinciaEditDto provincia);
        
           
        
    }
}
