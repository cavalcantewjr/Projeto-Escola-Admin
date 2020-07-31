using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Models;

namespace DevIO.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Escola, EscolaViewModel>().ReverseMap(); //EscolaViewModel
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<TurmaViewModel, Turma>();

            CreateMap<Turma, TurmaViewModel>()
                .ForMember(dest => dest.NomeEscola, opt => opt.MapFrom(src => src.Escola.Nome));
        }
    }
}