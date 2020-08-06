using LocacaoFilmes.Entidades.Padroes;
using LocacaoFilmes.Repositorio.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoFilmes.Negocios.Servicos
{
    public abstract class CrudServico<TEntity> : ICrudServico<TEntity>
        where TEntity : Entidade
    {
        private readonly IRepositorio<TEntity> _repository;

        protected CrudServico(IRepositorio<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<TEntity> BuscarPorCodigoAsync(long id)
        {
            return await _repository.BuscarPorCodigoAsync(id);
        }

        public virtual async Task<TEntity> InserirAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public virtual bool Inserir(IEnumerable<TEntity> items)
        {
            var itemsList = items.ToList();

            var result = _repository.Add(itemsList);

            return result;
        }

        public virtual TEntity Alterar(TEntity entity)
        {
            _repository.Alterar(entity);

            return entity;
        }

        public virtual IEnumerable<TEntity> Alterar(IEnumerable<TEntity> entities)
        {
            _repository.Alterar(entities);

            return entities;
        }

        public virtual async Task<TEntity> Salvar(TEntity entity)
        {
            if (entity.Id > 0)
                return Alterar(entity);

            return await InserirAsync(entity);
        }

        public virtual void Deletar(long id)
        {
            _repository.Remove(id);
        }

        public virtual List<TEntity> BuscarPagina(int limit, int offset)
        {
            var retorno = _repository.BuscarPagina(limit, offset);
            return retorno;
        }

        public virtual TEntity Buscar(long id)
        {
            var retorno = _repository.Buscar(id);
            return retorno;
        }

        public virtual bool Existe(long id)
        {
            return _repository.Existe(id);
        }

        //Verifica se pode ser excluido.
        public abstract bool CanDelete(long id);

        public List<TEntity> GetAllById(long[] ids)
        {
            return _repository.GetAllById(ids);
        }
    }
}
