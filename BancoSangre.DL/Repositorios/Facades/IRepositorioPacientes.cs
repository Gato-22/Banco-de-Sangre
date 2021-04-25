using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Pacientes;
using System.Collections.Generic;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioPacientes
    {
        List<PacienteListDto> GetLista();
        void guardar(Paciente paciente);
        bool existe(Paciente paciente);
        void borrar(int pacienteid);
        PacienteEditDto getPacientePorID(int PacienteID);
       
    }
}
