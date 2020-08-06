using FluentValidation;
using LocacaoFilmes.App.Models.Cadastro;
using LocacaoFilmes.Repositorio.EntityCore;
using System.Threading;
using System.Threading.Tasks;

namespace LocacaoFilmes.App.Validacao
{
    public class FilmeValidacao : AbstractValidator<FilmeCadastroModel>
    {
        private readonly IGeneroRepositorio _generoRepositorio;
        private readonly IFilmeRepositorio _filmeRepositorio;

        public FilmeValidacao(IGeneroRepositorio generoRepositorio, IFilmeRepositorio filmeRepositorio)
        {
            RuleFor(e => e.Nome)
                .NotEmpty()
                .MaximumLength(150)
                .Must(UnicoNome).WithMessage("Já foi cadastrado.");

            RuleFor(e => e.GeneroId)
                .Must(Existe).WithMessage("Obrigatório.")
                .MustAsync(Ativo).WithMessage("O genêro deve estar ativo.");

            _generoRepositorio = generoRepositorio;
            _filmeRepositorio = filmeRepositorio;
        }

        //garante que sómente genêros ativos sejam vinculados
        private async Task<bool> Ativo(long generoId, CancellationToken token)
        {
            var genero = await _generoRepositorio.BuscarPorCodigoAsync(generoId);

            return genero != null && genero.Ativo;
        }

        //garante que o id de genêro recebido esteja cadastrado
        private bool Existe(long generoId)
        {
            return _generoRepositorio.Existe(generoId);
        }

        //garante que o nome do filme seja único
        private bool UnicoNome(FilmeCadastroModel data, string nome)
        {
            var filme = _filmeRepositorio.BuscarPeloNome(nome);

            return filme == null || filme.Id == data.Id;
        }
    }
}
