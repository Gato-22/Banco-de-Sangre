using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Localidad;
using BancoSangre.DL.Repositorios.Facades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios
{
    public class RepositorioLocalidad : IRepositorioLocalidades
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IRepositorioProvincias _repositorioProvincias;
        public RepositorioLocalidad(SqlConnection sqlConnection, IRepositorioProvincias repositorioProvincias)
        {
            _sqlConnection = sqlConnection;
            _repositorioProvincias = repositorioProvincias;
        }
        public RepositorioLocalidad(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public void borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETe from localidades where LocalidadID=@ID";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@ID", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                if (e.Message.Contains("REFERENCE"))
                {
                    throw new Exception("registro con vinculos, eliminacion denega3");
                }
                throw new Exception(e.Message);

            }
        }

        public bool existe(Localidad localidad)
        {
            try
            {
                if (localidad.LocalidadID == 0)
                {
                    string cadenaComando = "SELECT * FROM localidades WHERE Nombrelocalidad=@nomb AND provinciaID=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@Nomb", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("Id", localidad.provincia.ProvinciaID);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
                else
                {
                    string cadenaComando = "SELECT * FROM localidades WHERE Nombrelocalidad=@nomb AND ProvinciaId=@id AND localidadId<>@localidadId";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@Nomb", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@Id", localidad.provincia.ProvinciaID);
                    comando.Parameters.AddWithValue("@LocalidadID", localidad.LocalidadID);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;

                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<LocalidadListDto> GetLista()
        {
            List<LocalidadListDto> lista = new List<LocalidadListDto>();
            try
            {   
                string cadenacomando = "SELECT LocalidadID, NombreLocalidad, nombreProvincia From Localidades inner join Provincias ON Localidades.ProvinciaID=Provincias.ProvinciaID";
                SqlCommand comando = new SqlCommand(cadenacomando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var localidadDto = ConstruirLocalidadDto(reader);
                    lista.Add(localidadDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception )
            {

                throw new Exception("error al intentar leer localidades");
            }
        }

        public LocalidadEditDto GetlocalidadPorId(int id)
        {
            LocalidadEditDto localidad = null;
            try
            {
                string cadenaComando =
                "SELECT LocalidadID, NombreLocalidad,ProvinciaID FROM Localidades WHERE LocalidadID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    localidad = construirLocalidad(reader);
                }
                reader.Close();
                return localidad;
            }
            catch (Exception )
            {
                throw new Exception("Error al intentar leer las ciudades");
            }
        }

        private LocalidadEditDto construirLocalidad(SqlDataReader reader)
                    {
            var localidad = new LocalidadEditDto();
            localidad.LocalidadID = reader.GetInt32(0);
            localidad.NombreLocalidad = reader.GetString(1);
            localidad.Provinciaid = reader.GetInt32(2);
            return localidad;
        }

        public void guardar(Localidad localidad)
        {
            if (localidad.LocalidadID==0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Localidades VALUES(@nombre, @localidadId)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@localidadId", localidad.provincia.ProvinciaID);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    localidad.LocalidadID = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception)
                {
                    throw new Exception("error, llame al programador");
                }
            }
            else
            {
                
                try
                {
                    string cadenaComando = "UPDATE Localidades SET NombreLocalidad=@nombre, ProvinciaId=@paisId WHERE LocalidadId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@paisId", localidad.provincia.ProvinciaID);

                    comando.Parameters.AddWithValue("@id", localidad.LocalidadID);
                    comando.ExecuteNonQuery();

                }
                catch (Exception )
                {
                    throw new Exception("Ojo llamar a Prrogramador");
                }
            }
            
        }

        private LocalidadListDto ConstruirLocalidadDto(SqlDataReader reader)
        {
            LocalidadListDto localidaddto = new LocalidadListDto();
            localidaddto.LocalidadID = reader.GetInt32(0);
            localidaddto.NombreLocalidad = reader.GetString(1);
            localidaddto.NombreProvincia = reader.GetString(2);
            return localidaddto;
        }
    }
}
