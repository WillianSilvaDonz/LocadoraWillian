using LocacaoFilmes.Entidades.Locacao;
using LocacaoFilmes.Repositorio.Data;
using LocacaoFilmes.Repositorio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoFilmes.Repositorio.EntityCore
{
    public class LocacaoRepositorio : EfCoreRepositorio<Locacao, EntityDataContext>, ILocacaoRepositorio
    {
        public LocacaoRepositorio(EntityDataContext context) : base(context)
        {
        }

        public Locacao BuscarPorFilmeCodigo(long id)
        {
            return DbSet.Include(e => e.Filmes)
                .ThenInclude(e => e.Filme)
                .FirstOrDefault(e => e.Id == id);
        }

        public Task<Locacao> BuscarPeloCodigoFilmesAsync(long id)
        {
            return DbSet.Include(e => e.Filmes).ThenInclude(e=>e.Filme).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
