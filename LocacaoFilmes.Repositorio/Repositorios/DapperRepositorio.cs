using LocacaoFilmes.Entidades.Padroes;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using System.Linq;

namespace LocacaoFilmes.Repositorio.Repositorios
{
    public class DapperRepositorio<TEntity> : IRepositorio<TEntity>
        where TEntity : Entidade
    {
        private IDbConnection _connection;

        private readonly IConfiguration _configuration;

        //busca a mesma string de conexão utilizada pelo entity
        public DapperRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected IDbConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_configuration.GetConnectionString("FilmeLocadoraSql"));
            }

            return _connection;
        }

        public void Add(TEntity entity)
        {
            GetConnection().Insert(entity);
        }

        public bool Add(IEnumerable<TEntity> items)
        {
            foreach (var entity in items)
                GetConnection().Insert(entity);

            return true;
        }

        public Task AddAsync(TEntity entity)
        {
            return GetConnection().InsertAsync(entity);
        }

        public bool Existe(long id)
        {
            return Buscar(id) != null;
        }

        public TEntity Buscar(long id)
        {
            return GetConnection().Get<TEntity>(id);
        }

        public List<TEntity> BuscarPagina(int limit, int offset)
        {
            var tableName = typeof(TEntity).Name;

            return GetConnection().Query<TEntity>($"Select * From {tableName} Order by Id Offset @offset ROWS FETCH NEXT @limit ROWS ONLY", new { offset, limit }).ToList();
        }

        public Task<TEntity> BuscarPorCodigoAsync(long id)
        {
            return GetConnection().GetAsync<TEntity>(id);
        }

        public void Remove(long id)
        {
            var entity = Activator.CreateInstance<TEntity>();
            entity.Id = id;
            GetConnection().Delete(entity);
        }

        public void Alterar(TEntity entity)
        {
            GetConnection().Update(entity);
        }


        public bool Alterar(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                GetConnection().Update(entity);

            return true;
        }

        public List<TEntity> GetAllById(long[] ids)
        {
            var tableName = typeof(TEntity).Name;

            return GetConnection().Query<TEntity>($"Select * From {tableName} WHERE Id IN @ids", new { ids }).ToList();
        }
    }
}
