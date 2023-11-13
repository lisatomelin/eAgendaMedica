using eAgendaMedica.Dominio.Compartilhado;

namespace eAgendaMedica.Dominio.ModuloMedico
{
    public class Medico : Entidade
    {
        public string CRM { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public bool Disponivel { get; set; }

    }
}
