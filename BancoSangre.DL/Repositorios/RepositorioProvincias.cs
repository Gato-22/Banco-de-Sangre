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
            throw new NotImplementedException();
        }

        public bool existe(Provincia provincia)
        {
            throw new NotImplementedException();
        }

        public Provincia GetProvinciaPorID(int id)
        {
            throw new NotImplementedException();
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
            catch (Exception e)
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

        private Donante ConstruirDonante(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }


        public void Guardar(Provincia provincia)
        {
            throw new NotImplementedException();
        }
    }
}
