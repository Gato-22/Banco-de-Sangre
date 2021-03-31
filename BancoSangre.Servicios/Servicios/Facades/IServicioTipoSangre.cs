using BancoSangre.BL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface IServicioTipoSangre
    {
        List<TipoSangre> GetTipoSangres();
        TipoSangre GetTipoSangreID(int id);
        void guardar(TipoSangre tipoSangre);
        void borrar(int id);
        bool existe(TipoSangre tipoSangre);
    }
}
