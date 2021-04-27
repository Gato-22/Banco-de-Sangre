using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO;
using BancoSangre.BL.Entidades.DTO.Documentos;
using BancoSangre.BL.Entidades.DTO.Generos;
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
    public class RepositorioDonante : IRepositorioDonante
    {
        private readonly SqlConnection _conexion;
        private  IRepositorioLocalidades _loca;
        private  IRepositorioProvincias _provi;
        private  IRepositorioGeneros _genero;
        private  IRepositorioDocumentos _documento;
        private  IRepositorioTipoSangre _tipoSangre;
        public RepositorioDonante(SqlConnection sqlConnection, IRepositorioProvincias repositorioProvincias,
            IRepositorioLocalidades epositorioLocalidades, IRepositorioGeneros repositorioGeneros, IRepositorioDocumentos repositorioDocumentos, IRepositorioTipoSangre repositorioTipoSangre)
        {
            this._conexion = sqlConnection;
            _provi = repositorioProvincias;
            _loca = epositorioLocalidades;        
            _genero = repositorioGeneros;
            _documento = repositorioDocumentos;
            _tipoSangre = repositorioTipoSangre;
        }
        public RepositorioDonante(SqlConnection conexion)
        {
            this._conexion = conexion;
        }

        public void borrar(int donanteid)
        {
            try
            {
                string cadenaComando = "DELETE FROM Donantes WHERE DonanteID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", donanteid);
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

        public bool existe(Donante donante)
        {
            try
            {
                if (donante.DonanteID == 0)
                {
                    
                    string cadenaComando = "SELECT * FROM Donantes WHERE TipoDeDocumentoId=@doc and NroDocumento=@nro";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@doc", donante.documento.TipoDocumentoID);
                    comando.Parameters.AddWithValue("@nro", donante.NroDocumento);

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;
                }
                else
                {
                    string cadenaComando = "SELECT * FROM Donantes WHERE TipoDeDocumentoId=@doc and NroDocumento=@nro AND DonanteID<>@DonanteID";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@doc", donante.documento.TipoDocumentoID);
                    comando.Parameters.AddWithValue("@nro", donante.NroDocumento);
                    comando.Parameters.AddWithValue("@DonanteID", donante.DonanteID);
                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.HasRows;

                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Donante getDonantePorId(int donanteID)
        {
            Donante donante = null;
            try
            {
                string cadenacomando = "select DonanteID,Nombre,Apellido,GeneroID,TipoDeDocumentoID,NroDocumento,Direccion,LocalidadID,ProvinciaID,TelefonoFijo," +
                    "TelefonoMovil,CorreoElectronico,FechaNacimiento, GrupoSanguineoID from Donantes where DonanteID=@id";
                SqlCommand comando = new SqlCommand(cadenacomando, _conexion);
                comando.Parameters.AddWithValue("@id", donanteID);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    donante = ConstruirDonante(reader);
                }
                reader.Close();
                return donante;
            }
            catch (Exception hj)
            {

                throw new Exception("Error al intentar leer Los Pacientes");
            }
        }

        private Donante ConstruirDonante(SqlDataReader reader)
        {
            var generoEditDto = _genero.GetGeneroPorID(reader.GetInt32(3));
            var documentoEditDto = _documento.GetDocumentoPorID(reader.GetInt32(4));
            var localidadEditDto = _loca.GetlocalidadPorId(reader.GetInt32(7));
            var provinciaEditDto = _provi.GetProvinciaPorID(reader.GetInt32(8));
            var tipoSangreEditDto = _tipoSangre.GetTipoSangrePorID(reader.GetInt32(13));          
            return new Donante
            {
                DonanteID = reader.GetInt32(0),
                NombreDonante = reader.GetString(1),
                ApellidoDonante = reader.GetString(2),
                genero = new Genero { GeneroID = generoEditDto.GeneroID, GeneroDescripcion = generoEditDto.GeneroDescripcion },
                documento = new Documento
                {
                    TipoDocumentoID = documentoEditDto.TipoDocumentoID,
                    Descripcion = documentoEditDto.Descripcion
                },
                Direccion = reader.GetString(6),
                provincia = new Provincia { ProvinciaID = provinciaEditDto.ProvinciaId, NombreProvincia = provinciaEditDto.NombreProvincia },
                localidad = new Localidad
                {
                    LocalidadID = localidadEditDto.LocalidadID,
                    NombreLocalidad = localidadEditDto.NombreLocalidad,
                    //NombreProvincia = localidadEditDto.ProvinciaID.NombreProvincia
                },
                
                TelefonoFijo = reader[9] != DBNull.Value ? reader.GetString(9) : string.Empty,
                TelefonoMovil = reader[10] != DBNull.Value ? reader.GetString(10) : string.Empty,
                Email = reader[11] != DBNull.Value ? reader.GetString(11) : string.Empty,

                FechaNac = reader.GetDateTime(12),
                tipoSangre = new TipoSangre { GrupoSanguineoID = tipoSangreEditDto.GrupoSanguineoID, Grupo = tipoSangreEditDto.Grupo }
                
            };
        }
        //private Donante ConstruirDonante(SqlDataReader reader)
        //{
        //    return new Donante
        //    {
        //        DonanteID = reader.GetInt32(0),
        //        NombreDonante = reader.GetString(1),
        //        ApellidoDonante = reader.GetString(2),
        //        localidad = reader.GetString(3),
        //        provincia = reader.GetString(4),
        //        tipoSangre = reader.GetString(5)

        //    };
        //}

        public List<Donante> GetLista()
        {
            List<Donante> lista = new List<Donante>();
            try
            {
                string cadenacomando = "select DonanteID,Nombre,Apellido,GeneroID,TipoDeDocumentoID,NroDocumento,Direccion,LocalidadID,ProvinciaID,TelefonoFijo," +
                    "TelefonoMovil,CorreoElectronico,FechaNacimiento, GrupoSanguineoID from Donantes";
                SqlCommand comando = new SqlCommand(cadenacomando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var donanteListDto = ConstruirDonante(reader);
                    lista.Add(donanteListDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception)
            {

                throw new Exception("error al intentar leer donantes");
            }
        }

        public void guardar(Donante donante)
        {
            if (donante.DonanteID == 0)
            {
                //Nuevo registro
                try
                {
                    string cadenaComando = "INSERT INTO Donantes VALUES(@Nombre,@Apellido, @GeneroID,@TipoDeDocumentoID,@NroDocumento,@Direccion," +
                        "@LocalidadID,@ProvinciaId,@TelefonoFijo,@TelefonoMovil,@CorreoElectronico,@FechaNacimiento,@GrupoSanguineoID)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@Nombre", donante.NombreDonante);
                    comando.Parameters.AddWithValue("@Apellido", donante.ApellidoDonante);
                    comando.Parameters.AddWithValue("@GeneroID", donante.genero.GeneroID);
                    comando.Parameters.AddWithValue("@TipoDeDocumentoID", donante.documento.TipoDocumentoID);
                    comando.Parameters.AddWithValue("@NroDocumento", donante.NroDocumento);
                    comando.Parameters.AddWithValue("@Direccion", donante.Direccion);
                    comando.Parameters.AddWithValue("@LocalidadID", donante.localidad.LocalidadID);
                    comando.Parameters.AddWithValue("@ProvinciaId", donante.provincia.ProvinciaID);
                    if (donante.TelefonoFijo != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", donante.TelefonoFijo);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", DBNull.Value);
                    }
                    if (donante.TelefonoMovil != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", donante.TelefonoMovil);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", DBNull.Value);
                    }
                    if (donante.Email != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@CorreoElectronico", donante.Email);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@CorreoElectronico", DBNull.Value);
                    }
                    comando.Parameters.AddWithValue("@FechaNacimiento", donante.FechaNac);
                    comando.Parameters.AddWithValue("@GrupoSanguineoID", donante.tipoSangre.GrupoSanguineoID);
                 


                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    donante.DonanteID = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception asd)
                {
                    throw new Exception("Error al intentar guardar del donante");
                }


            }
            else
            {
                //Edición
                try
                {
                    string cadenaComando = "UPDATE Donantes SET Nombre=@Nombre,Apellido=@Apellido,GeneroID=@GeneroID,TipoDeDocumentoID=@TipoDeDocumentoID," +
                        "NroDocumento=@NroDocumento,Direccion=@Direccion, LocalidadID=@LocalidadID,ProvinciaId=@ProvinciaId,TelefonoFijo=@TelefonoFijo,TelefonoMovil=@TelefonoMovil," +
                        "CorreoElectronico=@CorreoElectronico,FechaNacimiento=@FechaNacimiento,GrupoSanguineoID=@GrupoSanguineoID where DonanteID=@DonanteID";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@Nombre", donante.NombreDonante);
                    comando.Parameters.AddWithValue("@Apellido", donante.ApellidoDonante);
                    comando.Parameters.AddWithValue("@GeneroID", donante.genero.GeneroID);
                    comando.Parameters.AddWithValue("@TipoDeDocumentoID", donante.documento.TipoDocumentoID);
                    comando.Parameters.AddWithValue("@NroDocumento", donante.NroDocumento);
                    comando.Parameters.AddWithValue("@Direccion", donante.Direccion);
                    comando.Parameters.AddWithValue("@LocalidadID", donante.localidad.LocalidadID);
                    comando.Parameters.AddWithValue("@ProvinciaId", donante.provincia.ProvinciaID);
                    if (donante.TelefonoFijo != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", donante.TelefonoFijo);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", DBNull.Value);
                    }
                    if (donante.TelefonoMovil != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", donante.TelefonoMovil);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", DBNull.Value);
                    }
                    if (donante.Email != string.Empty)
                    {
                        comando.Parameters.AddWithValue("@CorreoElectronico", donante.Email);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@CorreoElectronico", DBNull.Value);
                    }
                    comando.Parameters.AddWithValue("@FechaNacimiento", donante.FechaNac);
                    comando.Parameters.AddWithValue("@GrupoSanguineoID", donante.tipoSangre.GrupoSanguineoID);
                    
                    comando.Parameters.AddWithValue("@DonanteID", donante.DonanteID);
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
