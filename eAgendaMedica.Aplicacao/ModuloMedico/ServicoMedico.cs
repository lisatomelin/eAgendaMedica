﻿using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloMedico;
using FluentResults;

namespace eAgendaMedica.Aplicacao.ModuloMedico
{
    public class ServicoMedico
    {
        private readonly IRepositorioMedico repositorioMedico;
        private readonly IContextoPersistencia contextoPersistencia;

        public ServicoMedico(IRepositorioMedico repositorioMedico, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioMedico = repositorioMedico;
            this.contextoPersistencia = contextoPersistencia;
        }

        public async Task<Result<Medico>> InserirAsync(Medico medico)
        {
            var resultadoValidacao = ValidarMedico(medico);

            if (resultadoValidacao.IsFailed)
                return Result.Fail(resultadoValidacao.Errors);

            await repositorioMedico.InserirAsync(medico);

            await contextoPersistencia.GravarAsync();

            return Result.Ok(medico);

        }

        public async Task<Result<Medico>> EditarAsync(Medico medico)
        {
            var resultadoValidacao = ValidarMedico(medico);

            if (resultadoValidacao.IsFailed)
                return Result.Fail(resultadoValidacao.Errors);


            repositorioMedico.Editar(medico);

            await contextoPersistencia.GravarAsync();

            return Result.Ok(medico);

        }

        public async Task<Result> ExcluirAsync(Medico medico)
        {
            repositorioMedico.Excluir(medico);

            await contextoPersistencia.GravarAsync();

            return Result.Ok();

        }

        public async Task<Result<List<Medico>>> SelecionarTodosAsync()
        {
            var medicos = await repositorioMedico.SelecionarTodosAsync();

            return Result.Ok(medicos);
        }

        public async Task<Result<Medico>> SelecionarPorIdAsync(Guid Id)
        {
            var medico = await repositorioMedico.SelecionarPorIdAsync(Id);

            return Result.Ok(medico);
        }


        private Result ValidarMedico(Medico medico)
        {

            ValidadorMedico validador = new ValidadorMedico();

            var resultadoValidacao = validador.Validate(medico);

            List<Error> erros = new List<Error>();

            foreach (var erro in resultadoValidacao.Errors)

                erros.Add(new Error(erro.ErrorMessage));


            if (erros.Any())
                return Result.Fail(erros.ToArray());

            return Result.Ok();
        }
    }
}
