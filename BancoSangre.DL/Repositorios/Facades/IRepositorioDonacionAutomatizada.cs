using BancoSangre.BL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioDonacionAutomatizada
    {
        List<DonacionAutomatizada> GetDonacions();
        DonacionAutomatizada GetTipoDonacionAutoPorID(int id);
        void guardar(DonacionAutomatizada dona);
        void borrar(int id);
        bool existe(DonacionAutomatizada donacion);
    }
}
