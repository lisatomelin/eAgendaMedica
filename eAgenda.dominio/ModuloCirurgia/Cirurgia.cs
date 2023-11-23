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

        public List<Medico> ListaMedicos { get; set; }


        public Cirurgia()
        {
            ListaMedicos = new List<Medico>();
        }

        public Cirurgia(string titulo, List<Medico> listaMedicos, TimeSpan horaInicio)
        {
            Titulo = titulo;
            ListaMedicos = listaMedicos;
            HoraInicio = horaInicio;
        }

        public bool AdicionarMedico(Medico medico)
        {
            if (ListaMedicos.Exists(x => x.Equals(medico)) == false)
            {
                medico.Cirurgias.Add(this);
                ListaMedicos.Add(medico);

                return true;
            }

            return false;
        }

        public void RemoverMedico(Guid medicoId)
        {
            var medicoCirurgia = ListaMedicos.Find(x => x.Id.Equals(medicoId));

            ListaMedicos.Remove(medicoCirurgia);
        }
    }

}