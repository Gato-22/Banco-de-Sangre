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
    public class RepositorioTipoSangre : IRepositorioTipoSangre
    {
        private readonly SqlConnection _conexion;
        public RepositorioTipoSangre(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public void borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETe from GruposSanguineos where GrupoSanguineoID=@ID";
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

        public bool existe(TipoSangre tipoSangre)
        {
            if (tipoSangre.GrupoSanguineoID == 0)
            {
                string cadenaComando = "SELECT GrupoSanguineoID, Grupo, Factor FROM GruposSanguineos WHERE Grupo=@nom and factor=@nomb";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", tipoSangre.Grupo);
                comando.Parameters.AddWithValue("@nomb", tipoSangre.Factor);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT GrupoSanguineoID, Grupo, Factor FROM GruposSanguineos WHERE Grupo=@nom and factor=@nomb AND GrupoSanguineoID<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", tipoSangre.Grupo);
                comando.Parameters.AddWithValue("@nomb", tipoSangre.Factor);
                comando.Parameters.AddWithValue("@id", tipoSangre.GrupoSanguineoID);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
        }

        public TipoSangre GetTipoSangrePorID(int id)
        {
           TipoSangre tipoSangre = null;
            try
            {
                string cadenaComando =
                    "SELECT GrupoSanguineoID, Grupo, Factor FROM GruposSanguineos WHERE GrupoSanguineoID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    tipoSangre = ConstruirTipoSangre(reader);
                }
                reader.Close();
                return tipoSangre;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer los tipos de sangre");
            }
        }

        public List<TipoSangre> GetTipoSangres()
        {
            List<TipoSangre> lista = new List<TipoSangre>();
            try
            {
                string cadenaComando = "select GrupoSanguineoID, Grupo, Factor from GruposSanguineos";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipoSangre tipoSangre = ConstruirTipoSangre(reader);
                    lista.Add(tipoSangre);

                }
                reader.Close();
                return lista;

            }
            catch (Exception)
            {

                throw new Exception("Error al intentar we");
            }
        }

        private TipoSangre ConstruirTipoSangre(SqlDataReader reader)
        {
            return new TipoSangre
            {
                GrupoSanguineoID = reader.GetInt32(0),
                Grupo = reader.GetString(1),
                Factor = reader.GetString(2)
            };
        }

        public void guardar(TipoSangre tipoSangre)
        {
            if (tipoSangre.GrupoSanguineoID == 0)
            {
                try
                {
                    string cadenaComando = "Insert Into GruposSanguineos Values(@Nombre, @nom)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@Nombre", tipoSangre.Grupo);
                    comando.Parameters.AddWithValue("@nom", tipoSangre.Factor);
                    comando.ExecuteNonQuery();
                    cadenaComando = "select @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    tipoSangre.GrupoSanguineoID = (int)(decimal)comando.ExecuteScalar();
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
                    string cadenacomando = "UPDATE GruposSanguineos SET Grupo=@grupo, Factor=@factor where GrupoSanguineoID=@ID";
                    SqlCommand comando = new SqlCommand(cadenacomando, _conexion);
                    comando.Parameters.AddWithValue("@grupo", tipoSangre.Grupo);
                    comando.Parameters.AddWithValue("@factor", tipoSangre.Factor);
                    comando.Parameters.AddWithValue("@ID", tipoSangre.GrupoSanguineoID);
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
