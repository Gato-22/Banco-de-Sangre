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
    public class ServicioProvincias : iServiciosProvincia
    {
        private IRepositorioProvincias _Repositorio;
        private ConexionBd _conexionBd;

        
        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Provincia provincia)
        {
            throw new NotImplementedException();
        }

        public Provincia GetProvinciaId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Provincia> GetProvincias()
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
        //
        public void Guardar(Provincia provincia)
        {
            throw new NotImplementedException();
        }
    }
}
