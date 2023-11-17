﻿using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.WebApi.ViewModels.ConsultaViewModel
{
    public class ListarConsultaViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public Guid MedicoId { get; set; }

    }

}
