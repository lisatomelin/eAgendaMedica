using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.TestesIntegracao.Compartilhado;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eAgendaMedica.TesteIntegracao.ModuloCirurgia
{
    [TestClass]
    public class RepositorioCirurgiaOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public async Task Deve_Inserir_Cirurgia()
        {
            var cirurgia = Builder<Cirurgia>.CreateNew().Build();

            await repositorioCirurgia.InserirAsync(cirurgia);

            await contextoPersistencia.GravarAsync();

            var cirurgiaSelecionada = await repositorioCirurgia.SelecionarPorIdAsync(cirurgia.Id);

            cirurgiaSelecionada.Should().BeEquivalentTo(cirurgia);
        }

        [TestMethod]
        public async Task Deve_Editar_Cirurgia()
        {
            var cirurgiaId = Builder<Cirurgia>.CreateNew().Persist().Id;

            var cirurgia = await repositorioCirurgia.SelecionarPorIdAsync(cirurgiaId);

            cirurgia.Titulo = "Camila";

            repositorioCirurgia.Editar(cirurgia);

            await contextoPersistencia.GravarAsync();

            var cirurgiaEditado = await repositorioCirurgia.SelecionarPorIdAsync(cirurgia.Id);

            cirurgiaEditado.Should().BeEquivalentTo(cirurgia);
        }

        [TestMethod]
        public async Task Deve_Excluir_Cirurgia()
        {
            var cirurgia = Builder<Cirurgia>.CreateNew().Persist();

            repositorioCirurgia.Excluir(cirurgia);

            await contextoPersistencia.GravarAsync();

            var cirurgiaResposta = await repositorioCirurgia.SelecionarPorIdAsync(cirurgia.Id);

            cirurgiaResposta.Should().BeNull();
        }

        [TestMethod]
        public async Task Deve_selecionar_todos_Cirurgia()
        {
            // Arrange
            var cirurgia1 = Builder<Cirurgia>.CreateNew().Persist();
            var cirurgia2 = Builder<Cirurgia>.CreateNew().Persist();

            // Act
            var cirurgia = await repositorioCirurgia.SelecionarTodosAsync();

            // Assert
            cirurgia.Should().NotBeEmpty();
            cirurgia.Should().Contain(cirurgia1);
            cirurgia.Should().Contain(cirurgia2);
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
