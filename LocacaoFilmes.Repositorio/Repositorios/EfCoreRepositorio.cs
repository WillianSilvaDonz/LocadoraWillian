using LocacaoFilmes.Entidades.Padroes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoFilmes.Repositorio.Repositorios
{
    public class EfCoreRepositorio
    <TEntity, TContext> : IRepositorio<TEntity>
        where TEntity : Entidade
        where TContext : DbContext
    {
        private readonly TContext _context;

        protected readonly DbSet<TEntity> DbSet;

        private void SalvarAlteracao()
        {
            _context.SaveChanges();
        }

        private async Task SalvarAlteracaoAsync()
        {
            await _context.SaveChangesAsync();
        }

        public EfCoreRepositorio(TContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
            SalvarAlteracao();
        }

        public async Task AddAsync(TEntity obj)
        {
            await DbSet.AddAsync(obj);
            await SalvarAlteracaoAsync();
        }

        public virtual Task<TEntity> BuscarPorCodigoAsync(long id)
            => DbSet.FindAsync(id).AsTask();

        public virtual TEntity Buscar(long id)
            => DbSet.Find(id);

        public virtual List<TEntity> BuscarPagina(int limit, int offset)
        {
            return DbSet.Take(limit).Skip(offset).ToList();
        }

        public virtual void Alterar(TEntity obj)
        {
            DbSet.Update(obj);
            SalvarAlteracao();
        }

        public bool Existe(long id)
        {
            if (id == 0) return false;

            return DbSet.ToList().Any(e => e.Id == id);
        }

        public void Remove(long id)
        {
            var entity = DbSet.Find(id);

            if (entity != null)
            {
                DbSet.Remove(entity);
                SalvarAlteracao();
            }
        }

        public bool Add(IEnumerable<TEntity> items)
        {
            var list = items.ToList();
            foreach (var item in list)
            {
                DbSet.Add(item);
            }
            SalvarAlteracao();
            return true;
        }

        public bool Alterar(IEnumerable<TEntity> entities)
        {
            var list = entities.ToList();

            foreach (var item in list)
            {
                DbSet.Update(item);
            }
            _context.SaveChanges();
            return true;
        }

        public List<TEntity> GetAllById(long[] ids)
        {
            return DbSet.Where(e => ids.Contains(e.Id)).ToList();
        }
    }
}
