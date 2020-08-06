using LocacaoFilmes.Entidades.Padroes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoFilmes.Negocios.Servicos
{
    public interface ICrudServico<TEntity>
        where TEntity : Entidade
    {
        Task<TEntity> BuscarPorCodigoAsync(long id);

        Task<TEntity> InserirAsync(TEntity entity);

        bool Inserir(IEnumerable<TEntity> items);

        TEntity Alterar(TEntity entity);

        IEnumerable<TEntity> Alterar(IEnumerable<TEntity> entities);

        Task<TEntity> Salvar(TEntity entity);

        void Deletar(long id);

        List<TEntity> BuscarPagina(int limit, int offset);

        TEntity Buscar(long id);

        List<TEntity> GetAllById(long[] ids);

        bool Existe(long id);

        bool CanDelete(long id);
    }
}
