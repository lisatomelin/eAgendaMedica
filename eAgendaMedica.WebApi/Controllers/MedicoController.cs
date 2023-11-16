using AutoMapper;
using eAgendaMedica.Aplicacao.ModuloCirurgia;
using eAgendaMedica.Aplicacao.ModuloMedico;
using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi.Controllers
{
    [Route("api/medicos")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly ServicoMedico servicoMedico;
        private readonly IMapper mapeador;

        public MedicoController(ServicoMedico servicoMedico, IMapper mapeador)
        {
            this.servicoMedico = servicoMedico;
            this.mapeador = mapeador;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var medicos = await servicoMedico.SelecionarTodosAsync();

            var viewModel = mapeador.Map<List<ListarMedicoViewModel>>(medicos.Value);

            return Ok(viewModel);

        }

        [HttpGet]

        public async Task<IActionResult> SelecionarTodos()
        {
            var medicos = await servicoMedico.SelecionarTodosAsync();

            var viewModel = mapeador.Map<List<ListarMedicoViewModel>>(medicos.Value);

            return Ok(viewModel);

        }

        [HttpGet("visualizacao-completa/{id}")]

        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var medicoResult = await servicoMedico.SelecionarPorIdAsync(id);

            var viewModel = mapeador.Map<List<VisualizarMedicoViewModel>>(medicoResult.Value);

            return Ok(viewModel);

        }
    }
}
