using BancoSangre.BL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioDocumentos
    {
        List<Documento>GetDocumentos();
        Documento GetDocumentoPorID(int id);
        void Guardar(Documento documento);
        void borrar(int id);
        bool existe(Documento documento);

    }
}
