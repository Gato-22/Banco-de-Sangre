using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Provincia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioProvincias
    {
        List<ProvinciaListDto> GetProvincias();
        ProvinciaEditDto GetProvinciaPorID(int id);
        void Guardar(Provincia provincia);
        void borrar(int id);
        bool existe(Provincia provincia);

    }
}
