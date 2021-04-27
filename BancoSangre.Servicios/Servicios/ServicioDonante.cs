using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO;
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
    public class ServicioDonante : IServicioDonante
    {
        private ConexionBd _conexionBd;
        private IRepositorioDonante _repo;
        private IRepositorioDocumentos _repositorioDocumentos;
        private IRepositorioGeneros _repositorioGeneros;
        private IRepositorioLocalidades _repositorioLocalidades;
        private IRepositorioProvincias _repositorioProvincias;
        private IRepositorioTipoSangre _repositorioTipoSangre;
        public ServicioDonante()
        {

        }

        public void borrar(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioDonante(_conexionBd.AbrirConexion());
                _repo.borrar(id);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool existe(Donante donanteEditDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioDonante(_conexionBd.AbrirConexion());

                Donante donante = new Donante
                {
                    NombreDonante = donanteEditDto.NombreDonante,
                    ApellidoDonante = donanteEditDto.ApellidoDonante,
                    genero = new Genero()
                    {
                        GeneroID = donanteEditDto.genero.GeneroID,
                        GeneroDescripcion = donanteEditDto.genero.GeneroDescripcion
                    },
                    documento = new Documento()
                    {
                        TipoDocumentoID = donanteEditDto.documento.TipoDocumentoID,
                        Descripcion = donanteEditDto.documento.Descripcion
                    },
                    NroDocumento = donanteEditDto.NroDocumento,
                    Direccion = donanteEditDto.Direccion,
                    provincia = new Provincia()
                    {
                        ProvinciaID = donanteEditDto.provincia.ProvinciaID,
                        NombreProvincia = donanteEditDto.provincia.NombreProvincia
                    },
                    localidad = new Localidad
                    {
                        LocalidadID = donanteEditDto.localidad.LocalidadID,
                        NombreLocalidad = donanteEditDto.localidad.NombreLocalidad,
                        provincia = new Provincia()
                        {
                            ProvinciaID = donanteEditDto.provincia.ProvinciaID,
                            NombreProvincia = donanteEditDto.provincia.NombreProvincia
                        },
                    },
                    TelefonoFijo = donanteEditDto.TelefonoFijo,
                    TelefonoMovil = donanteEditDto.TelefonoMovil,
                    Email = donanteEditDto.Email,
                    FechaNac = donanteEditDto.FechaNac,
                    tipoSangre = new TipoSangre()
                    {
                        GrupoSanguineoID = donanteEditDto.tipoSangre.GrupoSanguineoID,
                        Grupo = donanteEditDto.tipoSangre.Grupo,
                        Factor = donanteEditDto.tipoSangre.Factor
                    },
                    DonanteID = donanteEditDto.DonanteID


                };
                var existe = _repo.existe(donante);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception)
            {

                throw new Exception(" error al ver si existe el donante");
            }
        }

        public List<Donante> GetLista()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioGeneros = new RepositorioGeneros(_conexionBd.AbrirConexion());
                _repositorioDocumentos = new RepositorioDocumentos(_conexionBd.AbrirConexion());
                _repositorioProvincias = new RepositorioProvincias(_conexionBd.AbrirConexion());
                _repositorioLocalidades = new RepositorioLocalidad(_conexionBd.AbrirConexion(), _repositorioProvincias);
                _repositorioTipoSangre = new RepositorioTipoSangre(_conexionBd.AbrirConexion());

                _repo = new RepositorioDonante(_conexionBd.AbrirConexion(), _repositorioProvincias, _repositorioLocalidades, _repositorioGeneros, _repositorioDocumentos, _repositorioTipoSangre);
                var lista = _repo.GetLista();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Donante getDonantePorId(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repositorioGeneros = new RepositorioGeneros(_conexionBd.AbrirConexion());
                _repositorioDocumentos = new RepositorioDocumentos(_conexionBd.AbrirConexion());
                _repositorioProvincias = new RepositorioProvincias(_conexionBd.AbrirConexion());
                _repositorioLocalidades = new RepositorioLocalidad(_conexionBd.AbrirConexion(), _repositorioProvincias);
                _repositorioTipoSangre = new RepositorioTipoSangre(_conexionBd.AbrirConexion());
                
                _repo = new RepositorioDonante(_conexionBd.AbrirConexion(), _repositorioProvincias, _repositorioLocalidades,  _repositorioGeneros, _repositorioDocumentos, _repositorioTipoSangre);
                var cliente = _repo.getDonantePorId(id);
                _conexionBd.CerrarConexion();
                return cliente;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void guardar(Donante donanteEditDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioDonante(_conexionBd.AbrirConexion());

                Donante donante = new Donante
                {
                    NombreDonante = donanteEditDto.NombreDonante,
                    ApellidoDonante = donanteEditDto.ApellidoDonante,
                    genero = new Genero()
                    {
                        GeneroID = donanteEditDto.genero.GeneroID,
                        GeneroDescripcion = donanteEditDto.genero.GeneroDescripcion
                    },
                    documento = new Documento()
                    {
                        TipoDocumentoID = donanteEditDto.documento.TipoDocumentoID,
                        Descripcion = donanteEditDto.documento.Descripcion
                    },
                    NroDocumento = donanteEditDto.NroDocumento,
                    Direccion = donanteEditDto.Direccion,
                    provincia = new Provincia()
                    {
                        ProvinciaID = donanteEditDto.provincia.ProvinciaID,
                        NombreProvincia = donanteEditDto.provincia.NombreProvincia
                    },
                    localidad = new Localidad
                    {
                        LocalidadID = donanteEditDto.localidad.LocalidadID,
                        NombreLocalidad = donanteEditDto.localidad.NombreLocalidad,
                        provincia = new Provincia()
                        {
                            ProvinciaID = donanteEditDto.provincia.ProvinciaID,
                            NombreProvincia = donanteEditDto.provincia.NombreProvincia
                        },
                    },
                    TelefonoFijo = donanteEditDto.TelefonoFijo,
                    TelefonoMovil = donanteEditDto.TelefonoMovil,
                    Email = donanteEditDto.Email,
                    FechaNac = donanteEditDto.FechaNac,
                    tipoSangre = new TipoSangre()
                    {
                        GrupoSanguineoID = donanteEditDto.tipoSangre.GrupoSanguineoID,
                        Grupo = donanteEditDto.tipoSangre.Grupo,
                        Factor = donanteEditDto.tipoSangre.Factor
                    },
                    
                    DonanteID = donanteEditDto.DonanteID

                };
                _repo.guardar(donante);
                donanteEditDto.DonanteID = donante.DonanteID;
                _conexionBd.CerrarConexion();

            }
            catch (Exception)
            {

                throw new Exception(" error al ver si existe el Donante");
            }
        }
    }
}
