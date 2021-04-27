using BancoSangre.BL.Entidades;
using BancoSangre.DL;
using BancoSangre.DL.Repositorios;
using BancoSangre.DL.Repositorios.Facades;
using BancoSangre.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios
{
    public class ServicioDonacio : IServicioDonacion
    {
        IRepositorioDonacion _repo;
        IRepositorioDonacionAutomatizada _automatizada;
        ConexionBd _conexionBd;
        SqlTransaction sqlTransaction;
        public void borrar(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioDonacion(_conexionBd.AbrirConexion());
                _repo.borrar(id);
                _conexionBd.CerrarConexion();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool existe(Donacion donacion)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioDonacion(_conexionBd.AbrirConexion());
                var existe = false; //_repo.existe(donacion);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Donacion> GetDonacion()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioDonacion(_conexionBd.AbrirConexion());
                var lista = _repo.GetDonacion();
                _conexionBd.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            };
        }

        public Donacion GetDonacionID(int id)
        {
            throw new NotImplementedException();
        }

        public void guardar(Donacion donacion)
        {
            try
            {
                _conexionBd = new ConexionBd();
                var cn = _conexionBd.AbrirConexion();
                sqlTransaction = cn.BeginTransaction();
                _automatizada = new RepositorioDonacionAutomatizada(cn,sqlTransaction);
                _repo = new RepositorioDonacion(cn,sqlTransaction);
                _repo.guardar(donacion);
                if (donacion.TipoDonacion.TipoDonacionID==2)
                {
                    _automatizada.guardar(donacion.DonacionesDonacionesAutomatizadas.donacionAutomatizada);
                }
                sqlTransaction.Commit();
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {
                sqlTransaction.Rollback();
                throw new Exception(e.Message);
            }
        }
    }
}
