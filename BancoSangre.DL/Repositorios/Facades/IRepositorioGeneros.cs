using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Generos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioGeneros
    {
        List<GeneroListDto> GetGeneros();
        GeneroEditDto GetGeneroPorID(int id);
        void Guardar(Genero genero);
        void Borar(int id);
        bool existe(Genero genero);
    }
}
