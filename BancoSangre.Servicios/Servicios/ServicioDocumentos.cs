﻿using BancoSangre.BL.Entidades;
using BancoSangre.DL;
using BancoSangre.DL.Repositorios;
using BancoSangre.DL.Repositorios.Facades;
using BancoSangre.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios
{
    public class ServicioDocumentos : IServicioDocumento
    {
        private IRepositorioDocumentos _Repositorio;
        private ConexionBd _conexionBd;
        public void borrar(int id)
        {
            throw new NotImplementedException();
        }

        public bool existe(Documento documento)
        {
            throw new NotImplementedException();
        }

        public Documento GetDocumentoID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Documento> GetDocumentos()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositorio = new RepositorioDocumentos(_conexionBd.AbrirConexion());
                var lista = _Repositorio.GetDocumentos();
                _conexionBd.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Documento documento)
        {
            throw new NotImplementedException();
        }
    }
}