using BancoSangre.BL.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface IServicioPaciente
    {
        List<Paciente> GetLista();
        void guardar(Paciente pacienteEditDto);
        bool existe(Paciente pacienteEditDto);
        void borrar(int id);
        Paciente getPacientePorID(int id);
    }
}
