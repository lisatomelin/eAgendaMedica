using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.Dominio.ModuloCirurgia
{
    public class Cirurgia : Entidade
    {
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }

        public List<Medico> Medicos { get; set; }


        public Cirurgia()
        {

        }

        public Cirurgia(string titulo, DateTime data, TimeSpan horaInicio)
        {
            Titulo = titulo;
            Data = data;
            this.HoraInicio = horaInicio;

        }
    }
}
