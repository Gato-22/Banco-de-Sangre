using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface IServicioDocumento
    {
        List<DocumentoListDto> GetDocumentos();
        DocumentoEditDto GetDocumentoID(int id);
        void Guardar(DocumentoEditDto documento);
        void borrar(int id);
        bool existe(DocumentoEditDto documento);
    }
}
