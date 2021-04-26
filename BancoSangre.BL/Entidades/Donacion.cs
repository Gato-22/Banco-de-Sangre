﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.BL.Entidades
{
    public class Donacion : ICloneable
    {
        public int DonacionId { get; set; }
        public DateTime FechaDonacion { get; set; }
        public string Identificacion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string vencimiento { get; set; }
        public int Cantidad { get; set; }

        public Paciente Paciente { get; set; }

        public Donante Donante { get; set; }

        public TipoDonacion TipoDonacion { get; set; }

        public DonacionesDonacionesAutomatizadas DonacionesDonacionesAutomatizadas { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
