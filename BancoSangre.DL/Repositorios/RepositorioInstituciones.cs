using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Institucion;
using BancoSangre.BL.Entidades.DTO.Localidad;
using BancoSangre.BL.Entidades.DTO.Provincia;
using BancoSangre.DL.Repositorios.Facades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.DL.Repositorios
{
    public class RepositorioInstituciones : IRepositorioInstituciones
    {

        private readonly SqlConnection _sqlConnection;
        private readonly IRepositorioLocalidades _repositorioLocalidades;
        private readonly IRepositorioProvincias _repositorioProvincias;
        public RepositorioInstituciones(SqlConnection sqlConnection,IRepositorioProvincias repositorioProvincias, IRepositorioLocalidades epositorioLocalidades)
        {
            this._sqlConnection = sqlConnection ;
            _repositorioProvincias = repositorioProvincias;
            _repositorioLocalidades = epositorioLocalidades;
        }
        public RepositorioInstituciones(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public void borrar(int institucionid)
        {
            try
            {
                string cadenaComando = "DELETE FROM Instituciones WHERE InstitucionID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", institucionid);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                if (e.Message.Contains("referenc"))
                {
                    throw new Exception("Registro con datos asociados, Baja denega3");
                }
                throw new Exception(e.Message);
            }
        }

        public bool existe(Institucion institucion)
        {
            try
            {
                if (institucion.InstitucionID == 0)
                {
                    string cadenaComando = "SELECT * FROM Instituciones WHERE Denominacion=@nomb";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nomb", institucion.Denominacion);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
                else
                {
                    string cadenaComando = "SELECT * FROM Instituciones WHERE Denominacion=@nomb AND InstitucionID<>@InstitucionID";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nomb", institucion.Denominacion);
                    comando.Parameters.AddWithValue("@InstitucionId", institucion.InstitucionID);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;

                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public InstitucionEditdto GetInstitucionPorID(int id)
        {
            InstitucionEditdto insti = null;
            try
            {
                string cadenacomando = "select InstitucionID,Denominacion,Direccion,LocalidadID,ProvinciaID,TelefonoFijo,TelefonoMovil,CorreoElectronico from Instituciones where InstitucionID=@id";
                SqlCommand comando = new SqlCommand(cadenacomando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    insti = construirInstitucionEditdto(reader);
                }
                reader.Close();
                return insti;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer el instituciones");
            }
        }

        private InstitucionEditdto construirInstitucionEditdto(SqlDataReader reader)
        {
            var provinciaEditDto = _repositorioProvincias.GetProvinciaPorID(reader.GetInt32(3));
            var localidadEditDto = _repositorioLocalidades.GetlocalidadPorId(reader.GetInt32(4));
            return new InstitucionEditdto
            {
                InstitucionID = reader.GetInt32(0),
                Denominacion = reader.GetString(1),
                Direccion = reader.GetString(2),
                provincia = new ProvinciaListDto { Provinciaid = provinciaEditDto.ProvinciaId, NombreProvincia = provinciaEditDto.NombreProvincia },
                localidad = new LocalidadListDto
                {
                    LocalidadID = localidadEditDto.LocalidadID,
                    NombreLocalidad = localidadEditDto.NombreLocalidad,
                    NombreProvincia = localidadEditDto.ProvinciaID.NombreProvincia
                },
                telefonoFijo = reader[5] != DBNull.Value ? reader.GetString(5) : string.Empty,
                telefonoMovil = reader[6] != DBNull.Value ? reader.GetString(6) : string.Empty,
                correoElectronico = reader[7] != DBNull.Value ? reader.GetString(7) : string.Empty

            };
        }

        public List<InstitucionListDto> GetLista()
        {
            List<InstitucionListDto> lista = new List<InstitucionListDto>();
            try
            {
                string cadenacomando = "select InstitucionID,Denominacion,Direccion,NombreLocalidad,NombreProvincia from Instituciones i inner join Provincias p on i.ProvinciaID=p.ProvinciaID inner join Localidades l on i.LocalidadID=l.LocalidadID";
                SqlCommand comando = new SqlCommand(cadenacomando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var institucionListDto = ConstruirInstitucionListDto(reader);
                    lista.Add(institucionListDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception)
            {

                throw new Exception("error al intentar leer las Instituciones");
            }
        }

        public void guardar(Institucion institucion)
        {
            if (institucion.InstitucionID == 0)
            {
                //Nuevo registro
                try
                {
                    string cadenaComando = "INSERT INTO Instituciones VALUES(@Denominacion, @Direccion, @LocalidadID, @ProvinciaId, @TelefonoFijo, @TelefonoMovil, @CorreoElectronico)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@denominacion", institucion.Denominacion);
                    comando.Parameters.AddWithValue("@Direccion", institucion.Direccion);
                    comando.Parameters.AddWithValue("@LocalidadID", institucion.localidad.LocalidadID);
                    comando.Parameters.AddWithValue("@ProvinciaId", institucion.provincia.ProvinciaID);
                    if (institucion.telefonoFijo != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", institucion.telefonoFijo);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", DBNull.Value);
                    }
                    if (institucion.telefonoMovil != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", institucion.telefonoMovil);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", DBNull.Value);
                    }
                    if (institucion.correoElectronico != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@CorreoElectronico", institucion.correoElectronico);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@CorreoElectronico", DBNull.Value);
                    }


                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    institucion.InstitucionID = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception )
                {
                    throw new Exception("Error al intentar guardar una institucion");
                }


            }
            else
            {
                //Edición
                try
                {
                    string cadenaComando = "UPDATE Instituciones SET Denominacion=@Denominacion, Direccion=@Direccion, LocalidadID=@LocalidadID, ProvinciaId=@ProvinciaId, TelefonoFijo=@TelefonoFijo, TelefonoMovil=@TelefonoMovil, CorreoElectronico=@CorreoElectronico WHERE InstitucionID=@InstitucionID";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@Denominacion", institucion.Denominacion);
                    comando.Parameters.AddWithValue("@Direccion", institucion.Direccion);
                    comando.Parameters.AddWithValue("@LocalidadID", institucion.localidad.LocalidadID);
                    comando.Parameters.AddWithValue("@ProvinciaId", institucion.provincia.ProvinciaID);
                    if (institucion.telefonoFijo != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", institucion.telefonoFijo);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", DBNull.Value);
                    }
                    if (institucion.telefonoMovil != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", institucion.telefonoMovil);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", DBNull.Value);
                    }                   
                    if (institucion.correoElectronico != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@CorreoElectronico", institucion.correoElectronico);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@CorreoElectronico", DBNull.Value);
                    }
                    comando.Parameters.AddWithValue("@InstitucionID", institucion.InstitucionID);
                    comando.ExecuteNonQuery();
                }
                catch (Exception )
                {
                    throw new Exception("Error al intentar editar una Institucion");
                }

            }
        }

        private InstitucionListDto ConstruirInstitucionListDto(SqlDataReader reader)
        {
            return new InstitucionListDto
            {
                InstitucionID = reader.GetInt32(0),
                Denominacion = reader.GetString(1),
                Direccion = reader.GetString(2),
                localidad = reader.GetString(3),
                provincia = reader.GetString(4)             
            };
        }
    }
}
