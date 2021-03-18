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
            throw new NotImplementedException();
        }

        public bool existe(Documento documento)
        {
            throw new NotImplementedException();
        }

        public Documento GetDocumentoPorID(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
