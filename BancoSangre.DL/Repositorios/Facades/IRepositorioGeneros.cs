using BancoSangre.BL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioGeneros
    {
        List<Genero> GetGeneros();
        Genero GetGeneroPorID(int id);
        void Guardar(Genero genero);
        void Borar(int id);
        bool existe(Genero genero);
    }
}
