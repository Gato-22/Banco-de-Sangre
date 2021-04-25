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
        public ServicioPaciente()
        {

        }
        public void borrar(int id)
        {
            throw new NotImplementedException();
        }

        public bool existe(PacienteEditDto pacienteEditDto)
        {
            throw new NotImplementedException();
        }

        public PacienteEditDto getInstitucionPorID(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
