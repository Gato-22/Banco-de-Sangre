using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Generos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface IServicioGenero
    {
        List<GeneroListDto> GetGeneros();
        GeneroEditDto GetGeneroID(int id);
        void Guardar(GeneroEditDto genero);
        void Borar(int id);
        bool existe(GeneroEditDto genero);
    }
}
