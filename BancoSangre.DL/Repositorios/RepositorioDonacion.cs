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
        private  SqlConnection _conexion;
        private IRepositorioLocalidades _loca;
        private IRepositorioProvincias _provi;
        private IRepositorioGeneros _genero;
        private IRepositorioDocumentos _documento;
        private IRepositorioTipoSangre _tipoSangre;
        private IRepositorioInstituciones _insti;
        private  IRepositorioDonante _repositorioDonante;
        private  IRepositorioPacientes _repositorioPaciente;
        private  IRepositorioTipoDonaciones _repositorioTipoDonaciones;
        private SqlTransaction sqlTransaction;
        public RepositorioDonacion(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public RepositorioDonacion(SqlConnection conexion,SqlTransaction sqlTransaction)
        {
            _conexion = conexion;
            this.sqlTransaction = sqlTransaction;
        }
        public RepositorioDonacion(SqlConnection sqlConnection, IRepositorioDonante Donante, IRepositorioPacientes Paciente, IRepositorioTipoDonaciones TipoDonaciones)
        {
            this._conexion = sqlConnection;
            _repositorioDonante = Donante;
            _repositorioPaciente = Paciente;
            _repositorioTipoDonaciones = TipoDonaciones;
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
            //string cadenaComando = "SELECT * FROM Donantes WHERE TipoDeDocumentoId=@doc and NroDocumento=@nro";
            if (donacion.DonacionId == 0)
            {
                
               
                string cadenaComando = "SELECT * FROM Donaciones WHERE Identificacion=@Identificacion";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@Identificacion", donacion.Identificacion);
                
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                //string cadenaComando = "SELECT * FROM Donantes WHERE TipoDeDocumentoId=@doc and NroDocumento=@nro AND DonanteID<>@DonanteID";
                string cadenaComando = "SELECT * FROM Donaciones WHERE Identificacion=@Identificacion and DonacionID=@DonacionID";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@Identificacion", donacion.Identificacion);
                comando.Parameters.AddWithValue("@DonacionID", donacion.DonacionId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
        }

        public List<Donacion> GetDonacion()
        {
            List<Donacion> lista = new List<Donacion>();
            try
            {
                string cadenaComando = "SELECT DonacionId, FechaDonacion,Cantidad,DonanteID,PacienteID,TipoDonacionID FROM Donaciones";
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

                throw new Exception("Error al intentar construir we");
            }
        }

        public Donacion GetDonacionPorID(int id)
        {
            Donacion donacion = null;
            try
            {
                string cadenaComando =
                    "SELECT DonacionId, FechaDonacion,Cantidad,DonanteID,PacienteID,TipoDonacionID FROM Donaciones WHERE DonacionId<>@id";
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
                throw new Exception("Error al intentar leer Las donaciones");
            }
        }

        private Donacion construirdonacion(SqlDataReader reader)
        {
            _genero = new RepositorioGeneros(_conexion);
            _documento = new RepositorioDocumentos(_conexion);
            _provi = new RepositorioProvincias(_conexion);
            _loca = new RepositorioLocalidad(_conexion,_provi);
            _insti = new RepositorioInstituciones(_conexion,_provi,_loca);
            _tipoSangre = new RepositorioTipoSangre(_conexion);
            _repositorioDonante = new RepositorioDonante(_conexion,_provi,_loca,_genero,_documento,_tipoSangre);
            _repositorioPaciente = new RepositorioPacientes(_conexion, _provi, _loca,_insti, _genero, _documento,_tipoSangre);
            _repositorioTipoDonaciones = new RepositorioTipoDonaciones(_conexion);

            //return new Donacion
            //{
            //    DonacionId = reader.GetInt32(0),
            //    FechaDonacion = reader.GetDateTime(1),
            //    Cantidad=reader.GetInt32(2),
            //    Donante=_repositorioDonante.getDonantePorId(reader.GetInt32(3)),
            //    Paciente=_repositorioPaciente.getPacientePorID(reader.GetInt32(4)),
            //    TipoDonacion=_repositorioTipoDonaciones.getTipoDonacionporID(reader.GetInt32(5))


            //};
            var donacion = new Donacion();

            donacion.DonacionId = reader.GetInt32(0);
            donacion.FechaDonacion = reader.GetDateTime(1);
            donacion.Cantidad = reader.GetInt32(2);
            donacion.Donante = _repositorioDonante.getDonantePorId(reader.GetInt32(3));
            donacion.Paciente = _repositorioPaciente.getPacientePorID(reader.GetInt32(4));
            donacion.TipoDonacion = _repositorioTipoDonaciones.getTipoDonacionporID(reader.GetInt32(5));
            return donacion;

        }

        public void guardar(Donacion donacion)
        {
            if (donacion.DonacionId == 0)
            {
                try
                {
                    string cadenaComando = "Insert Into Donaciones(FechaDonacion, Cantidad, DonanteID, PacienteID, TipoDonacionID) Values(@FechaDonacion,@Cantidad,@DonanteID,@PacienteID,@TipoDonacionID)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion,sqlTransaction);
                    comando.Parameters.AddWithValue("@FechaDonacion", donacion.FechaDonacion);
                    comando.Parameters.AddWithValue("@Cantidad", donacion.Cantidad);
                    comando.Parameters.AddWithValue("@DonanteID", donacion.Donante.DonanteID);
                    comando.Parameters.AddWithValue("@PacienteID", donacion.Paciente.PacienteID);
                    comando.Parameters.AddWithValue("@TipoDonacionID", donacion.TipoDonacion.TipoDonacionID);
                    comando.ExecuteNonQuery();
                    cadenaComando = "select @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion,sqlTransaction);
                    donacion.DonacionId = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception gfd)
                {

                    throw new Exception("ojo llamar al programador (error guardar registro)");
                }

            }
            //else
            //{
            //    try
            //    {
            //        string cadenacomando = "UPDATE Donaciones SET FechaDonacion=@FechaDonacion, Identificacion=@Identificacion, FechaIngreso=@FechaIngreso, Vencimiento=@Vencimiento," +
            //            " Cantidad=@Cantidad,DonanteID=@DonanteID where DonacionId=@ID";
            //        SqlCommand comando = new SqlCommand(cadenacomando, _conexion);
            //        comando.Parameters.AddWithValue("@FechaDonacion", donacion.FechaDonacion);
            //        comando.Parameters.AddWithValue("@Identificacion", donacion.Identificacion);               
            //        comando.Parameters.AddWithValue("@FechaIngreso", donacion.FechaIngreso);
            //        comando.Parameters.AddWithValue("@Vencimiento", donacion.vencimiento);
            //        comando.Parameters.AddWithValue("@Cantidad", donacion.Cantidad);

            //        comando.Parameters.AddWithValue("@ID", donacion.DonacionId);
            //        comando.ExecuteNonQuery();

            //    }
            //    catch (Exception)
            //    {

            //        throw new Exception("ojo llamar al programador (error al modificar registro)");
            //    }
            //}
        }
    }
}
