using BancoSangre.BL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface IServicioDonacionAutomatizada
    {
        List<DonacionAutomatizada> GetDonacions();
        DonacionAutomatizada GetTipoDonacionAutoID(int id);
        void guardar(DonacionAutomatizada dona);
        void borrar(int id);
        bool existe(DonacionAutomatizada donacion);
    }
}
