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
            throw new NotImplementedException();
        }

        public bool existe(Genero genero)
        {
            throw new NotImplementedException();
        }

        public Genero GetGeneroPorID(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
