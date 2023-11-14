using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.Infra.Orm.ModuloCirurgia;
using eAgendaMedica.Infra.Orm.ModuloConsulta;
using eAgendaMedica.Infra.Orm.ModuloMedico;
using Microsoft.EntityFrameworkCore;


namespace eAgendaMedica.Infra.Orm.Compartilhado
{
    public class eAgendaMedicaDbContext : DbContext
    {
        public eAgendaMedicaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Cirurgia> Cirurgias { get; set; }

        public DbSet<Consulta> Consultas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeadorCirurgiaOrm());

            modelBuilder.ApplyConfiguration(new MapeadorConsultaOrm());

            modelBuilder.ApplyConfiguration(new MapeadorMedicoOrm());



            base.OnModelCreating(modelBuilder);

        }
    }
}
