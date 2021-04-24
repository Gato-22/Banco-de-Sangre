using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Institucion;
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
    public class ServicioInstitucion : IServicioIntitucion
    {
        private ConexionBd _conexionBd;
        private IRepositorioInstituciones _repositorio;
        private IRepositorioLocalidades _repositorioLocalidades;
        private IRepositorioProvincias _repositorioProvincias;
        public ServicioInstitucion()
        {

        }

        public void borrar(int institucionID)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioInstituciones(_conexionBd.AbrirConexion());
                _repositorio.borrar(institucionID);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool existe(InstitucionEditdto institucionEditdto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioInstituciones(_conexionBd.AbrirConexion());
               
                Institucion institucion = new Institucion
                {
                    InstitucionID = institucionEditdto.InstitucionID,
                    Denominacion = institucionEditdto.Denominacion,
                    Direccion = institucionEditdto.Direccion,                    
                    provincia = new Provincia()
                    {
                        ProvinciaID = institucionEditdto.provincia.Provinciaid,
                        NombreProvincia = institucionEditdto.provincia.NombreProvincia
                    },
                    localidad = new Localidad
                    {
                        LocalidadID = institucionEditdto.localidad.LocalidadID,
                        NombreLocalidad = institucionEditdto.localidad.NombreLocalidad,
                        provincia = new Provincia()
                        {
                            ProvinciaID = institucionEditdto.provincia.Provinciaid,
                            NombreProvincia = institucionEditdto.provincia.NombreProvincia
                        },
                    },
                    telefonoFijo = institucionEditdto.telefonoFijo,
                    telefonoMovil = institucionEditdto.telefonoMovil,
                    correoElectronico = institucionEditdto.correoElectronico

                };
                var existe = _repositorio.existe(institucion);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception )
            {
                throw new Exception("Error al intentar ver si existe la institucion");
            }
        }

        public InstitucionEditdto GetInstitucionPorId(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioProvincias = new RepositorioProvincias(_conexionBd.AbrirConexion());
                _repositorioLocalidades = new RepositorioLocalidad(_conexionBd.AbrirConexion(), _repositorioProvincias);
                _repositorio = new RepositorioInstituciones(_conexionBd.AbrirConexion(), _repositorioProvincias, _repositorioLocalidades);
                var cliente = _repositorio.GetInstitucionPorID(id);
                _conexionBd.CerrarConexion();
                return cliente;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<InstitucionListDto> GetLista()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioInstituciones(_conexionBd.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void guardar(InstitucionEditdto institucionEditdto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorio = new RepositorioInstituciones(_conexionBd.AbrirConexion());
                Institucion institucion = new Institucion
                {
                    InstitucionID = institucionEditdto.InstitucionID,
                    Denominacion = institucionEditdto.Denominacion,
                    Direccion = institucionEditdto.Direccion,
                    provincia = new Provincia()
                    {
                        ProvinciaID = institucionEditdto.provincia.Provinciaid,
                        NombreProvincia = institucionEditdto.provincia.NombreProvincia
                    },
                    localidad = new Localidad
                    {
                        LocalidadID = institucionEditdto.localidad.LocalidadID,
                        NombreLocalidad = institucionEditdto.localidad.NombreLocalidad,
                        provincia = new Provincia()
                        {
                            ProvinciaID = institucionEditdto.provincia.Provinciaid,
                            NombreProvincia = institucionEditdto.provincia.NombreProvincia
                        },
                    },
                    telefonoFijo = institucionEditdto.telefonoFijo,
                    telefonoMovil = institucionEditdto.telefonoMovil,
                    correoElectronico = institucionEditdto.correoElectronico
                };
                _repositorio.guardar(institucion);
                institucionEditdto.InstitucionID = institucion.InstitucionID;
                _conexionBd.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
