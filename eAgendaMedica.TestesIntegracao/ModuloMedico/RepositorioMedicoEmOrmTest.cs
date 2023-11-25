using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.TestesIntegracao.Compartilhado;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaMedica.TestesIntegracao.ModuloMedico
{
    [TestClass]
    public class RepositorioMedicoEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public async Task Deve_Inserir_Medico()
        {
            // Criação do médico
            var medico = Builder<Medico>.CreateNew().Build();

            // Inserção assíncrona do médico
            await repositorioMedico.InserirAsync(medico);

            // Gravação assíncrona no contexto
            await contextoPersistencia.GravarAsync();

            // Seleção assíncrona do médico pelo ID
            var medicoSelecionado = await repositorioMedico.SelecionarPorIdAsync(medico.Id);

            // Verificação usando FluentAssertions
            medicoSelecionado.Should().BeEquivalentTo(medico);
        }


        //[TestMethod]
        //public async Task Deve_Editar_Medico()
        //{
        //    // Criação e persistência assíncrona de um médico
        //    var medicoId = Builder<Medico>.CreateNew().Persist().Id;

        //    // Seleção assíncrona do médico pelo ID
        //    var medico = await repositorioMedico.SelecionarPorIdAsync(medicoId);

        //    // Edição do nome do médico
        //    medico.Nome = "Cleiton";

        //    // Edição assíncrona do médico no repositório
        //    await repositorioMedico.EditarAsync(medico);

        //    // Gravação assíncrona no contexto
        //    await contextoPersistencia.GravarAsync();

        //    // Seleção síncrona do médico pelo ID e verificação usando FluentAssertions
        //    repositorioMedico.SelecionarPorIdAsync(medico.Id).Should().BeEquivalentTo(medico);
        //}


        [TestMethod]
        public async Task Deve_Excluir_Medico()
        {
            // Criação e persistência assíncrona de um médico
            var medico = Builder<Medico>.CreateNew().Persist();

            // Exclusão assíncrona do médico no repositório
             repositorioMedico.Excluir(medico);

            // Gravação assíncrona no contexto
            await contextoPersistencia.GravarAsync();

            // Seleção assíncrona do médico pelo ID e verificação se é nulo usando FluentAssertions
           var medicoResposta = await repositorioMedico.SelecionarPorIdAsync(medico.Id);

            medicoResposta.Should().BeNull();
        }
    }
}
