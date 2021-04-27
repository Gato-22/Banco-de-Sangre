using BancoSangre.BL.Entidades;
using System.Collections.Generic;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioPacientes
    {
        List<Paciente> GetLista();
        void guardar(Paciente paciente);
        bool existe(Paciente paciente);
        void borrar(int pacienteid);
        Paciente getPacientePorID(int PacienteID);
       
    }
}
