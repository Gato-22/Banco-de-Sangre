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
    public class ServicioDonacionAutomatizada : IServicioDonacionAutomatizada
    {
        private IRepositorioDonacionAutomatizada _repo;
        private ConexionBd _conexionBd;
        public void borrar(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioDonacionAutomatizada(_conexionBd.AbrirConexion());
                _repo.borrar(id);
                _conexionBd.CerrarConexion();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool existe(DonacionAutomatizada donacion)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioDonacionAutomatizada(_conexionBd.AbrirConexion());
                var existe = _repo.existe(donacion);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<DonacionAutomatizada> GetDonacions()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioDonacionAutomatizada(_conexionBd.AbrirConexion());
                var lista = _repo.GetDonacions();
                _conexionBd.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public DonacionAutomatizada GetTipoDonacionAutoID(int id)
        {
            throw new NotImplementedException();
        }

        public void guardar(DonacionAutomatizada dona)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioDonacionAutomatizada(_conexionBd.AbrirConexion());
                _repo.guardar(dona);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
