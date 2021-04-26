using BancoSangre.BL.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface IServicioDonante
    {
        List<DonanteListDto> GetLista();
        void guardar(DonanteEditDto donanteEditDto);
        bool existe(DonanteEditDto donanteEditDto);
        void borrar(int id);
        DonanteEditDto getDonantePorId(int id);
    }
}
