using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Generos;
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
    public class ServicioGeneros : IServicioGenero
    {
        private IRepositorioGeneros _Repositorio;
        private ConexionBd _conexionBd;

        public void Borar(int id)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositorio = new RepositorioGeneros(_conexionBd.AbrirConexion());
                _Repositorio.Borar(id);
                _conexionBd.CerrarConexion();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool existe(GeneroEditDto genero)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositorio = new RepositorioGeneros(_conexionBd.AbrirConexion());
                var generoo = new Genero
                {
                    GeneroID = genero.GeneroID,
                    GeneroDescripcion = genero.GeneroDescripcion
                };
                var existe = _Repositorio.existe(generoo);
                _conexionBd.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public GeneroEditDto GetGeneroID(int id)
        {
            throw new NotImplementedException();
        }

        public List<GeneroListDto> GetGeneros()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositorio = new RepositorioGeneros(_conexionBd.AbrirConexion());
                var lista = _Repositorio.GetGeneros();
                _conexionBd.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(GeneroEditDto genero)
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositorio = new RepositorioGeneros(_conexionBd.AbrirConexion());
                var generoo = new Genero
                {
                    GeneroID = genero.GeneroID,
                    GeneroDescripcion = genero.GeneroDescripcion
                };
                _Repositorio.Guardar(generoo);
                _conexionBd.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
