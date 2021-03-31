using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Localidad;
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
    public class ServicioLocalidad : IServicioLocalidad
    {
        private ConexionBd _conexionBd;
        private  IRepositorioLocalidades _repositorio;
        private IRepositorioProvincias _repositorioprovincias;
        public ServicioLocalidad()
        {
            
        }

        public void Borrar(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioLocalidad(_conexionBd.AbrirConexion());
                _repositorio.borrar(id);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool existe(Localidad localidad)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioLocalidad(_conexionBd.AbrirConexion());
                var existe = _repositorio.existe(localidad);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception )
            {
                throw new Exception("Error al intentar ver si existe la localidad");
            }
        }

        public List<LocalidadListDto> GetLista()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioLocalidad(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Localidad getLocalidadPorID(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioprovincias = new RepositorioProvincias(_conexionBd.AbrirConexion());
                _repositorio = new RepositorioLocalidad(_conexionBd.AbrirConexion(),_repositorioprovincias);
                var localidad = _repositorio.GetlocalidadPorId(id);
                _conexionBd.CerrarConexion();
                return localidad;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void guardar(Localidad localidad)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioLocalidad(_conexionBd.AbrirConexion());
                _repositorio.guardar(localidad);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
