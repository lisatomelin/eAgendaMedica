using AutoMapper;
using eAgendaMedica.Aplicacao.ModuloCirurgia;
using eAgendaMedica.Aplicacao.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi.Controllers
{

    [Route("api/consultas")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly ServicoConsulta servicoConsulta;
        private readonly IMapper mapeador;

        public ConsultaController(ServicoConsulta servicoConsulta, IMapper mapeador)
        {
            this.servicoConsulta = servicoConsulta;
            this.mapeador = mapeador;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var consultas = await servicoConsulta.SelecionarTodosAsync();

            var viewModel = mapeador.Map<List<ListarConsultaViewModel>>(consultas.Value);

            return Ok(viewModel);

        }

        [HttpGet]

        public async Task<IActionResult> SelecionarTodos()
        {
            var consultasResult = await servicoConsulta.SelecionarTodosAsync();

            var viewModel = mapeador.Map<List<ListarConsultaViewModel>>(consultasResult.Value);

            return Ok(viewModel);

        }

        [HttpGet("visualizacao-completa/{id}")]

        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var consultaResult = await servicoConsulta.SelecionarPorIdAsync(id);

            var viewModel = mapeador.Map<List<VisualizarConsultaViewModel>>(consultaResult.Value);

            return Ok(viewModel);

        }
    }
}
