using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.WebApi.ViewModels
{



    public class InserirCirurgiaViewModel
    {

        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaTermino { get; set; }

        public List<Medico> Medicos { get; set; }
    }

    public class EditarCirurgiaViewModel
    {

        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaTermino { get; set; }

        public List<Medico> Medicos { get; set; }
    }

    public class ListarCirurgiaViewModel
    {
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
       

    }

    public class VisualizarCirurgiaViewModel
    {
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaTermino { get; set; }

        

        public List<Medico> Medicos { get; set; }
    }

}
