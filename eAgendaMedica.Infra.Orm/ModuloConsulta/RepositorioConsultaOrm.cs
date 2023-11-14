using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.Infra.Orm.Compartilhado;


namespace eAgendaMedica.Infra.Orm.ModuloConsulta
{
    public class RepositorioConsultaOrm : RepositorioBase<Consulta>, IRepositorioConsulta
    {
        public RepositorioConsultaOrm(eAgendaMedicaDbContext dbContext) : base(dbContext)
        {

        }
    }
}
