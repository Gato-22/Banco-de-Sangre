using BancoSangre.BL.Entidades.DTO;
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
        private readonly SqlConnection _sqlConnection;
        public RepositorioDonante(SqlConnection sqlConnection)
        {
            this._sqlConnection = sqlConnection;
        }
        public List<DonanteListDto> GetLista()
        {
            List<DonanteListDto> lista = new List<DonanteListDto>();
            try
            {
                string cadenacomando = "Select DonanteID,Nombre,Apellido,NombreLocalidad,NombreProvincia,Grupo from Donantes d inner join Localidades l on d.LocalidadID=l.LocalidadID inner join Provincias p on d.ProvinciaID=p.ProvinciaID inner join GruposSanguineos g on d.GrupoSanguineoID = g.GrupoSanguineoID";
                SqlCommand comando = new SqlCommand(cadenacomando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var donanteListDto = ConstruirDonanteListDto(reader);
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

        private DonanteListDto ConstruirDonanteListDto(SqlDataReader reader)
        {
            return new DonanteListDto
            {
                DonanteID = reader.GetInt32(0),
                NombreDonante=reader.GetString(1),
                ApellidoDonante=reader.GetString(2),
                localidad=reader.GetString(3),
                provincia=reader.GetString(4),
                tipoSangre=reader.GetString(5)
                
            };
        }
    }
}
