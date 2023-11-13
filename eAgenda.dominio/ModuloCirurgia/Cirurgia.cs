using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloMedico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaMedica.Dominio.ModuloCirurgia
{
    public class Cirurgia : Entidade
    {
        public string Titulo { get; set; }
        public Medico Medico { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaTermino { get; set; }
    }
}
