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
    public class RepositorioPacientes : Facades.IRepositorioPacientes
    {
        private readonly SqlConnection _conexion;
        public RepositorioPacientes(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Donante donante)
        {
            throw new NotImplementedException();
        }

        public Donante GetDonantePorID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Donante> GetDonante()
        {
            List<Donante> lista = null;
            try
            {
                string cadenaComando = "SELECT DonanteID, Nombre,Apellido,GeneroID,TipoDeDocumentoID,NroDocumento,Direccion,LocalidadID,ProvinciaID,TelefonoMovil,TelefonoFijo,CorreoElectronico,FechaNacimiento,GrupoSanguineoID fROM Donantes";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Donante donante = ConstruirDonante(reader);
                    lista.Add(donante);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception("Error al intentar men");
            }
        }

        private Donante ConstruirDonante(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Donante donante)
        {
            throw new NotImplementedException();
        }
    }
}
