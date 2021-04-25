using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Documentos;
using BancoSangre.DL;
using BancoSangre.DL.Repositorios;
using BancoSangre.DL.Repositorios.Facades;
using BancoSangre.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios
{
    public class ServicioDocumentos : IServicioDocumento
    {
        private IRepositorioDocumentos _Repositorio;
        private ConexionBd _conexionBd;
        public void borrar(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositorio = new RepositorioDocumentos(_conexionBd.AbrirConexion());
                _Repositorio.borrar(id);
                _conexionBd.CerrarConexion();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool existe(DocumentoEditDto documentoDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositorio = new RepositorioDocumentos(_conexionBd.AbrirConexion());
                var documento = new Documento
                {
                    TipoDocumentoID=documentoDto.TipoDocumentoID,
                    Descripcion=documentoDto.Descripcion
                };
                var existe = _Repositorio.existe(documento);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public DocumentoEditDto GetDocumentoID(int id)
        {
            _conexionBd = new ConexionBd();
            _Repositorio = new RepositorioDocumentos(_conexionBd.AbrirConexion());
            var documento = _Repositorio.GetDocumentoPorID(id);
            _conexionBd.CerrarConexion();
            return documento;
        }

        public List<DocumentoListDto> GetDocumentos()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositorio = new RepositorioDocumentos(_conexionBd.AbrirConexion());
                var lista = _Repositorio.GetDocumentos();
                _conexionBd.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(DocumentoEditDto documentoDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositorio = new RepositorioDocumentos(_conexionBd.AbrirConexion());
                var documento = new Documento
                {
                    TipoDocumentoID = documentoDto.TipoDocumentoID,
                    Descripcion = documentoDto.Descripcion
                };
                _Repositorio.Guardar(documento);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
