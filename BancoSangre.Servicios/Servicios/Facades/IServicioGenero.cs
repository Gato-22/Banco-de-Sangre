using BancoSangre.BL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface IServicioGenero
    {
        List<Genero> GetGeneros();
        Genero GetGeneroID(int id);
        void Guardar(Genero genero);
        void Borar(int id);
        bool existe(Genero genero);
    }
}
