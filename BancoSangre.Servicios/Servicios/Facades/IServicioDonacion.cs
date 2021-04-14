using BancoSangre.BL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface IServicioDonacion
    {
        List<Donacion> GetDonacion();
        void guardar(Donacion donacion);
        bool existe(Donacion donacion);
        void borrar(int id);
        Donacion GetDonacionID(int id);
    }
}
