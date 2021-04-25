using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.TiposSangres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioTipoSangre
    {
        List<TipoSangreListDto>GetTipoSangres();
        TipoSangreEditDto GetTipoSangrePorID(int id);
        void guardar(TipoSangre tipoSangre);
        void borrar(int id);
        bool existe(TipoSangre tipoSangre);
    }
}
