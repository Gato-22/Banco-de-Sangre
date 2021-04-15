using BancoSangre.BL.Entidades;
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
    public class ServicioProvincias : iServiciosProvincia
    {
        private IRepositorioProvincias _Repositorio;
        private ConexionBd _conexionBd;

        
        public void Borrar(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
                _Repositorio.borrar(id);
                _conexionBd.CerrarConexion();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(ProvinciaEditDto provinciaDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
                var provincia = new Provincia
                {
                    ProvinciaID = provinciaDto.ProvinciaId,
                    NombreProvincia = provinciaDto.NombreProvincia
                };
                var existe = _Repositorio.existe(provincia);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }

        public ProvinciaEditDto GetProvinciaPorId(int id)
        {
            _conexionBd = new ConexionBd();
            _Repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
            var provincia = _Repositorio.GetProvinciaPorID(id);
            _conexionBd.CerrarConexion();
            return provincia;
        }

        public List<ProvinciaListDto> GetProvincias()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
                var lista = _Repositorio.GetProvincias();
                _conexionBd.CerrarConexion();
                return lista;
                
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        
        public void Guardar(ProvinciaEditDto provinciaDto)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositorio = new RepositorioProvincias(_conexionBd.AbrirConexion());
                var provincia = new Provincia
                {
                    ProvinciaID = provinciaDto.ProvinciaId,
                    NombreProvincia=provinciaDto.NombreProvincia
                };
                _Repositorio.Guardar(provincia);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
