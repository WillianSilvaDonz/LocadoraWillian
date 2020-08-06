using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoFilmes.Repositorio.Repositorios
{
    public interface IRepositorio<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);

        Task AddAsync(TEntity obj);

        Task<TEntity> BuscarPorCodigoAsync(long id);

        TEntity Buscar(long id);

        List<TEntity> BuscarPagina(int limit, int offset);

        List<TEntity> GetAllById(long[] ids);

        void Alterar(TEntity entity);

        void Remove(long id);

        bool Add(IEnumerable<TEntity> items);

        bool Alterar(IEnumerable<TEntity> entities);

        bool Existe(long id);
    }
}
