using LocacaoFilmes.Entidades.Locacao;
using LocacaoFilmes.Repositorio.Repositorios;
using System.Threading.Tasks;

namespace LocacaoFilmes.Repositorio.EntityCore
{
    public interface ILocacaoRepositorio : IRepositorio<Locacao>
    {
        Locacao BuscarPorFilmeCodigo(long id);

        Task<Locacao> BuscarPeloCodigoFilmesAsync(long id);
    }
}
