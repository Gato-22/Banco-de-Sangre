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
    public class RepositorioProvincias : IRepositorioProvincias
    {
        private readonly SqlConnection _conexion;
        public RepositorioProvincias(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public void borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETe from Provincias where ProvinciaID=@ID";
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

        public bool existe(Provincia provincia)
        {
            if (provincia.ProvinciaID==0)
            {
                string cadenaComando = "SELECT ProvinciaId, NombreProvincia FROM Provincias WHERE NombreProvincia=@nom";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", provincia.NombreProvincia);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT ProvinciaID, NombreProvincia FROM Provincias WHERE NombreProvincia=@nom AND ProvinciaID<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", provincia.NombreProvincia);
                comando.Parameters.AddWithValue("@id", provincia.ProvinciaID);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
        }

        public Provincia GetProvinciaPorID(int id)
        {
            Provincia provincia = null;
            try
            {
                string cadenaComando =
                    "SELECT provinciaID, nombreprovincia FROM provincias WHERE localidadId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    provincia = ConstruirProvincia(reader);
                }
                reader.Close();
                return provincia;
            }
            catch (Exception )
            {
                throw new Exception("Error al intentar leer las ciudades");
            }
        }

        public List<Provincia> GetProvincias()
        {
            List<Provincia> lista = new List<Provincia>();
            try
            {
                string cadenaComando= "select provinciaId, NombreProvincia from Provincias";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Provincia provincia = ConstruirProvincia(reader);
                    lista.Add(provincia);

                }
                reader.Close();
                return lista;

            }
            catch (Exception)
            {

                throw new Exception("Error al intentar we");
            }
        }

        private Provincia ConstruirProvincia(SqlDataReader reader)
        {
            return new Provincia
            {
                ProvinciaID = reader.GetInt32(0),
                NombreProvincia = reader.GetString(1)
            };
        }    

        
        public void Guardar(Provincia provincia)
        {
            if (provincia.ProvinciaID==0)
            {
                try
                {
                    string cadenaComando = "Insert Into Provincias Values(@Nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@Nombre", provincia.NombreProvincia);
                    comando.ExecuteNonQuery();
                    cadenaComando = "select @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    provincia.ProvinciaID = (int)(decimal)comando.ExecuteScalar();
                }
                catch (Exception) 
                {
                    
                    throw new Exception( "ojo llamar al programador (error guardar registro)");
                }

            }
            else
            {
                try
                {
                    string cadenacomando = "UPDATE provincias SET nombreprovincia=@Nombre where ProvinciaID=@ID";
                    SqlCommand comando = new SqlCommand(cadenacomando, _conexion);
                    comando.Parameters.AddWithValue("@Nombre", provincia.NombreProvincia);
                    comando.Parameters.AddWithValue("@ID", provincia.ProvinciaID);
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
