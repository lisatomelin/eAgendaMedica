using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloMedico;

namespace eAgendaMedica.Dominio.ModuloConsulta
{
    public class Consulta : Entidade
    {
        public string Titulo { get; set; }
        public Medico Medico { get; set; }

        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }

        public Guid MedicoId { get; set; }


        public Consulta()
        {

        }

        public Consulta(string titulo, Medico medico, DateTime data, TimeSpan horaInicio, Guid medicoId)
        {
            Titulo = titulo;
            Medico = medico;
            Data = data;
            this.HoraInicio = horaInicio;
            MedicoId = medicoId;
        }
    }
}
