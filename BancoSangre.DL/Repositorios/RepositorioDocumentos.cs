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
    public class RepositorioDocumentos : IRepositorioDocumentos
    {
        private readonly SqlConnection _conexion;
        public RepositorioDocumentos(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public void borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETe from TiposDeDocumento where TipoDeDocumentoID=@ID";
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


        public bool existe(Documento documento)
        {
            if (documento.TipoDocumentoID == 0)
            {
                string cadenaComando = "SELECT TipoDeDocumentoID, Descripcion FROM TiposDeDocumento WHERE Descripcion=@nom";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", documento.Descripcion);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT TipoDeDocumentoID, descripcion FROM tiposDeDocumento WHERE Descripcion=@nom AND TipoDeDocumentoID<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", documento.Descripcion);
                comando.Parameters.AddWithValue("@id", documento.TipoDocumentoID);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
        }

        public Documento GetDocumentoPorID(int id)
        {
            Documento documento = null;
            try
            {
                string cadenaComando =
                    "SELECT TipoDeDocumentoID, Descripcion FROM TiposDeDocumento WHERE TipoDeDocumentoID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    documento = COnstruirDocumento(reader);
                }
                reader.Close();
                return documento;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer las ciudades");
            }
        }

        public List<Documento> GetDocumentos()
        {
            List<Documento> lista = new List<Documento>();
            try
            {
                string cadenaComando = "select TipoDeDocumentoID, Descripcion from TiposDeDocumento";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Documento documento = COnstruirDocumento(reader);
                    lista.Add(documento);

                }
                reader.Close();
                return lista;

            }
            catch (Exception)
            {
                throw new Exception("Error al intentar we");
            }
        }

        private Documento COnstruirDocumento(SqlDataReader reader)
        {
            return new Documento
            {
                TipoDocumentoID = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

        public void Guardar(Documento documento)
        {
            if (documento.TipoDocumentoID == 0)
            {
                try
                {
                    string cadenaComando = "Insert Into TiposDeDocumento Values(@Nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@Nombre", documento.Descripcion);
                    comando.ExecuteNonQuery();
                    cadenaComando = "select @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    documento.TipoDocumentoID = (int)(decimal)comando.ExecuteScalar();
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
                    string cadenacomando = "UPDATE TiposDeDocumento SET Descripcion=@Nombre where TipoDeDocumentoID=@ID";
                    SqlCommand comando = new SqlCommand(cadenacomando, _conexion);
                    comando.Parameters.AddWithValue("@Nombre", documento.Descripcion);
                    comando.Parameters.AddWithValue("@ID", documento.TipoDocumentoID);
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
