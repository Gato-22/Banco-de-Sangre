using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Localidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface IServicioLocalidad
    {
        List<LocalidadListDto> GetLista();
        void guardar(Localidad localidad);
        bool existe(Localidad localidad);
        void Borrar(int id);
        Localidad getLocalidadPorID(int id);
    }
}
