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
    public class ServicioGeneros : IServicioGenero
    {
        private IRepositorioGeneros _Repositorio;
        private ConexionBd _conexionBd;

        public void Borar(int id)
        {
            throw new NotImplementedException();
        }

        public bool existe(Genero genero)
        {
            throw new NotImplementedException();
        }

        public Genero GetGeneroID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Genero> GetGeneros()
        {
            try
            {
                _conexionBd = new ConexionBd();
                _Repositorio = new RepositorioGeneros(_conexionBd.AbrirConexion());
                var lista = _Repositorio.GetGeneros();
                _conexionBd.CerrarConexion();
                return lista;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Genero genero)
        {
            throw new NotImplementedException();
        }
    }
}