using BancoSangre.BL.Entidades.DTO.Institucion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface IServicioIntitucion
    {
        List<InstitucionListDto> GetLista();
    }
}
