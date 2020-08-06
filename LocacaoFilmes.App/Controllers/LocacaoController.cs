using AutoMapper;
using LocacaoFilmes.App.Models.Cadastro;
using LocacaoFilmes.Entidades.Locacao;
using LocacaoFilmes.Negocios.Cadastro;
using Microsoft.AspNetCore.Authorization;
using Movies.Framework.Controllers;

namespace LocacaoFilmes.App.Controllers
{
    [Authorize]
    public class LocacaoController : CrudController<Locacao, LocacaoViewModel, LocacaoCadastroModel>
    {

        public LocacaoController(IMapper mapper, ILocacaoCrudServico servico) : base(mapper, servico)
        {
        }
    }
}
