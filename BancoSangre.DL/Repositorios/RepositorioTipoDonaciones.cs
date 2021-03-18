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
    public class RepositorioTipoDonaciones : IRepositorioTipoDonaciones
    {
        private readonly SqlConnection _conexion;
        public RepositorioTipoDonaciones(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public void borrar(int id)
        {
            throw new NotImplementedException();
        }

        public bool existe(TipoDonacion tipoDonacion)
        {
            throw new NotImplementedException();
        }

        public TipoDonacion getTipoDonacionporID(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoDonacion> GetTipoDonacions()
        {
            List<TipoDonacion> lista = new List<TipoDonacion>();
            try
            {
                string cadenaComando = "select TipoDonacionID, Descripcion from TipoDeDonacion";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipoDonacion tipodonacion = ConstruirDonacion(reader);
                    lista.Add(tipodonacion);

                }
                reader.Close();
                return lista;

            }
            catch (Exception)
            {

                throw new Exception("Error al intentar we");
            }
        }

        private TipoDonacion ConstruirDonacion(SqlDataReader reader)
        {
            return new TipoDonacion
            {
                TipoDonacionID = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

        public void guardar(TipoDonacion tipoDonacion)
        {
            throw new NotImplementedException();
        }
    }
}
