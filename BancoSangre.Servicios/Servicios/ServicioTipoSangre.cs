using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.TiposSangres;
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
    public class ServicioTipoSangre : IServicioTipoSangre
    {
        private IRepositorioTipoSangre _repo;
        private ConexionBd _conexionBd;
        public void borrar(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioTipoSangre(_conexionBd.AbrirConexion());
                _repo.borrar(id);
                _conexionBd.CerrarConexion();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool existe(TipoSangreEditDto tipoSangre)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioTipoSangre(_conexionBd.AbrirConexion());
                var tiposangree = new TipoSangre
                {
                    GrupoSanguineoID = tipoSangre.GrupoSanguineoID,
                    Grupo = tipoSangre.Grupo,
                    Factor=tipoSangre.Factor

                };
                var existe = _repo.existe(tiposangree);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoSangreEditDto GetTipoSangreID(int id)
        {
            _conexionBd = new ConexionBd();
            _repo = new RepositorioTipoSangre(_conexionBd.AbrirConexion());
            var tipoSangre = _repo.GetTipoSangrePorID(id);
            _conexionBd.CerrarConexion();
            return tipoSangre;
        }

        public List<TipoSangreListDto> GetTipoSangres()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioTipoSangre(_conexionBd.AbrirConexion());
                var lista = _repo.GetTipoSangres();
                _conexionBd.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void guardar(TipoSangreEditDto tipoSangre)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioTipoSangre(_conexionBd.AbrirConexion());
                var tiposangree = new TipoSangre
                {
                    GrupoSanguineoID = tipoSangre.GrupoSanguineoID,
                    Grupo = tipoSangre.Grupo,
                    Factor = tipoSangre.Factor

                };
                _repo.guardar(tiposangree);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
