using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloConsulta;

namespace eAgendaMedica.Dominio.ModuloMedico
{
    public class Medico : Entidade
    {
        public string CRM { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public bool Disponivel { get; set; }

        public List<Consulta> Consultas { get; set; }

        public List<Cirurgia> Cirurgias { get; set; }


        public Medico()
        {
            
        }

        public Medico(string cRM, string nome, string telefone)
        {
            CRM = cRM;
            Nome = nome;
            Telefone = telefone;
            
        }
    }





}
