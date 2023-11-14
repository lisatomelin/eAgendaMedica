using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Infra.Orm.Compartilhado;

namespace eAgendaMedica.Infra.Orm.ModuloCirurgia
{
    public class RepositorioCirurgiaOrm : RepositorioBase<Cirurgia>, IRepositorioCirurgia
    {
        public RepositorioCirurgiaOrm(eAgendaMedicaDbContext dbContext) : base(dbContext)
        {

        }
    }
}
