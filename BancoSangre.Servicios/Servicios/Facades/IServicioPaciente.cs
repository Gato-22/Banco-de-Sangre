﻿using BancoSangre.BL.Entidades.DTO.Pacientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSangre.Servicios.Servicios.Facades
{
    public interface IServicioPaciente
    {
        List<PacienteListDto> GetLista();
        
    }
}
