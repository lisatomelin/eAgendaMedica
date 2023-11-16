using AutoMapper;
using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.WebApi.ViewModels;

namespace eAgendaMedica.WebApi.Config.AutoMapperProfiles
{
    public class MedicoProfile : Profile
    {
        public MedicoProfile()
        {
            CreateMap<Medico, ListarMedicoViewModel>();

            CreateMap<Medico, VisualizarMedicoViewModel>();

            CreateMap<InserirMedicoViewModel, Medico>();

            CreateMap<EditarMedicoViewModel, Medico>();
        }
    }
}
