using AutoMapper;
using eAgendaMedica.Aplicacao.ModuloCirurgia;
using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi.Controllers
{
    [Route("api/cirurgias")]
    [ApiController]
    public class CirurgiaController : ControllerBase
    {
        private readonly ServicoCirurgia servicoCirurgia;
        private readonly IMapper mapeador;

        public CirurgiaController(ServicoCirurgia servicoCirurgia, IMapper mapeador)
        {
            this.servicoCirurgia = servicoCirurgia;
            this.mapeador = mapeador;
        }
               

        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var cirurgiasResult = await servicoCirurgia.SelecionarTodosAsync();

            var viewModel = mapeador.Map<List<ListarCirurgiaViewModel>>(cirurgiasResult.Value);

            return Ok(viewModel);

        }


        [HttpGet("visualizacao-completa/{id}")]
        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var cirurgiaResult = await servicoCirurgia.SelecionarPorIdAsync(id);

            var viewModel = mapeador.Map<List<VisualizarCirurgiaViewModel>>(cirurgiaResult.Value);

            return Ok(viewModel);

        }


        [HttpPost]
        public async Task<IActionResult> Inserir(InserirCirurgiaViewModel viewModel)
        {
            var cirurgia = mapeador.Map<Cirurgia>(viewModel);

            var cirurgiaResult = await servicoCirurgia.InserirAsync(cirurgia);

            if (cirurgiaResult.IsFailed)
                return BadRequest(cirurgiaResult.Errors);

            return Ok(viewModel);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(Guid id, EditarCirurgiaViewModel viewModel)
        {
            var selecaoCirurgiaResult = await servicoCirurgia.SelecionarPorIdAsync(id);

            if (selecaoCirurgiaResult.IsFailed)
                return NotFound(selecaoCirurgiaResult.Errors);

            var cirurgia = mapeador.Map(viewModel, selecaoCirurgiaResult.Value);

            var cirurgiaResult = await servicoCirurgia.EditarAsync(cirurgia);

            if (cirurgiaResult.IsFailed)
                return BadRequest(cirurgiaResult.Errors);

            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var cirurgiaResult = await servicoCirurgia.ExcluirAsync(id);

            if (cirurgiaResult.IsFailed)
                return NotFound(cirurgiaResult.Errors);

            return Ok();
        }

    }
}
