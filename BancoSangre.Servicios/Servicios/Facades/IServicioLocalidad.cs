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
        List<LocalidadListDto> GetLista(BL.Entidades.DTO.Provincia.ProvinciaListDto providto);
        void guardar(LocalidadEditDto localidadEditDto);
        bool existe(LocalidadEditDto localidad);
        void Borrar(int id);
        LocalidadEditDto getLocalidadPorID(int id);
    }
}
