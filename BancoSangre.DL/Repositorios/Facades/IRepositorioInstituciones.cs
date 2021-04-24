using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Institucion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioInstituciones
    {
        List<InstitucionListDto> GetLista();
        void guardar(Institucion institucion);
        bool existe(Institucion institucion);
        void borrar(int institucionid);
        InstitucionEditdto GetInstitucionPorID(int id);
    }
}
