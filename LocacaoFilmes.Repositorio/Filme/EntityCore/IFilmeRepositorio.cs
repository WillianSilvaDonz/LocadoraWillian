using LocacaoFilmes.Entidades.Cadastro;
using LocacaoFilmes.Repositorio.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoFilmes.Repositorio.EntityCore
{
    public interface IFilmeRepositorio : IRepositorio<Filme>
    {
        Filme BuscarPeloNome(string name);

        Filme BuscarPeloCodigoGenero(long genreId);

        List<Filme> BuscarTodosAtivosPeloNome(string name);

        Task<Filme> BuscarPeloCodigoGeneroAsync(long id);

        List<Filme> BuscarPaginaComGenero(int limit, int offset);
    }
}
