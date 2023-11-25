using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.Infra.Orm.Compartilhado;
using eAgendaMedica.Infra.Orm.ModuloMedico;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace eAgendaMedica.TestesIntegracao.Compartilhado
{
    public class TestesIntegracaoBase
    {
        protected IRepositorioMedico repositorioMedico;
        protected IContextoPersistencia contextoPersistencia;


        public TestesIntegracaoBase()
        {
            string connectionString = ObterConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new eAgendaMedicaDbContext(optionsBuilder.Options);
            contextoPersistencia = dbContext;

            repositorioMedico = new RepositorioMedicoOrm(dbContext);

        }

        protected static string ObterConnectionString()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");
            return connectionString;
        }
    }

}
