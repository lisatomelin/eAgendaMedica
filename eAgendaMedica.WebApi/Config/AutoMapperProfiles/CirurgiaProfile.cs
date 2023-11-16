using AutoMapper;
using eAgendaMedica.Dominio.ModuloCirurgia;
using eAgendaMedica.WebApi.ViewModels;

namespace eAgendaMedica.WebApi.Config.AutoMapperProfiles
{
    public class CirurgiaProfile : Profile
    {
        public CirurgiaProfile()
        {
            CreateMap<Cirurgia, ListarCirurgiaViewModel>();

            CreateMap<Cirurgia, VisualizarCirurgiaViewModel>();


            CreateMap<InserirCirurgiaViewModel,Cirurgia>();

            CreateMap<EditarCirurgiaViewModel, Cirurgia>();
        }
    }
}
