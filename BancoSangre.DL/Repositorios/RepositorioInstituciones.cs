using BancoSangre.BL.Entidades.DTO.Institucion;
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
        public RepositorioInstituciones(SqlConnection sqlConnection)
        {
            this._sqlConnection = sqlConnection;
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
