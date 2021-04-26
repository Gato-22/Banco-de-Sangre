using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioDonante
    {
        List<DonanteListDto> GetLista();
        void guardar(Donante donante);
        bool existe(Donante donante);
        void borrar(int donanteid);
        DonanteEditDto getDonantePorId(int donanteID);
        //List<PacienteListDto> GetLista();
        //void guardar(Paciente paciente);
        //bool existe(Paciente paciente);
        //void borrar(int pacienteid);
        //PacienteEditDto getPacientePorID(int PacienteID);
    }
}
