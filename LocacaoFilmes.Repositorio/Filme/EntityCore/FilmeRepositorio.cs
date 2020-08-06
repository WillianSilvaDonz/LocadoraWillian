using LocacaoFilmes.Entidades.Cadastro;
using LocacaoFilmes.Repositorio.Data;
using LocacaoFilmes.Repositorio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoFilmes.Repositorio.EntityCore
{
    public class FilmeRepositorio : EfCoreRepositorio<Filme, EntityDataContext>, IFilmeRepositorio
    {
        public FilmeRepositorio(EntityDataContext context):base(context)
        {
        }

        public List<Filme> BuscarPaginaComGenero(int limit, int offset)
        {
            return DbSet.AsNoTracking().Include(e => e.Genero).Take(limit).Skip(offset).ToList();
        }

        public Filme BuscarPeloCodigoGenero(long generoId)
        {
            return DbSet.FirstOrDefault(e => e.GeneroId == generoId);
        }

        public Task<Filme> BuscarPeloCodigoGeneroAsync(long id)
        {
            return DbSet.Include(e => e.Genero).FirstOrDefaultAsync(e => e.Id == id);
        }

        public Filme BuscarPeloNome(string nome)
        {
            return DbSet.FirstOrDefault(e => e.Nome == nome);
        }

        public List<Filme> BuscarTodosAtivosPeloNome(string nome)
        {
            return DbSet.Where(e => e.Nome.Contains(nome) && e.Ativo).ToList();
        }
    }
}
