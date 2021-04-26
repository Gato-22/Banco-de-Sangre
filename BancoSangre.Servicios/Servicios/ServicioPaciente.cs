using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Pacientes;
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
    public class ServicioPaciente : IServicioPaciente
    {
        private ConexionBd _conexionBd;
        private IRepositorioPacientes _repo;
        private IRepositorioDocumentos _repositorioDocumentos;
        private IRepositorioGeneros _repositorioGeneros;
        private IRepositorioInstituciones _repositorioInstituciones;
        private IRepositorioLocalidades _repositorioLocalidades;
        private IRepositorioProvincias _repositorioProvincias;
        private IRepositorioTipoSangre _repositorioTipoSangre;
        public ServicioPaciente()
        {

        }
        public void borrar(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioPacientes(_conexionBd.AbrirConexion());
                _repo.borrar(id);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool existe(PacienteEditDto pacienteEditDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioPacientes(_conexionBd.AbrirConexion());

                Paciente paciente = new Paciente
                {
                    NombrePaciente = pacienteEditDto.NombrePaciente,
                    ApellidoPaciente = pacienteEditDto.ApellidoPaciente,
                    genero = new Genero()
                    {
                        GeneroID = pacienteEditDto.genero.GeneroID,
                        GeneroDescripcion = pacienteEditDto.genero.GeneroDescripcion
                    },
                    documento = new Documento()
                    {
                        TipoDocumentoID = pacienteEditDto.documento.TipoDocumentoID,
                        Descripcion = pacienteEditDto.documento.Descripcion
                    },
                    NroDocumento = pacienteEditDto.NroDocumento,
                    Direccion = pacienteEditDto.Direccion,
                    provincia = new Provincia()
                    {
                        ProvinciaID = pacienteEditDto.provincia.Provinciaid,
                        NombreProvincia = pacienteEditDto.provincia.NombreProvincia
                    },
                    localidad = new Localidad
                    {
                        LocalidadID = pacienteEditDto.localidad.LocalidadID,
                        NombreLocalidad = pacienteEditDto.localidad.NombreLocalidad,
                        provincia = new Provincia()
                        {
                            ProvinciaID = pacienteEditDto.provincia.Provinciaid,
                            NombreProvincia = pacienteEditDto.provincia.NombreProvincia
                        },
                    },
                    TelefonoFijo = pacienteEditDto.TelefonoFijo,
                    TelefonoMovil = pacienteEditDto.TelefonoMovil,
                    Email = pacienteEditDto.Email,
                    FechaNac = pacienteEditDto.FechaNac,
                    tipoSangre = new TipoSangre()
                    {
                        GrupoSanguineoID = pacienteEditDto.tipoSangre.GrupoSanguineoID,
                        Grupo = pacienteEditDto.tipoSangre.Grupo,
                        Factor = pacienteEditDto.tipoSangre.Factor
                    },
                    institucion = new Institucion
                    {
                        InstitucionID = pacienteEditDto.institucion.InstitucionID,
                        Denominacion = pacienteEditDto.institucion.Denominacion,
                        Direccion = pacienteEditDto.Direccion,
                        provincia = new Provincia()
                        {
                            ProvinciaID = pacienteEditDto.provincia.Provinciaid,
                            NombreProvincia = pacienteEditDto.provincia.NombreProvincia
                        },
                        localidad = new Localidad
                        {
                            LocalidadID = pacienteEditDto.localidad.LocalidadID,
                            NombreLocalidad = pacienteEditDto.localidad.NombreLocalidad,
                            provincia = new Provincia()
                            {
                                ProvinciaID = pacienteEditDto.provincia.Provinciaid,
                                NombreProvincia = pacienteEditDto.provincia.NombreProvincia
                            },
                        },
                    }

                };
                var existe = _repo.existe(paciente);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception)
            {

                throw new Exception(" error al ver si existe el paciente");
            }
        }

        public PacienteEditDto getPacientePorID(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioGeneros = new RepositorioGeneros(_conexionBd.AbrirConexion());
                _repositorioDocumentos = new RepositorioDocumentos(_conexionBd.AbrirConexion());
                _repositorioProvincias = new RepositorioProvincias(_conexionBd.AbrirConexion());
                _repositorioLocalidades = new RepositorioLocalidad(_conexionBd.AbrirConexion(), _repositorioProvincias);
                _repositorioTipoSangre = new RepositorioTipoSangre(_conexionBd.AbrirConexion());
                _repositorioInstituciones = new RepositorioInstituciones(_conexionBd.AbrirConexion(), _repositorioProvincias, _repositorioLocalidades );
                _repo = new RepositorioPacientes(_conexionBd.AbrirConexion(), _repositorioProvincias, _repositorioLocalidades,_repositorioInstituciones, _repositorioGeneros,_repositorioDocumentos,_repositorioTipoSangre);
                var cliente = _repo.getPacientePorID(id);
                _conexionBd.CerrarConexion();
                return cliente;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<PacienteListDto> GetLista()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioPacientes(_conexionBd.AbrirConexion());
                var lista = _repo.GetLista();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void guardar(PacienteEditDto pacienteEditDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioPacientes(_conexionBd.AbrirConexion());

                Paciente paciente = new Paciente
                {
                    NombrePaciente = pacienteEditDto.NombrePaciente,
                    ApellidoPaciente = pacienteEditDto.ApellidoPaciente,
                    genero = new Genero()
                    {
                        GeneroID = pacienteEditDto.genero.GeneroID,
                        GeneroDescripcion = pacienteEditDto.genero.GeneroDescripcion
                    },
                    documento = new Documento()
                    {
                        TipoDocumentoID = pacienteEditDto.documento.TipoDocumentoID,
                        Descripcion = pacienteEditDto.documento.Descripcion
                    },
                    NroDocumento = pacienteEditDto.NroDocumento,
                    Direccion = pacienteEditDto.Direccion,
                    provincia = new Provincia()
                    {
                        ProvinciaID = pacienteEditDto.provincia.Provinciaid,
                        NombreProvincia = pacienteEditDto.provincia.NombreProvincia
                    },
                    localidad = new Localidad
                    {
                        LocalidadID = pacienteEditDto.localidad.LocalidadID,
                        NombreLocalidad = pacienteEditDto.localidad.NombreLocalidad,
                        provincia = new Provincia()
                        {
                            ProvinciaID = pacienteEditDto.provincia.Provinciaid,
                            NombreProvincia = pacienteEditDto.provincia.NombreProvincia
                        },
                    },
                    TelefonoFijo = pacienteEditDto.TelefonoFijo,
                    TelefonoMovil = pacienteEditDto.TelefonoMovil,
                    Email = pacienteEditDto.Email,
                    FechaNac = pacienteEditDto.FechaNac,
                    tipoSangre = new TipoSangre()
                    {
                        GrupoSanguineoID = pacienteEditDto.tipoSangre.GrupoSanguineoID,
                        Grupo = pacienteEditDto.tipoSangre.Grupo,
                        Factor = pacienteEditDto.tipoSangre.Factor
                    },
                    institucion = new Institucion
                    {
                        InstitucionID = pacienteEditDto.institucion.InstitucionID,
                        Denominacion = pacienteEditDto.institucion.Denominacion,
                        Direccion = pacienteEditDto.Direccion,
                        provincia = new Provincia()
                        {
                            ProvinciaID = pacienteEditDto.provincia.Provinciaid,
                            NombreProvincia = pacienteEditDto.provincia.NombreProvincia
                        },
                        localidad = new Localidad
                        {
                            LocalidadID = pacienteEditDto.localidad.LocalidadID,
                            NombreLocalidad = pacienteEditDto.localidad.NombreLocalidad,
                            provincia = new Provincia()
                            {
                                ProvinciaID = pacienteEditDto.provincia.Provinciaid,
                                NombreProvincia = pacienteEditDto.provincia.NombreProvincia
                            },
                        },
                    },
                    PacienteID = pacienteEditDto.PacienteID

                };
                 _repo.guardar(paciente);
                pacienteEditDto.PacienteID = paciente.PacienteID;
                _conexionBd.CerrarConexion();
                
            }
            catch (Exception)
            {

                throw new Exception(" error al ver si existe el paciente");
            }
        }
    }
}
