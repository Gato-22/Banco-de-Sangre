using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Documentos;
using BancoSangre.BL.Entidades.DTO.Generos;
using BancoSangre.BL.Entidades.DTO.Institucion;
using BancoSangre.BL.Entidades.DTO.Localidad;

using BancoSangre.BL.Entidades.DTO.Provincia;
using BancoSangre.BL.Entidades.DTO.TiposSangres;
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
                    
                    string cadenaComando = "SELECT * FROM Pacientes WHERE TipoDeDocumentoId=@doc and NroDocumento=@nro";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@doc", paciente.documento.TipoDocumentoID);
                    comando.Parameters.AddWithValue("@nro", paciente.NroDocumento);

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
                else
                {
                    string cadenaComando = "SELECT * FROM Pacientes WHERE TipoDeDocumentoId=@doc and NroDocumento=@nro AND DonanteID<>@DonanteID";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@doc", paciente.documento.TipoDocumentoID);
                    comando.Parameters.AddWithValue("@nro", paciente.NroDocumento);
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

        public Paciente getPacientePorID(int PacienteID)
        {
            Paciente paciente = null;
            try
            {
                string cadenacomando = "select DonanteID,Nombre,Apellido,GeneroID,TipoDeDocumentoID,NroDocumento,Direccion,LocalidadID,ProvinciaID,TelefonoFijo," +
                    "TelefonoMovil,CorreoElectronico,FechaNacimiento, GrupoSanguineoID, InstitucionID from Pacientes where DonanteID=@id";
                SqlCommand comando = new SqlCommand(cadenacomando, _conexion);
                comando.Parameters.AddWithValue("@id", PacienteID);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    paciente = ConstruirPaciente(reader);
                }
                reader.Close();
                return paciente;
            }
            catch (Exception hj)
            {

                throw new Exception("Error al intentar leer Los Pacientes");
            }
        }

        private Paciente ConstruirPaciente(SqlDataReader reader)
        {
            var generoEditDto = _genero.GetGeneroPorID(reader.GetInt32(3));
            var documentoEditDto = _documento.GetDocumentoPorID(reader.GetInt32(4));
            var localidadEditDto = _loca.GetlocalidadPorId(reader.GetInt32(7));
            var provinciaEditDto = _provi.GetProvinciaPorID(reader.GetInt32(8));
            var tipoSangreEditDto = _tipoSangre.GetTipoSangrePorID(reader.GetInt32(13));
            var institucionEditDto = _insti.GetInstitucionPorID(reader.GetInt32(14));
            return new Paciente
            {
                PacienteID = reader.GetInt32(0),
                NombrePaciente = reader.GetString(1),
                ApellidoPaciente = reader.GetString(2),
                genero = new Genero { GeneroID = generoEditDto.GeneroID, GeneroDescripcion = generoEditDto.GeneroDescripcion },
                documento = new Documento
                {
                    TipoDocumentoID = documentoEditDto.TipoDocumentoID,
                    Descripcion = documentoEditDto.Descripcion
                },
                NroDocumento = reader.GetString(5),
                Direccion = reader.GetString(6),
                localidad = new Localidad
                {
                    LocalidadID = localidadEditDto.LocalidadID,
                    NombreLocalidad = localidadEditDto.NombreLocalidad,
                    //NombreProvincia = localidadEditDto.ProvinciaID.NombreProvincia
                },
                provincia = new Provincia { ProvinciaID = provinciaEditDto.ProvinciaId, NombreProvincia = provinciaEditDto.NombreProvincia },
                TelefonoFijo = reader[9] != DBNull.Value ? reader.GetString(9) : string.Empty,
                TelefonoMovil = reader[10] != DBNull.Value ? reader.GetString(10) : string.Empty,
                Email= reader[11] != DBNull.Value ? reader.GetString(11) : string.Empty,
                
                FechaNac=reader.GetDateTime(12),
                tipoSangre= new TipoSangre { GrupoSanguineoID=tipoSangreEditDto.GrupoSanguineoID, Grupo=tipoSangreEditDto.Grupo},
                institucion=new Institucion { InstitucionID=institucionEditDto.InstitucionID, Denominacion=institucionEditDto.Denominacion}
            };
        }

        public List<Paciente> GetLista()
        {
            List<Paciente> lista = new List<Paciente>();
            try
            {
                string cadenaComando = "select DonanteID,Nombre,Apellido,GeneroID,TipoDeDocumentoID,NroDocumento,Direccion,LocalidadID,ProvinciaID,TelefonoFijo," +
                    "TelefonoMovil,CorreoElectronico,FechaNacimiento, GrupoSanguineoID, InstitucionID from Pacientes";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var pacienteListDto = ConstruirPaciente(reader);
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
        //private Paciente ConstruirPaciente(SqlDataReader reader)
        //{
        //    return new Paciente
        //    {
        //        PacienteID = reader.GetInt32(0),
        //        NombrePaciente = reader.GetString(1),
        //        ApellidoPaciente = reader.GetString(2),
        //        localidad = reader.GetString(3),
        //        provincia = reader.GetString(4),
        //        tipoSangre = reader.GetString(5),
        //        institucion = reader.GetString(6)
        //    };
        //}
        public void guardar(Paciente paciente)
        {
            if (paciente.PacienteID == 0)
            {
                //Nuevo registro
                try
                {
                    string cadenaComando = "INSERT INTO Pacientes(Nombre,Apellido,GeneroID,TipoDeDocumentoID,NroDocumento,Direccion,LocalidadID,ProvinciaID,TelefonoFijo,TelefonoMovil," +
                        "CorreoElectronico,FechaNacimiento,GrupoSanguineoID,InstitucionID) VALUES(@Nombre,@Apellido, @GeneroID,@TipoDeDocumentoID,@NroDocumento,@Direccion," +
                        "@LocalidadID,@ProvinciaID,@TelefonoFijo,@TelefonoMovil,@CorreoElectronico,@FechaNacimiento,@GrupoSanguineoID,@InstitucionID)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@Nombre", paciente.NombrePaciente);
                    comando.Parameters.AddWithValue("@Apellido", paciente.ApellidoPaciente);
                    comando.Parameters.AddWithValue("@GeneroID", paciente.genero.GeneroID);
                    comando.Parameters.AddWithValue("@TipoDeDocumentoID", paciente.documento.TipoDocumentoID);
                    comando.Parameters.AddWithValue("@NroDocumento", paciente.NroDocumento);
                    comando.Parameters.AddWithValue("@Direccion", paciente.Direccion);
                    comando.Parameters.AddWithValue("@LocalidadID", paciente.localidad.LocalidadID);
                    comando.Parameters.AddWithValue("@ProvinciaID", paciente.provincia.ProvinciaID);
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
                catch (Exception gh)
                {
                    throw new Exception("Error al intentar guardar al paciente");
                }


            }
            else
            {
                //Edición
                try
                {
                    string cadenaComando = "UPDATE Pacientes SET Nombre=@Nombre,Apellido=@Apellido,GeneroID=@GeneroID,TipoDeDocumentoID=@TipoDeDocumentoID," +
                        "NroDocumento=@NroDocumento,Direccion=@Direccion, LocalidadID=@LocalidadID,ProvinciaId=@ProvinciaId,TelefonoFijo=@TelefonoFijo,TelefonoMovil=@TelefonoMovil," +
                        "CorreoElectronico=@CorreoElectronico,FechaNacimiento=@FechaNacimiento,GrupoSanguineoID=@GrupoSanguineoID,InstitucionID=@InstitucionID where DonanteID=@DonanteID";
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
                catch (Exception ex)
                {
                    throw new Exception("Error al intentar editar a un paciente");
                }

            }
        }

        
    }
}
