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
    public class ServicioTipoDonacion : IServicioTipoDonacion
    {        
        private IRepositorioTipoDonaciones _Repositori;
        private ConexionBd _conexionBd;
        public void borrar(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositori = new RepositorioTipoDonaciones(_conexionBd.AbrirConexion());
                _Repositori.borrar(id);
                _conexionBd.CerrarConexion();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool existe(TipoDonacion tipoDonacion)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositori = new RepositorioTipoDonaciones(_conexionBd.AbrirConexion());
                var existe = _Repositori.existe(tipoDonacion);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoDonacion getTipoDonacionID(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoDonacion> GetTipoDonacions()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositori = new RepositorioTipoDonaciones(_conexionBd.AbrirConexion());
                var lista = _Repositori.GetTipoDonacions();
                _conexionBd.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void guardar(TipoDonacion tipoDonacion)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositori = new RepositorioTipoDonaciones(_conexionBd.AbrirConexion());
                _Repositori.guardar(tipoDonacion);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
