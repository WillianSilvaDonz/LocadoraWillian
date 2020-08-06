using Dapper;
using LocacaoFilmes.Entidades.Cadastro;
using LocacaoFilmes.Repositorio.Repositorios;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace LocacaoFilmes.Repositorio.EntityCore
{
    public class GeneroRepositorio : DapperRepositorio<Genero>, IGeneroRepositorio
    {
        public GeneroRepositorio(IConfiguration configuration) : base(configuration)
        {

        }

        public Genero BuscarPeloNome(string generoNome)
        {
            return GetConnection().QueryFirstOrDefault<Genero>("Select * from Genero Where Nome = @generoNome", new { generoNome });
        }

        public List<Genero> BuscarTodosAtivosPeloNome(string nome)
        {
            var sql = "Select * from Genero Where Ativo = 1";

            if (!string.IsNullOrWhiteSpace(nome))
                sql += $" AND Nome LIKE '%{nome}%'";

            return GetConnection().Query<Genero>(sql).ToList();
        }
    }
}
