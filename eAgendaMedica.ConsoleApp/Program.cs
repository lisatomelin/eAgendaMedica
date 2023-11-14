using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.Infra.Orm.Compartilhado;
using eAgendaMedica.Infra.Orm.ModuloConsulta;
using eAgendaMedica.Infra.Orm.ModuloMedico;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace eAgendaMedica.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var novoMedico = new Medico();
            novoMedico.Nome = "Pedro";
            novoMedico.CRM = "88888";
            novoMedico.Telefone = "999999999";
            novoMedico.Disponivel = false;

            var optionsBuilder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>();

            IConfiguration configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(@"Data Source=(LOCALDB)\MSSQLLOCALDB;Initial Catalog=EAgendaMedica;Integrated Security=True");


            var dbContext = new eAgendaMedicaDbContext(optionsBuilder.Options);

            var repositorioMedico = new RepositorioMedicoOrm(dbContext);
            repositorioMedico.InserirAsync(novoMedico);

            

            var novaConsulta = new Consulta();
            novaConsulta.Titulo = "Cardiologista";
            //novaConsulta.horaInicio = 10;
            //novaConsulta.horaTermino = 11;
            //novaConsulta.Medico = novoMedico;

            var repositorioConsulta = new RepositorioConsultaOrm(dbContext);
            repositorioConsulta.InserirAsync(novaConsulta);


            dbContext.SaveChanges();
        }
    }
}