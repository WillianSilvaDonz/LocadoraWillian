using LocacaoFilmes.Entidades.Relacionamento;
using LocacaoFilmes.Repositorio.Data;
using LocacaoFilmes.Repositorio.Repositorios;
using System.Linq;

namespace LocacaoFilmes.Repositorio.EntityCore
{
    public class FilmeLocacaoRepositorio : EfCoreRepositorio<FilmeLocacao, EntityDataContext>, IFilmeLocacaoRepositorio
    {
        public FilmeLocacaoRepositorio(EntityDataContext context) : base(context)
        {
        }

        public FilmeLocacao BuscarPorCodigoFilme(long filmeCodigo)
        {
            return DbSet.FirstOrDefault(e => e.FilmeId == filmeCodigo);
        }
    }
}
