using AutoMapper;
using LocacaoFilmes.App.Models.Cadastro;
using LocacaoFilmes.Entidades.Cadastro;
using LocacaoFilmes.Entidades.Locacao;
using LocacaoFilmes.Entidades.Relacionamento;
using System.Linq;

namespace LocacaoFilmes.App.Mappings
{
    public class MapearPerfil : Profile
    {
        public MapearPerfil()
        {
            CreateMap<Genero, GeneroCadastroModel>().ReverseMap();

            CreateMap<Genero, GeneroViewModel>();

            CreateMap<Filme, FilmeViewModel>()
                .ForMember(dest => dest.GeneroNome, opt => opt.MapFrom(e => e.Genero.Nome));

            CreateMap<Filme, FilmeCadastroModel>()
                .ReverseMap()
                .ForMember(dest => dest.Genero, opt => opt.Ignore());

            CreateMap<Locacao, LocacaoViewModel>()
                .ForMember(dest => dest.Filmes, opt => opt.MapFrom(src => src.Filmes.Select(e => new FilmeViewModel() { Id = e.Filme.Id, Nome = e.Filme.Nome })));

            CreateMap<Locacao, LocacaoCadastroModel>()
                .ReverseMap()
                .ForMember(dest => dest.Filmes, opt => opt.MapFrom(src => src.FilmesId.Select(filmeId => new FilmeLocacao() { FilmeId = filmeId, LocacaoId = src.Id })));
        }
    }
}
