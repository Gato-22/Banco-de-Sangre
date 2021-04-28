using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface IServicioDonante
    {
        List<Donante> GetLista();
        void guardar(Donante donanteEditDto);
        bool existe(Donante donanteEditDto);
        void borrar(int id);
        Donante getDonantePorId(int id);
        List<Donante> GetLista(Paciente paciente);
    }
}
