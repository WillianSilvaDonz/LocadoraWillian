using FluentValidation;
using LocacaoFilmes.App.Models.Cadastro;
using LocacaoFilmes.Repositorio.EntityCore;

namespace LocacaoFilmes.App.Validacao
{
    public class GeneroValidacao : AbstractValidator<GeneroCadastroModel>
    {
        private readonly IGeneroRepositorio _generoRepositorio;

        public GeneroValidacao(IGeneroRepositorio generoRepositorio)
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("Obrigatório")
                .MaximumLength(50)
                .Must(BeUniqueName).WithMessage("Já esta cadastrado.");

            _generoRepositorio = generoRepositorio;
        }

        //garante que o nome do genêro seja único
        private bool BeUniqueName(GeneroCadastroModel data, string nome)
        {
            var genero = _generoRepositorio.BuscarPeloNome(nome);

            return genero == null || genero.Id == data.Id;
        }
    }
}
