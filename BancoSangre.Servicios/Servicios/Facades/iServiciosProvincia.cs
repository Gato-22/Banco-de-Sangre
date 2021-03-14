using BancoSangre.BL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface iServiciosProvincia
    {
        List<Provincia> GetProvincias();
        Provincia GetProvinciaId(int id);
        void Guardar(Provincia provincia);
        void Borrar(int id);
        bool Existe(Provincia provincia);
    }
}
