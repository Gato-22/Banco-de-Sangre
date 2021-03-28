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
            throw new NotImplementedException();
        }

        public bool editar(TipoSangre tipoSangre)
        {
            throw new NotImplementedException();
        }

        public TipoSangre GetTipoSangrePorID(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
