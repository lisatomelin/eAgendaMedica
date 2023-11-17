using AutoMapper;
using eAgendaMedica.Dominio.ModuloConsulta;
using eAgendaMedica.WebApi.ViewModels;

namespace eAgendaMedica.WebApi.Config.AutoMapperProfiles
{
    public class ConsultaProfile : Profile
    {
        public ConsultaProfile()
        {
            CreateMap<Consulta, ListarConsultaViewModel>();

            CreateMap<Consulta, VisualizarConsultaViewModel>();

            CreateMap<InserirConsultaViewModel, Consulta>();

            CreateMap<EditarConsultaViewModel, Consulta>();
        }
    }
}
