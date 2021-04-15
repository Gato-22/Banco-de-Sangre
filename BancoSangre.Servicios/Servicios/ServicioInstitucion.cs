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
        private IRepositorioInstituciones _repo;
        public List<InstitucionListDto> GetLista()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _repo = new RepositorioInstituciones(_conexionBd.AbrirConexion());
                var lista = _repo.GetLista();
                _conexionBd.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
