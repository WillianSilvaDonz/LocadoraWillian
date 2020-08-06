using LocacaoFilmes.Entidades.Cadastro;
using LocacaoFilmes.Repositorio.Repositorios;
using System.Collections.Generic;

namespace LocacaoFilmes.Repositorio.EntityCore
{
    public interface IGeneroRepositorio : IRepositorio<Genero>
    {
        Genero BuscarPeloNome(string generoNome);

        List<Genero> BuscarTodosAtivosPeloNome(string nome);
    }
}
