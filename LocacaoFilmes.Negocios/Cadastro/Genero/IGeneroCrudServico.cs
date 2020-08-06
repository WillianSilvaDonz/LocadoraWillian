using LocacaoFilmes.Negocios.Servicos;
using System.Collections.Generic;
using LocacaoFilmes.Entidades.Cadastro;

namespace LocacaoFilmes.Negocios.Cadastro
{
    public interface IGeneroCrudServico : ICrudServico<Genero>
    {
        List<Genero> BuscarTodosAtivosPeloNome(string name);
    }
}
