using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.Infra.Orm.Compartilhado;

namespace eAgendaMedica.Infra.Orm.ModuloMedico
{
    public class RepositorioMedicoOrm : RepositorioBase<Medico>, IRepositorioMedico
    {

        public RepositorioMedicoOrm(eAgendaMedicaDbContext dbContext) : base(dbContext)
        {

        }
    }
}
