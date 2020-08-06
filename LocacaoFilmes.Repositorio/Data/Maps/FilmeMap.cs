using LocacaoFilmes.Entidades.Cadastro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocacaoFilmes.Repositorio.Data.Maps
{
    public class FilmeMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.HasOne(e => e.Genero).WithMany(e => e.Filmes).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
