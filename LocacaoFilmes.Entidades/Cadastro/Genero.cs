using Dapper.Contrib.Extensions;
using LocacaoFilmes.Entidades.Padroes;
using System.Collections.Generic;

namespace LocacaoFilmes.Entidades.Cadastro
{
    [Table("Genero")]
    public class Genero : EntidadeCadastro
    {
        [Computed]
        public ICollection<Filme> Filmes { get; set; }
    }
}
