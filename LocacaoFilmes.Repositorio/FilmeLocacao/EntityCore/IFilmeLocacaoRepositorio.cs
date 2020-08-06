using LocacaoFilmes.Entidades.Relacionamento;
using LocacaoFilmes.Repositorio.Repositorios;

namespace LocacaoFilmes.Repositorio.EntityCore
{
    public interface IFilmeLocacaoRepositorio : IRepositorio<FilmeLocacao>
    {
        FilmeLocacao BuscarPorCodigoFilme(long filmeId);
    }
}
