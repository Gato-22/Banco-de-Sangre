using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.TiposSangres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface IServicioTipoSangre
    {
        List<TipoSangreListDto> GetTipoSangres();
        TipoSangreEditDto GetTipoSangreID(int id);
        void guardar(TipoSangreEditDto tipoSangre);
        void borrar(int id);
        bool existe(TipoSangreEditDto tipoSangre);
    }
}
