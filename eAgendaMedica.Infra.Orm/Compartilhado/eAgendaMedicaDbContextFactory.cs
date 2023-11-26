﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace eAgendaMedica.Infra.Orm.Compartilhado
{
    public class eAgendaMedicaDbContextFactory : IDesignTimeDbContextFactory<eAgendaMedicaDbContext>
    {
        public eAgendaMedicaDbContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>();

            IConfiguration configuracao = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var connectionString = configuracao.GetConnectionString("PostgreSql");

            optionsBuilder.UseNpgsql(connectionString);

            var dbContext = new eAgendaMedicaDbContext(optionsBuilder.Options);

            return dbContext;
        }
    }
}
