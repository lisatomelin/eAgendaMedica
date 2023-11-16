using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.WebApi.ViewModels
{
    
    

        public class InserirConsultaViewModel
        {

            public string Titulo { get; set; }
            public Medico Medico { get; set; }

            public DateTime Data { get; set; }
            public TimeSpan horaInicio { get; set; }
            public TimeSpan horaTermino { get; set; }

            public Guid MedicoId { get; set; }
        }

        public class EditarConsultaViewModel
        {

            public string Titulo { get; set; }
            public Medico Medico { get; set; }

            public DateTime Data { get; set; }
            public TimeSpan horaInicio { get; set; }
            public TimeSpan horaTermino { get; set; }

            public Guid MedicoId { get; set; }

        }

        public class ListarConsultaViewModel
        {
            public Guid Id { get; set; }
            public string Titulo { get; set; }
            public Medico Medico { get; set; }

            public DateTime Data { get; set; }
            
        }


        public class VisualizarConsultaViewModel
        {
            public Guid Id { get; set; }
            public string Titulo { get; set; }
            public Medico Medico { get; set; }

            public DateTime Data { get; set; }
            public TimeSpan horaInicio { get; set; }
            public TimeSpan horaTermino { get; set; }

            public Guid MedicoId { get; set; }
        }
    
}
