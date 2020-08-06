using FluentValidation;
using LocacaoFilmes.App.Models.Cadastro;

namespace LocacaoFilmes.App.Validacao
{
    public class LocacaoValidacao : AbstractValidator<LocacaoCadastroModel>
    {
        public LocacaoValidacao()
        {
            RuleFor(e => e.CpfCliente)
                .NotEmpty().WithMessage("Obrigatório.")
                .Length(14);
        }
    }
}
