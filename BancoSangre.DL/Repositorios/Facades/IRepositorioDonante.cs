using BancoSangre.BL.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioDonante
    {
        List<DonanteListDto> GetLista();
    }
}
