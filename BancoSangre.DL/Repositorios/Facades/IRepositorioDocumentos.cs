using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios.Facades
{
    public interface IRepositorioDocumentos
    {
        List<DocumentoListDto>GetDocumentos();
        DocumentoEditDto GetDocumentoPorID(int id);
        void Guardar(Documento documento);
        void borrar(int id);
        bool existe(Documento documento);

    }
}
