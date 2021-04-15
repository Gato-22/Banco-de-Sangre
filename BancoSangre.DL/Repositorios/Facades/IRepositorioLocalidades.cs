using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Localidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioLocalidades
    {
        List<LocalidadListDto> GetLista(BL.Entidades.DTO.Provincia.ProvinciaListDto provinciaDto);
        void guardar(Localidad localidad);
        bool existe(Localidad localidad);
        void borrar(int id);
        LocalidadEditDto GetlocalidadPorId(int id);
    }
}
