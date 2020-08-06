using LocacaoFilmes.Entidades.Cadastro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocacaoFilmes.Repositorio.Data.Maps
{
    public class GeneroMap : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("Genero");
            builder.Property(x => x.DataCriacao).HasColumnType("datetime");
        }
    }
}
