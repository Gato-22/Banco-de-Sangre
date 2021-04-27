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
    public class RepositorioDonacionAutomatizada : IRepositorioDonacionAutomatizada
    {
        private readonly SqlConnection _conexion;
        private SqlTransaction transaction;
        public RepositorioDonacionAutomatizada(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public RepositorioDonacionAutomatizada(SqlConnection conexion,SqlTransaction transaction)
        {
            _conexion = conexion;
            this.transaction = transaction;
        }
        public void borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETe from TipoDeDonacionAutomatizada where TipoID=@ID";
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

        public bool existe(DonacionAutomatizada donacion)
        {
            if (donacion.DonacionAutoID == 0)
            {
                string cadenaComando = "SELECT TipoID, Descripcion, IntervaloDonacionEnDias FROM TipoDeDonacionAutomatizada WHERE Descripcion=@nom and IntervaloDonacionEnDias=@nomb";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", donacion.Descripcion);
                comando.Parameters.AddWithValue("@nomb", donacion.Intervalo);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT TipoID, Descripcion, intervaloDonacionEnDias FROM TipoDeDonacionAutomatizada WHERE Descripcion=@nom and fIntervaloDonacionEnDias=@nomb AND TipoID<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", donacion.Descripcion);
                comando.Parameters.AddWithValue("@nomb", donacion.Intervalo);
                comando.Parameters.AddWithValue("@id", donacion.DonacionAutoID);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
        }

        public List<DonacionAutomatizada> GetDonacions()
        {
            List<DonacionAutomatizada> lista = new List<DonacionAutomatizada>();
            try
            {
                string cadenaComando = "SELECT TipoID, Descripcion, intervaloDonacionEnDias FROM TipoDeDonacionAutomatizada";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    DonacionAutomatizada donacion = construirDonacion(reader);
                    lista.Add(donacion);

                }
                reader.Close();
                return lista;

            }
            catch (Exception)
            {

                throw new Exception("Error al intentar we");
            }
        }

        public DonacionAutomatizada GetTipoDonacionAutoPorID(int id)
        {
            DonacionAutomatizada donacion = null;
            try
            {
                string cadenaComando =
                    "SELECT TipoID, Descripcion, IntervaloDonacionEnDias FROM TipoDeDonacionAutomatizada WHERE TipoID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    donacion = construirDonacion(reader);
                }
                reader.Close();
                return donacion;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer el tipo de donaciones automatizadas");
            }
        }

        private DonacionAutomatizada construirDonacion(SqlDataReader reader)
        {
            return new DonacionAutomatizada
            {
                DonacionAutoID = reader.GetInt32(0),
                Descripcion = reader.GetString(1),
                Intervalo = reader.GetInt32(2)
            };
        }

        public void guardar(DonacionAutomatizada dona)
        {
            if (dona.DonacionAutoID == 0)
            {
                try
                {
                    string cadenaComando = "Insert Into TipoDeDonacionAutomatizada Values(@Nombre, @nom)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion,transaction);
                    comando.Parameters.AddWithValue("@Nombre", dona.Descripcion);
                    comando.Parameters.AddWithValue("@nom", dona.Intervalo);
                    comando.ExecuteNonQuery();
                    cadenaComando = "select @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion,transaction);
                    dona.DonacionAutoID = (int)(decimal)comando.ExecuteScalar();
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
                    string cadenacomando = "UPDATE TipoDeDonacionAutomatizada SET Descripcion=@descripcion, IntervaloDonacionEnDias=@Inter where TipoID=@ID";
                    SqlCommand comando = new SqlCommand(cadenacomando, _conexion,transaction);
                    comando.Parameters.AddWithValue("@descripcion",dona.Descripcion);
                    comando.Parameters.AddWithValue("@Inter", dona.Intervalo);
                    comando.Parameters.AddWithValue("@ID", dona.DonacionAutoID);
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
