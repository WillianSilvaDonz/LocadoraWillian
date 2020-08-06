using AutoMapper;
using LocacaoFilmes.App.Models.Cadastro;
using LocacaoFilmes.Entidades.Cadastro;
using LocacaoFilmes.Negocios.Cadastro;
using Microsoft.AspNetCore.Mvc;
using Movies.Framework.Controllers;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoFilmes.App.Controllers
{
    public class FilmeController : CrudController<Filme, FilmeViewModel, FilmeCadastroModel>
    {
        private readonly IFilmeCrudServico _servico;

        public FilmeController(IMapper mapper, IFilmeCrudServico servico) : base(mapper, servico)
        {
            _servico = servico;
        }

        //funcao para consulta ajax para levar todos os filmes.
        [HttpGet]
        public async Task<IActionResult> SelectList(string term)
        {
            var list = _servico.BuscarTodosAtivosPeloNome(term)
                .Select(e => new { id = e.Id, text = e.Nome });

            return Json(list);
        }
    }
}
