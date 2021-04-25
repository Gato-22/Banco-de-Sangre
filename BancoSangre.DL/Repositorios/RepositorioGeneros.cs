using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Generos;
using BancoSangre.DL.Repositorios.Facades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios
{
    public class RepositorioGeneros : IRepositorioGeneros
    {
        private readonly SqlConnection _conexion;
        public RepositorioGeneros(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public void Borar(int id)
        {
            try
            {
                string cadenaComando = "DELETe from Generos where GeneroID=@ID";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
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

        public bool existe(Genero genero)
        {
            if (genero.GeneroID == 0)
            {
                string cadenaComando = "SELECT GeneroID, Descripcion FROM Generos WHERE Descripcion=@nom";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", genero.GeneroDescripcion);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT GeneroID, Descripcion FROM Generos WHERE Descripcion=@nom AND GeneroID<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", genero.GeneroDescripcion);
                comando.Parameters.AddWithValue("@id", genero.GeneroID);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
        }

        public GeneroEditDto GetGeneroPorID(int id)
        {
            GeneroEditDto genero = null;
            try
            {
                string cadenaComando =
                    "SELECT GeneroID, Descripcion FROM Generos WHERE GeneroID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    genero = ConstruirGeneroEditDto(reader);
                }
                reader.Close();
                return genero;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer las ciudades");
            }
        }

        public List<GeneroListDto> GetGeneros()
        {
            List<GeneroListDto> lista = new List<GeneroListDto>();
            try
            {
                string cadenaComando = "select GeneroId, Descripcion from Generos";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    GeneroListDto genero = ConstruirGeneroListDto(reader);
                    lista.Add(genero);

                }
                reader.Close();
                return lista;

            }
            catch (Exception)
            { 
                throw new Exception("Error al intentar we");
            }
        }

        private GeneroListDto ConstruirGeneroListDto(SqlDataReader reader)
        {
            return new GeneroListDto
            {
                GeneroID = reader.GetInt32(0),
                GeneroDescripcion = reader.GetString(1)
            };
        }

        private GeneroEditDto ConstruirGeneroEditDto(SqlDataReader reader)
        {
            return new GeneroEditDto
            {
                GeneroID = reader.GetInt32(0),
                GeneroDescripcion = reader.GetString(1)
            };
        }

        public void Guardar(Genero genero)
        {
            if (genero.GeneroID == 0)
            {
                try
                {
                    string cadenaComando = "Insert Into Generos Values(@Nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@Nombre", genero.GeneroDescripcion);
                    comando.ExecuteNonQuery();
                    cadenaComando = "select @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    genero.GeneroID = (int)(decimal)comando.ExecuteScalar();
                }
                catch (Exception)
                {

                    throw new Exception("ojo llamar al programador (error guardar registro)");
                }

            }
            else
            {
                try
                {
                    string cadenacomando = "UPDATE Generos SET Descripcion=@Nombre where GeneroID=@ID";
                    SqlCommand comando = new SqlCommand(cadenacomando, _conexion);
                    comando.Parameters.AddWithValue("@Nombre", genero.GeneroDescripcion);
                    comando.Parameters.AddWithValue("@ID", genero.GeneroID);
                    comando.ExecuteNonQuery();

                }
                catch (Exception)
                {

                    throw new Exception("ojo llamar al programador (error al modificar registro)");
                }
            }
        }
    }
}
