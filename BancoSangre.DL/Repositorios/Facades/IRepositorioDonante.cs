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
        List<Donante> GetLista();
        void guardar(Donante donante);
        bool existe(Donante donante);
        void borrar(int donanteid);
        Donante getDonantePorId(int donanteID);
        //List<Paciente> GetLista();
        //void guardar(Paciente paciente);
        //bool existe(Paciente paciente);
        //void borrar(int pacienteid);
        //Paciente getPacientePorID(int PacienteID);
    }
}
