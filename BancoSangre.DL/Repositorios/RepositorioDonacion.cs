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
    public class RepositorioDonacion : IRepositorioDonacion
    {
        private readonly SqlConnection _conexion;
        public RepositorioDonacion(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public void borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETe from Donaciones where DonacionId=@ID";
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

        public bool existe(Donacion donacion)
        {
            if (donacion.DonacionId == 0)
            {
                string cadenaComando = "SELECT DonacionId, FechaDonacion,Identificacion,FechaIngreso,Vencimiento,Cantidad FROM Donaciones WHERE FechaDonacion=@nom and Identificacion=@N and FechaIngreso=@NO and "+
                    "Vencimiento=@nomb and Cantidad=@Nombr";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@N", donacion.Identificacion);
                comando.Parameters.AddWithValue("@NO", donacion.FechaIngreso);
                comando.Parameters.AddWithValue("@nom", donacion.FechaDonacion);
                comando.Parameters.AddWithValue("@nomb", donacion.vencimiento);
                comando.Parameters.AddWithValue("@Nombr", donacion.Cantidad);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT DonacionId, FechaDonacion,Identificacion,FechaIngreso,Vencimiento,Cantidad FROM Donaciones WHERE FechaDonacion=@nom and Identificacion=@N and FechaIngreso=@NO and " +
                    "Vencimiento=@nomb and Cantidad=@Nombr AND DonacionId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@N", donacion.Identificacion);
                comando.Parameters.AddWithValue("@NO", donacion.FechaIngreso);
                comando.Parameters.AddWithValue("@nom", donacion.FechaDonacion);
                comando.Parameters.AddWithValue("@nomb", donacion.vencimiento);
                comando.Parameters.AddWithValue("@Nombr", donacion.Cantidad);
                comando.Parameters.AddWithValue("@id", donacion.DonacionId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
        }

        public List<Donacion> GetDonacion()
        {
            List<Donacion> lista = new List<Donacion>();
            try
            {
                string cadenaComando = "SELECT DonacionId, FechaDonacion,Identificacion,FechaIngreso,Vencimiento,Cantidad FROM Donaciones";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Donacion donacion = construirdonacion(reader);
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

        public Donacion GetDonacionPorID(int id)
        {
            Donacion donacion = null;
            try
            {
                string cadenaComando =
                    "SELECT DonacionId, FechaDonacion,Identificacion,FechaIngreso,Vencimiento,Cantidad FROM Donaciones WHERE DonacionId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    donacion = construirdonacion(reader);
                }
                reader.Close();
                return donacion;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer los tipos de sangre");
            }
        }

        private Donacion construirdonacion(SqlDataReader reader)
        {
            return new Donacion
            {
                DonacionId = reader.GetInt32(0),
                FechaDonacion = reader.GetDateTime(1),
                Identificacion = reader.GetString(2),
                FechaIngreso = reader.GetDateTime(3),
                vencimiento = reader.GetString(4),
                Cantidad=reader.GetInt32(5)
            };
        }

        public void guardar(Donacion donacion)
        {
            if (donacion.DonacionId == 0)
            {
                try
                {
                    string cadenaComando = "Insert Into Donaciones Values(@n, @no, @nom, @nomb, @Nombr)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@n", donacion.FechaIngreso);
                    comando.Parameters.AddWithValue("@no", donacion.Identificacion);
                    comando.Parameters.AddWithValue("@nom", donacion.FechaDonacion);
                    comando.Parameters.AddWithValue("@nomb", donacion.vencimiento);
                    comando.Parameters.AddWithValue("@Nombr", donacion.Cantidad);
                    comando.ExecuteNonQuery();
                    cadenaComando = "select @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    donacion.DonacionId = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenacomando = "UPDATE Donaciones SET FechaDonacion=@FechaDonacion, Identificacion=@Identificacion, FechaIngreso=@FechaIngreso, Vencimiento=@Vencimiento, Cantidad=@Cantidad where DonacionId=@ID";
                    SqlCommand comando = new SqlCommand(cadenacomando, _conexion);
                    comando.Parameters.AddWithValue("@FechaDonacion", donacion.FechaDonacion);
                    comando.Parameters.AddWithValue("@Identificacion", donacion.Identificacion);               
                    comando.Parameters.AddWithValue("@FechaIngreso", donacion.FechaIngreso);
                    comando.Parameters.AddWithValue("@Vencimiento", donacion.vencimiento);
                    comando.Parameters.AddWithValue("@Cantidad", donacion.Cantidad);

                    comando.Parameters.AddWithValue("@ID", donacion.DonacionId);
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
