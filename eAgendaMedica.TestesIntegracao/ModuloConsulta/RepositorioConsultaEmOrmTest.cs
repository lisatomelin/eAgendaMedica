using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.TestesIntegracao.Compartilhado;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eAgendaMedica.TesteIntegracao.ModuloConsulta
{
    [TestClass]
    public class RepositorioConsultaEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public async Task Deve_Inserir_Consulta()
        {
            var medico = Builder<Medico>.CreateNew().Build();
            var consulta = Builder<Consulta>.CreateNew().Build();

            consulta.Medico = medico;
            consulta.MedicoId = medico.Id;

            await repositorioConsulta.InserirAsync(consulta);

            await contextoPersistencia.GravarAsync();

            var consultaSelecionado = await repositorioConsulta.SelecionarPorIdAsync(consulta.Id);

            consultaSelecionado.Should().BeEquivalentTo(consulta);
        }

        [TestMethod]
        public async Task Deve_Editar_Consulta()
        {
            var medico = Builder<Medico>.CreateNew().Persist();

            var consulta = Builder<Consulta>.CreateNew()
                .With(c => c.Medico = medico)
                .Persist()
                .Id;

            var consultaOriginal = await repositorioConsulta.SelecionarPorIdAsync(consulta);

            consultaOriginal.Titulo = "Camila";

            repositorioConsulta.Editar(consultaOriginal);

            await contextoPersistencia.GravarAsync();

            var consultaEditada = await repositorioConsulta.SelecionarPorIdAsync(consulta);

            consultaEditada.Should().BeEquivalentTo(consultaOriginal);
        }


        [TestMethod]
        public async Task Deve_Excluir_Consulta()
        {
            var medico = Builder<Medico>.CreateNew().Persist();
            var consulta = Builder<Consulta>.CreateNew()
                .With(c => c.Medico = medico)
                .Persist();

            repositorioConsulta.Excluir(consulta);
            repositorioMedico.Excluir(medico);

            await contextoPersistencia.GravarAsync();

            var consultaResposta = await repositorioConsulta.SelecionarPorIdAsync(consulta.Id);

            consultaResposta.Should().BeNull();
        }


        [TestMethod]
        public async Task Deve_selecionar_todos_Consulta()
        {
            // Arrange
            var medico1 = Builder<Medico>.CreateNew().Persist();
            var medico2 = Builder<Medico>.CreateNew().Persist();

            var consulta1 = Builder<Consulta>.CreateNew()
                .With(x => x.Medico = medico1)
                .Persist();

            var consulta2 = Builder<Consulta>.CreateNew()
                .With(x => x.Medico = medico2)
                .Persist();

            // Action
            var consulta = await repositorioConsulta.SelecionarTodosAsync();

            // Assert
            consulta.Should().NotBeEmpty();
            consulta.Should().Contain(consulta1);
            consulta.Should().Contain(consulta2);
        }


        [TestMethod]
        public async Task Deve_selecionar_cirurgia_por_id()
        {
            // Arrange
            var cirurgia = Builder<Cirurgia>.CreateNew().Persist();

            // Act
            var cirurgiaEncontrada = await repositorioCirurgia.SelecionarPorIdAsync(cirurgia.Id);

            // Assert
            cirurgiaEncontrada.Should().Be(cirurgia);
        }

    }
}