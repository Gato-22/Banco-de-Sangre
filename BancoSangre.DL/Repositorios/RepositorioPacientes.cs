using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Pacientes;
using BancoSangre.DL.Repositorios.Facades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios
{
    public class RepositorioPacientes :IRepositorioPacientes
    {
        private readonly SqlConnection _conexion;
        private readonly IRepositorioInstituciones _insti;
        private readonly IRepositorioLocalidades _loca;
        private readonly IRepositorioProvincias _provi;
        public RepositorioPacientes(SqlConnection conexion)
        {
            _conexion = conexion;
            
        }

        public void borrar(int pacienteid)
        {
            try
            {
                string cadenaComando = "DELETE FROM Pacientes WHERE DonanteID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", pacienteid);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                if (e.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Registro con datos asociados... Baja denega2");
                }
                throw new Exception(e.Message);
            }
        }

        public bool existe(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public PacienteEditDto GetclientePorId(int PacienteID)
        {
            throw new NotImplementedException();
        }

        public List<PacienteListDto> GetLista()
        {
            List<PacienteListDto> lista = new List<PacienteListDto>();
            try
            {
                string cadenaComando = "SELECT DonanteID, Nombre,Apellido,NombreLocalidad,NombreProvincia,Grupo, Denominacion, p.Direccion from Pacientes p inner join Localidades l on p.LocalidadID=l.LocalidadID inner join Provincias pr on p.ProvinciaID=pr.ProvinciaID inner join GruposSanguineos g on p.GrupoSanguineoID=g.GrupoSanguineoID inner join Instituciones ins on p.InstitucionID=ins.InstitucionID";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var pacienteListDto = ConstruirPacienteListDto(reader);
                    lista.Add(pacienteListDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar men");
            }
        }

        public void guardar(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        private PacienteListDto ConstruirPacienteListDto(SqlDataReader reader)
        {
            return new PacienteListDto
            {
                DonanteID = reader.GetInt32(0),
                NombreDonante = reader.GetString(1),
                ApellidoDonante = reader.GetString(2),
                localidad = reader.GetString(3),
                provincia = reader.GetString(4),
                tipoSangre = reader.GetString(5),
                institucion=reader.GetString(6)
            };
        }
    }
}
