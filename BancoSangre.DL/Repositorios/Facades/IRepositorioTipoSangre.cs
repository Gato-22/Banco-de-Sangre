using BancoSangre.BL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioTipoSangre
    {
        List<TipoSangre>GetTipoSangres();
        TipoSangre GetTipoSangrePorID(int id);
        void guardar(TipoSangre tipoSangre);
        void borrar(int id);
        bool existe(TipoSangre tipoSangre);
    }
}
