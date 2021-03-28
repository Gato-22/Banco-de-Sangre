using BancoSangre.BL.Entidades;
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
            throw new NotImplementedException();
        }

        public bool editar(TipoSangre tipoSangre)
        {
            throw new NotImplementedException();
        }

        public TipoSangre GetTipoSangreID(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoSangre> GetTipoSangres()
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

        public void guardar(TipoSangre tipoSangre)
        {
            throw new NotImplementedException();
        }
    }
}
