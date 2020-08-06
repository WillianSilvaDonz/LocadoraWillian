using LocacaoFilmes.Entidades.Cadastro;
using LocacaoFilmes.Entidades.Locacao;
using LocacaoFilmes.Repositorio.Data.Maps;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocacaoFilmes.Repositorio.Data
{
    public class EntityDataContext : IdentityDbContext
    {
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Locacao> Locacao { get; set; }

        public EntityDataContext(DbContextOptions<EntityDataContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FilmeMap());
            builder.ApplyConfiguration(new GeneroMap());
            builder.ApplyConfiguration(new LocacaoMap());
            builder.ApplyConfiguration(new FilmeLocacaoMap());

            base.OnModelCreating(builder);
        }
    }
}
