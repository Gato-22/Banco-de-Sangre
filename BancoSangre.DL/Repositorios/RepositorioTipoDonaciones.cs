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
            try
            {
                string cadenaComando = "DELETe from TipoDeDonacion where TipoDonacionID=@ID";
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

        public bool existe(TipoDonacion tipoDonacion)
        {
            if (tipoDonacion.TipoDonacionID == 0)
            {
                string cadenaComando = "SELECT TipoDonacionID, Descripcion FROM TipoDeDonacion WHERE Descripcion=@nom";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", tipoDonacion.Descripcion);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT TipoDonacionID, descripcion FROM tipoDeDonacion WHERE Descripcion=@nom AND TipoDonacionID<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", tipoDonacion.Descripcion);
                comando.Parameters.AddWithValue("@id", tipoDonacion.TipoDonacionID);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
        }

        public TipoDonacion getTipoDonacionporID(int id)
        {
            TipoDonacion tipoDonacion = null;
            try
            {
                string cadenaComando =
                    "SELECT TipoDonacionID, Descripcion FROM TiposDeDocumento WHERE TipoDeDocumentoID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    tipoDonacion = ConstruirDonacion(reader);
                }
                reader.Close();
                return tipoDonacion;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer el tipo de donacion");
            }
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
            if (tipoDonacion.TipoDonacionID == 0)
            {
                try
                {
                    string cadenaComando = "Insert Into TipoDeDonacion Values(@Nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@Nombre", tipoDonacion.Descripcion);
                    comando.ExecuteNonQuery();
                    cadenaComando = "select @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    tipoDonacion.TipoDonacionID= (int)(decimal)comando.ExecuteScalar();
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
                    string cadenacomando = "UPDATE TipoDeDonacion SET Descripcion=@Nombre where TipoDonacionID=@ID";
                    SqlCommand comando = new SqlCommand(cadenacomando, _conexion);
                    comando.Parameters.AddWithValue("@Nombre", tipoDonacion.Descripcion);
                    comando.Parameters.AddWithValue("@ID", tipoDonacion.TipoDonacionID);
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
