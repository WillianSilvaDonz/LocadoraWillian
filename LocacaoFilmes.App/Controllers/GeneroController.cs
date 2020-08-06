using AutoMapper;
using LocacaoFilmes.App.Models.Cadastro;
using LocacaoFilmes.Entidades.Cadastro;
using LocacaoFilmes.Negocios.Cadastro;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Framework.Controllers;
using System.Linq;

namespace LocacaoFilmes.App.Controllers
{
    [Authorize]
    public class GeneroController : CrudController<Genero, GeneroViewModel, GeneroCadastroModel>
    {
        private readonly IGeneroCrudServico _servico;

        public GeneroController(IMapper mapper, IGeneroCrudServico servico)
            : base(mapper, servico)
        {
            _servico = servico;
        }

        //funcao para que seja consultada via ajax para trazer os dados na tela do filme.
        [HttpGet]
        public IActionResult SelectList(string term)
        {
            var list = _servico.BuscarTodosAtivosPeloNome(term)
                .Select(e => new { id = e.Id, text = e.Nome });

            return Json(list);
        }
    }
}
