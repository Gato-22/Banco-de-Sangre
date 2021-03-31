using BancoSangre.BL.Entidades;
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

        public Genero GetGeneroPorID(int id)
        {
            Genero genero = null;
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
                    genero = ConstruirGenero(reader);
                }
                reader.Close();
                return genero;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer las ciudades");
            }
        }

        public List<Genero> GetGeneros()
        {
            List<Genero> lista = new List<Genero>();
            try
            {
                string cadenaComando = "select GeneroId, Descripcion from Generos";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Genero genero = ConstruirGenero(reader);
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

        private Genero ConstruirGenero(SqlDataReader reader)
        {
            return new Genero
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
