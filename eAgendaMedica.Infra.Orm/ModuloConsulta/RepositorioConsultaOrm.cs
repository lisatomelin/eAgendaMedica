﻿using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.Infra.Orm.Compartilhado;


namespace eAgendaMedica.Infra.Orm.ModuloConsulta
{
    public class RepositorioConsultaOrm : RepositorioBase<Consulta>, IRepositorioConsulta
    {
        public RepositorioConsultaOrm(IContextoPersistencia ctx) : base(ctx)
        {
        }

        public override async Task<Consulta> SelecionarPorIdAsync(Guid id)
        {
            return await registros.Include(x => x.Medico)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<List<Consulta>> SelecionarTodosAsync()
        {
            return await registros.Include(x => x.Medico).ToListAsync();
        }
    }
}
