using BancoSangre.BL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface IServicioTipoDonacion
    {
        List<TipoDonacion> GetTipoDonacions();
        TipoDonacion getTipoDonacionID(int id);
        void guardar(TipoDonacion tipoDonacion);
        void borrar(int id);
        bool existe(TipoDonacion tipoDonacion);
    }
}
