using LocacaoFilmes.Entidades.Relacionamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocacaoFilmes.Repositorio.Data.Maps
{
    public class FilmeLocacaoMap : IEntityTypeConfiguration<FilmeLocacao>
    {
        public void Configure(EntityTypeBuilder<FilmeLocacao> builder)
        {
            builder.HasIndex(t => new { t.FilmeId, t.LocacaoId }).IsUnique();

            builder.HasOne(e => e.Filme).WithMany(e => e.Locacoes).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
