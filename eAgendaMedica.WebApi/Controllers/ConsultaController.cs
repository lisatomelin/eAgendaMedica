using AutoMapper;
using eAgendaMedica.Aplicacao.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.WebApi.ViewModels.ConsultaViewModel;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi.Controllers
{

    [Route("api/consultas")]
    [ApiController]
    public class ConsultaController : ApiControllerBase
    {
        private readonly ServicoConsulta servicoConsulta;
        private readonly IMapper mapeador;

        public ConsultaController(ServicoConsulta servicoConsulta, IMapper mapeador)
        {
            this.servicoConsulta = servicoConsulta;
            this.mapeador = mapeador;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<ListarConsultaViewModel>), 200)]
        [ProducesResponseType(typeof(string[]), 500)]

        public async Task<IActionResult> SelecionarTodos()
        {
            var consultasResult = await servicoConsulta.SelecionarTodosAsync();

            var viewModel = mapeador.Map<List<ListarConsultaViewModel>>(consultasResult.Value);

            return Ok(viewModel);

        }


        [HttpGet("visualizacao-completa/{id}")]
        [ProducesResponseType(typeof(VisualizarConsultaViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]

        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var consultaResult = await servicoConsulta.SelecionarPorIdAsync(id);

            var viewModel = mapeador.Map<List<VisualizarConsultaViewModel>>(consultaResult.Value);

            return Ok(viewModel);

        }

        [HttpPost]
        [ProducesResponseType(typeof(FormsConsultaViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Inserir(FormsConsultaViewModel viewModel)
        {
            var consulta = mapeador.Map<Consulta>(viewModel);

            var consultaResult = await servicoConsulta.InserirAsync(consulta);

            if (consultaResult.IsFailed)
                return BadRequest(consultaResult.Errors);

            return Ok(viewModel);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FormsConsultaViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Editar(Guid id, FormsConsultaViewModel viewModel)
        {
            var selecaoConsultaResult = await servicoConsulta.SelecionarPorIdAsync(id);

            if (selecaoConsultaResult.IsFailed)
                return NotFound(selecaoConsultaResult.Errors);

            var consulta = mapeador.Map(viewModel, selecaoConsultaResult.Value);

            var consultaResult = await servicoConsulta.EditarAsync(consulta);

            if (consultaResult.IsFailed)
                return BadRequest(consultaResult.Errors);

            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var consultaResult = await servicoConsulta.ExcluirAsync(id);

            if (consultaResult.IsFailed)
                return NotFound(consultaResult.Errors);

            return Ok();
        }
    }
}
