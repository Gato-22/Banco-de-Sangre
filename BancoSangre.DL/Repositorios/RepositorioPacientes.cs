using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Documentos;
using BancoSangre.BL.Entidades.DTO.Generos;
using BancoSangre.BL.Entidades.DTO.Pacientes;
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
    public class RepositorioPacientes :IRepositorioPacientes
    {
        private readonly SqlConnection _conexion;
        private readonly IRepositorioInstituciones _insti;
        private readonly IRepositorioLocalidades _loca;
        private readonly IRepositorioProvincias _provi;
        private readonly IRepositorioGeneros _genero;
        private readonly IRepositorioDocumentos _documento;
        private readonly IRepositorioTipoSangre _tipoSangre;
        public RepositorioPacientes(SqlConnection sqlConnection, IRepositorioProvincias repositorioProvincias, IRepositorioLocalidades epositorioLocalidades, IRepositorioInstituciones repositorioInstituciones,IRepositorioGeneros repositorioGeneros,IRepositorioDocumentos repositorioDocumentos, IRepositorioTipoSangre repositorioTipoSangre)
        {
            this._conexion = sqlConnection;
            _provi = repositorioProvincias;
            _loca = epositorioLocalidades;
            _insti = repositorioInstituciones;
            _genero = repositorioGeneros;
            _documento = repositorioDocumentos;
            _tipoSangre = repositorioTipoSangre;
        }
        public RepositorioPacientes(SqlConnection conexion)
        {
            _conexion = conexion;
            
        }

        public void borrar(int pacienteid)
        {
            try
            {
                string cadenaComando = "DELETE FROM Pacientes WHERE DonanteID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", pacienteid);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                if (e.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Registro con datos asociados... Baja denega2");
                }
                throw new Exception(e.Message);
            }
        }

        public bool existe(Paciente paciente)
        {
            try
            {
                if (paciente.PacienteID == 0)
                {
                    //editar esto
                    string cadenaComando = "SELECT * FROM Pacientes WHERE Nombre=@nomb";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nomb", paciente.NombrePaciente);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
                else
                {
                    string cadenaComando = "SELECT * FROM Pacientes WHERE Nombre=@nomb AND DonanteID<>@DonanteID";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nomb", paciente.NombrePaciente);
                    comando.Parameters.AddWithValue("@DonanteID", paciente.PacienteID);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;

                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public PacienteEditDto getPacientePorID(int PacienteID)
        {
            PacienteEditDto paciente = null;
            try
            {
                string cadenacomando = "select DonanteID,Nombre,Apellido,GeneroID,TipoDeDocumentoID,NroDocumento,Direccion,LocalidadID,ProvinciaID,TelefonoFijo,TelefonoMovil,CorreoElectronico,FechaNacimiento, GrupoSanguineoID, InstitucionID from Pacientes where DonanteID=@id";
                SqlCommand comando = new SqlCommand(cadenacomando, _conexion);
                comando.Parameters.AddWithValue("@id", PacienteID);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    paciente = ConstruirPacienteEditDto(reader);
                }
                reader.Close();
                return paciente;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer Los Pacientes");
            }
        }

        private PacienteEditDto ConstruirPacienteEditDto(SqlDataReader reader)
        {
            var generoEditDto = _genero.GetGeneroPorID(reader.GetInt32(3));
            var documentoEditDto = _documento.GetDocumentoPorID(reader.GetInt32(4));
            var localidadEditDto = _loca.GetlocalidadPorId(reader.GetInt32(7));
            var provinciaEditDto = _provi.GetProvinciaPorID(reader.GetInt32(8));
            var tipoSangreEditDto = _tipoSangre.GetTipoSangrePorID(reader.GetInt32(14));
            var institucionEditDto = _insti.GetInstitucionPorID(reader.GetInt32(15));
            return new PacienteEditDto
            {
                PacienteID = reader.GetInt32(0),
                NombrePaciente = reader.GetString(1),
                ApellidoPaciente = reader.GetString(2),
                //genero = new GeneroListDto { GeneroID = generoEditDto.GeneroID, GeneroDescripcion = generoEditDto.GeneroDescripcion },


                provincia = new ProvinciaListDto { Provinciaid = provinciaEditDto.ProvinciaId, NombreProvincia = provinciaEditDto.NombreProvincia },
                //documento = new DocumentoEditDto
                //{
                //    TipoDocumentoID = documentoEditDto.TipoDocumentoID, Descripcion = documentoEditDto.Descripcion
                //}
                //localidad = new localidadEditDto
                //{
                //    LocalidadID = localidadEditDto.LocalidadID,
                //    NombreLocalidad = localidadEditDto.NombreLocalidad,
                //    NombreProvincia = localidadEditDto.ProvinciaID.NombreProvincia
                //},
                //localidad = reader.GetString(3),
                //provincia = reader.GetString(4),
                //tipoSangre = reader.GetString(5),
                //institucion = reader.GetString(6)
            };
        }

        public List<PacienteListDto> GetLista()
        {
            List<PacienteListDto> lista = new List<PacienteListDto>();
            try
            {
                string cadenaComando = "SELECT DonanteID, Nombre,Apellido,NombreLocalidad,NombreProvincia,Grupo, Denominacion, p.Direccion from Pacientes p inner join Localidades l on p.LocalidadID=l.LocalidadID inner join Provincias pr on p.ProvinciaID=pr.ProvinciaID inner join GruposSanguineos g on p.GrupoSanguineoID=g.GrupoSanguineoID inner join Instituciones ins on p.InstitucionID=ins.InstitucionID";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var pacienteListDto = ConstruirPacienteListDto(reader);
                    lista.Add(pacienteListDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar men");
            }
        }

        public void guardar(Paciente paciente)
        {
            if (paciente.PacienteID == 0)
            {
                //Nuevo registro
                try
                {
                    string cadenaComando = "INSERT INTO Pacientes VALUES(@Nombre,@Apellido, @GeneroID,@TipoDeDocumentoID,@NroDocumento,@Direccion,@LocalidadID,@ProvinciaId,@TelefonoFijo,@TelefonoMovil,@CorreoElectronico,@FechaNacimiento,GrupoSanguineoID,InstitucionID)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@Nombre", paciente.NombrePaciente);
                    comando.Parameters.AddWithValue("@Apellido", paciente.ApellidoPaciente);
                    comando.Parameters.AddWithValue("@GeneroID", paciente.genero.GeneroID);
                    comando.Parameters.AddWithValue("@TipoDeDocumentoID", paciente.documento.TipoDocumentoID);
                    comando.Parameters.AddWithValue("@NroDocumento", paciente.NroDocumento);
                    comando.Parameters.AddWithValue("@Direccion", paciente.Direccion);
                    comando.Parameters.AddWithValue("@LocalidadID", paciente.localidad.LocalidadID);
                    comando.Parameters.AddWithValue("@ProvinciaId", paciente.provincia.ProvinciaID);
                    if (paciente.TelefonoFijo != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", paciente.TelefonoFijo);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", DBNull.Value);
                    }
                    if (paciente.TelefonoMovil != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", paciente.TelefonoMovil);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", DBNull.Value);
                    }
                    if (paciente.Email != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@CorreoElectronico", paciente.Email);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@CorreoElectronico", DBNull.Value);
                    }
                    comando.Parameters.AddWithValue("@FechaNacimiento", paciente.FechaNac);
                    comando.Parameters.AddWithValue("@GrupoSanguineoID", paciente.tipoSangre.GrupoSanguineoID);
                    comando.Parameters.AddWithValue("@InstitucionID", paciente.institucion.InstitucionID);


                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    paciente.PacienteID = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception)
                {
                    throw new Exception("Error al intentar guardar al paciente");
                }


            }
            else
            {
                //Edición
                try
                {
                    string cadenaComando = "UPDATE Pacientes SET Nombre=@Nombre,Apellido=@Apellido,GeneroID=@GeneroID,TipoDeDocumentoID=@TipoDeDocumentoID,NroDocumento=@NroDocumento,Direccion=@Direccion, LocalidadID=@LocalidadID,ProvinciaId=@ProvinciaId,TelefonoFijo=@TelefonoFijo,TelefonoMovil=@TelefonoMovil,CorreoElectronico=@CorreoElectronico,FechaNacimiento=@FechaNacimiento,GrupoSanguineoID=@GrupoSanguineoID,InstitucionID=@InstitucionID where donateID=@DonanteID";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@Nombre", paciente.NombrePaciente);
                    comando.Parameters.AddWithValue("@Apellido", paciente.ApellidoPaciente);
                    comando.Parameters.AddWithValue("@GeneroID", paciente.genero.GeneroID);
                    comando.Parameters.AddWithValue("@TipoDeDocumentoID", paciente.documento.TipoDocumentoID);
                    comando.Parameters.AddWithValue("@NroDocumento", paciente.NroDocumento);
                    comando.Parameters.AddWithValue("@Direccion", paciente.Direccion);
                    comando.Parameters.AddWithValue("@LocalidadID", paciente.localidad.LocalidadID);
                    comando.Parameters.AddWithValue("@ProvinciaId", paciente.provincia.ProvinciaID);
                    if (paciente.TelefonoFijo != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", paciente.TelefonoFijo);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", DBNull.Value);
                    }
                    if (paciente.TelefonoMovil != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", paciente.TelefonoMovil);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", DBNull.Value);
                    }
                    if (paciente.Email != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@CorreoElectronico", paciente.Email);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@CorreoElectronico", DBNull.Value);
                    }
                    comando.Parameters.AddWithValue("@FechaNacimiento", paciente.FechaNac);
                    comando.Parameters.AddWithValue("@GrupoSanguineoID", paciente.tipoSangre.GrupoSanguineoID);
                    comando.Parameters.AddWithValue("@InstitucionID", paciente.institucion.InstitucionID);
                    comando.Parameters.AddWithValue("@DonanteID", paciente.PacienteID);
                    comando.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new Exception("Error al intentar editar a un paciente");
                }

            }
        }

        private PacienteListDto ConstruirPacienteListDto(SqlDataReader reader)
        {
            return new PacienteListDto
            {
                PacienteID = reader.GetInt32(0),
                NombrePaciente = reader.GetString(1),
                ApellidoPaciente = reader.GetString(2),
                localidad = reader.GetString(3),
                provincia = reader.GetString(4),
                tipoSangre = reader.GetString(5),
                institucion=reader.GetString(6)
            };
        }
    }
}
