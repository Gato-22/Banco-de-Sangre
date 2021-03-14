using BancoSangre.BL.Entidades;
using System.Collections.Generic;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioPacientes
    {
        List<Donante> GetDonante();
        Donante GetDonantePorID(int id);
        void Guardar(Donante donante);
        void Borrar(int id);
        bool Existe(Donante donante);
    }
}
