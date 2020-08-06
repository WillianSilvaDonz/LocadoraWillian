using LocacaoFilmes.Entidades.Cadastro;
using LocacaoFilmes.Negocios.Servicos;
using System.Collections.Generic;

namespace LocacaoFilmes.Negocios.Cadastro
{
    public interface IFilmeCrudServico : ICrudServico<Filme>
    {
        List<Filme> BuscarTodosAtivosPeloNome(string name);
    }
}
