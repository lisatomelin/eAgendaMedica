using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace eAgendaMedica.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var novoMedico = new Medico();
            novoMedico.Nome = "Pedro";

            var optionsBuilder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>();

            optionsBuilder.UseSqlServer(@"Data Source=(LOCALDB)\MSSQLLOCALDB;Initial Catalog=EAgendaMedica;Integrated Security=True");

            var dbContext = new eAgendaMedicaDbContext(optionsBuilder.Options);

            dbContext.Medicos.Add(novoMedico);
        }
    }
}