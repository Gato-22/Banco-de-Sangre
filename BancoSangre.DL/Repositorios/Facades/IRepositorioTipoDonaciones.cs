using BancoSangre.BL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioTipoDonaciones
    {
        List<TipoDonacion> GetTipoDonacions();
        TipoDonacion getTipoDonacionporID(int id);
        void guardar(TipoDonacion tipoDonacion);
        void borrar(int id);
        bool existe(TipoDonacion tipoDonacion);
    }
}
