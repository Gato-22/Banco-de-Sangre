using BancoSangre.BL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface IServicioDocumento
    {
        List<Documento> GetDocumentos();
        Documento GetDocumentoID(int id);
        void Guardar(Documento documento);
        void borrar(int id);
        bool existe(Documento documento);
    }
}
