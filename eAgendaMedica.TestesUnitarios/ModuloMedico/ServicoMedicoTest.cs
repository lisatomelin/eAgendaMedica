using eAgendaMedica.Aplicacao.ModuloMedico;
using eAgendaMedica.Dominio.Compartilhado;
using eAgendaMedica.Dominio.ModuloMedico;
using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using Moq;

namespace eAgendaMedica.TestesUnitarios.ModuloMedico
{
    [TestClass]
    public class ServicoMedicoTest
    {
        Mock<IRepositorioMedico> repositorioMedicoMoq;
        Mock<ValidadorMedico> validadorMedicoMoq;
        Mock<IContextoPersistencia> contextoMoq;

        private ServicoMedico servicoMedico;

        Medico medico;
    

        public ServicoMedicoTest()
        {
            repositorioMedicoMoq = new Mock<IRepositorioMedico>();
            validadorMedicoMoq = new Mock<ValidadorMedico>();
            contextoMoq = new Mock<IContextoPersistencia>();
           // servicoMedico = new ServicoMedico(repositorioMedicoMoq.Object, validadorMedicoMoq.Object, contextoMoq.Object);

            medico = new Medico("LISIANA", "49 9999-9999", "55555-SC");
        }

        //[TestMethod]
        //public void Deve_inserir_medico_caso_ele_for_valido() //cenário 1
        //{
        //    action
        //    Result resultado = servicoMedico.InserirAsync(medico);

        //    assert
        //    resultado.Should().BeSuccess();
        //    repositorioMedicoMoq.Verify(x => x.InserirAsync(medico), Times.Once());


        //}
    }

}
