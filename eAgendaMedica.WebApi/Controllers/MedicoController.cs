using AutoMapper;
using eAgendaMedica.Aplicacao.ModuloMedico;
using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.WebApi.ViewModels.MedicoViewModel;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi.Controllers
{
    [Route("api/medicos")]
    [ApiController]
    public class MedicoController : ApiControllerBase
    {
        private readonly ServicoMedico servicoMedico;
        private readonly IMapper mapeador;

        public MedicoController(ServicoMedico servicoMedico, IMapper mapeador)
        {
            this.servicoMedico = servicoMedico;
            this.mapeador = mapeador;
        }



        [HttpGet]
        [ProducesResponseType(typeof(List<ListarMedicoViewModel>), 200)]
        [ProducesResponseType(typeof(string[]), 500)]

        public async Task<IActionResult> SelecionarTodos()
        {
            var medicoResult = await servicoMedico.SelecionarTodosAsync();

            var viewModel = mapeador.Map<List<ListarMedicoViewModel>>(medicoResult.Value);

            return Ok(viewModel);

        }

        [HttpGet("visualizacao-completa/{id}")]
        [ProducesResponseType(typeof(VisualizarMedicoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]

        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var medicoResult = await servicoMedico.SelecionarPorIdAsync(id);

            var viewModel = mapeador.Map<List<VisualizarMedicoViewModel>>(medicoResult.Value);

            return Ok(viewModel);

        }

        [HttpPost]
        [ProducesResponseType(typeof(FormsMedicoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Inserir(FormsMedicoViewModel viewModel)
        {
            var medico = mapeador.Map<Medico>(viewModel);

            var medicoResult = await servicoMedico.InserirAsync(medico);

            if (medicoResult.IsFailed)
                return BadRequest(medicoResult.Errors);

            return Ok(viewModel);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FormsMedicoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Editar(Guid id, FormsMedicoViewModel viewModel)
        {
            var selecaoMedicoResult = await servicoMedico.SelecionarPorIdAsync(id);

            if (selecaoMedicoResult.IsFailed)
                return NotFound(selecaoMedicoResult.Errors);

            var medico = mapeador.Map(viewModel, selecaoMedicoResult.Value);

            var medicoResult = await servicoMedico.EditarAsync(medico);

            if (medicoResult.IsFailed)
                return BadRequest(medicoResult.Errors);

            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var medicoResult = await servicoMedico.ExcluirAsync(id);

            if (medicoResult.IsFailed)
                return NotFound(medicoResult.Errors);

            return Ok();
        }


    }
}
