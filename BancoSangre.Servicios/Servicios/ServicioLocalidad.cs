using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Localidad;
using BancoSangre.BL.Entidades.DTO.Provincia;
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
        
        public bool existe(LocalidadEditDto localidadDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioLocalidad(_conexionBd.AbrirConexion());
                //_repositorioprovincias = new RepositorioProvincias(_conexionBd.AbrirConexion());
                Localidad localidad = new Localidad
                {
                    LocalidadID = localidadDto.LocalidadID,
                    NombreLocalidad = localidadDto.NombreLocalidad,
                    provincia = new Provincia
                    {
                        ProvinciaID= localidadDto.ProvinciaID.Provinciaid,
                        NombreProvincia= localidadDto.ProvinciaID.NombreProvincia
                    }
                };
                var existe = _repositorio.existe(localidad);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception )
            {
                throw new Exception("Error al intentar ver si existe la localidad");
            }
        }

        public List<LocalidadListDto> GetLista(ProvinciaListDto provinciaDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioLocalidad(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetLista(provinciaDto);
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public LocalidadEditDto getLocalidadPorID(int id)
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

        public void guardar(LocalidadEditDto localidadDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioLocalidad(_conexionBd.AbrirConexion());
                
                var localidad = new Localidad
                {
                    LocalidadID = localidadDto.LocalidadID,
                    NombreLocalidad = localidadDto.NombreLocalidad,
                    provincia=new Provincia
                    {
                        ProvinciaID = localidadDto.ProvinciaID.Provinciaid,
                        NombreProvincia = localidadDto.ProvinciaID.NombreProvincia
                    }
                };
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
